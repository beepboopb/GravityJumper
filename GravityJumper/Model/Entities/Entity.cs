// <copyright file="Entity.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using GravityJumper.Model.Interfaces;
using GravityJumper.Model.Util;
using Microsoft.Xna.Framework;

namespace GravityJumper.Model.Entities
{
    // Every state the Player can achieve.
    public enum State
    {
        IdleLeft,
        IdleRight,
        WalkLeft,
        WalkRight,
        JumpLeft,
        JumpRight,
        OnLeftWall,
        OnRightWall,
        Dead,
        Goal,
    }

    /// <summary>
    /// defines an entity and implements the interfaces.
    /// for a description of the public methods look in Models.Interfaces.IEntits.cs.
    /// </summary>
    public abstract class Entity : IDrawableEntity, IEntity
    {
        public Entity(Vector2 position, Vector2 size)
        {
            this.Position = position;
            this.Size = size;
            this.HitBox = new Rectangle((int)this.Position.X, (int)this.Position.Y, (int)this.Size.X, (int)this.Size.Y);
        }

        public Vector2 Size { get; set; }

        public State EntityState { get; set; }

        public int Frame { get; set; }

        public float Delay { get; set; }

        public float ElapsedTime { get; set; }

        public Vector2 Position { get; set; }

        public Vector2 Velocity { get; set; }

        public Rectangle HitBox { get; set; }

        public Vector2 Direction { get; set; }

        public Vector2 LastDirection { get; set; }

        public bool Grounded { get; set; }

        public bool IsPlayer { get; set; } = false;

        public int TouchingWall { get; set; }

        public int ExtraJumps { get; set; }

        public int Gravity { get; set; }

        public abstract bool Update(GameTime gameTime, IEnumerable<IBlock> blocks);

        public abstract bool CollideWith(IEntity e);

        public void Move(GameTime gameTime, IEnumerable<IBlock> blocks)
        {
            this.CheckForWalls(blocks);
            this.Velocity += this.Accelerate(gameTime);
            this.UpdateState();

            Vector2 moveDistance;
            moveDistance.X = this.ApplyGravity(this.Velocity).X * (float)(gameTime.ElapsedGameTime.TotalMilliseconds / 1000);
            moveDistance.Y = this.ApplyGravity(this.Velocity).Y * (float)(gameTime.ElapsedGameTime.TotalMilliseconds / 1000);

            IBlock b = this.CheckMovementOkay(moveDistance, blocks);

            // if Entity would collide with a Block
            if (b != null)
            {
                moveDistance = Vector2.Zero;

                // if Block is a trap
                if (b.Type == Blocks.BlockType.Speertrap)
                {
                    this.EntityState = State.Dead;
                    return;
                }
                else if (b.Type == Blocks.BlockType.Goal)
                {
                    this.EntityState = State.Goal;
                    return;
                }
                else if (b.Type == Blocks.BlockType.Switch && b.SwitchState == false)
                {
                    b.SwitchState = true;
                    b.SwitchChanged = true;
                }
                else if (b.Type == Blocks.BlockType.Switch && b.SwitchState == true)
                {
                    b.SwitchState = false;
                    b.SwitchChanged = true;
                }

                if (b.Type == Blocks.BlockType.GravChange && b.Dir == Blocks.BlockDirection.Downwards)
                {
                    this.Gravity = 0;
                }
                else if (b.Type == Blocks.BlockType.GravChange && b.Dir == Blocks.BlockDirection.Right)
                {
                    this.Gravity = 1;
                }
                else if (b.Type == Blocks.BlockType.GravChange && b.Dir == Blocks.BlockDirection.Upwards)
                {
                    this.Gravity = 2;
                }
                else if (b.Type == Blocks.BlockType.GravChange && b.Dir == Blocks.BlockDirection.Left)
                {
                    this.Gravity = 3;
                }

                // Block is above Entity
                if (b.IsAbove(this.Position, this.Size))
                {
                    this.Position = new Vector2(this.Position.X, b.Position.Y + b.Size.Y);
                    if (this.Velocity.Y < 0)
                    {
                        this.Velocity = new Vector2(this.Velocity.X, 0);
                    }
                }

                // Block is right of Entity
                if (b.IsRightOf(this.Position, this.Size))
                {
                    this.Position = new Vector2(b.Position.X - this.Size.X, this.Position.Y);
                }

                // Block is below Entity
                if (b.IsBelow(this.Position, this.Size))
                {
                    this.Position = new Vector2(this.Position.X, b.Position.Y - this.Size.Y);

                    // And Right
                    if (b.IsRightOf(this.Position, this.Size))
                    {
                        this.Position = new Vector2(b.Position.X - this.Size.X + 1, this.Position.Y);
                    }

                    // And Left
                    else if (b.IsLeftOf(this.Position, this.Size))
                    {
                        this.Position = new Vector2(b.Position.X + b.Size.X - 1, this.Position.Y);
                    }
                }

                // Block is left of Entity
                if (b.IsLeftOf(this.Position, this.Size))
                {
                    this.Position = new Vector2(b.Position.X + b.Size.X, this.Position.Y);
                }
            }

            this.Position = new Vector2(this.Position.X + moveDistance.X, this.Position.Y + moveDistance.Y);
            this.HitBox = new Rectangle((int)this.Position.X, (int)this.Position.Y, (int)this.Size.X, (int)this.Size.Y);
            this.LastDirection = this.Direction;
        }

        /// <summary>
        /// Checks if the move ends up in a Block.
        /// </summary>
        /// <param name="moveDistance">distance the entity should move.</param>
        /// <param name="blocks">interfaces of all blocks.</param>
        /// <returns> null -> movementOkay. not null -> the interface of the block which collides with.</returns>
        private IBlock CheckMovementOkay(Vector2 moveDistance, IEnumerable<IBlock> blocks)
        {
            this.Position = new Vector2(this.Position.X + moveDistance.X, this.Position.Y + moveDistance.Y);
            foreach (IBlock b in blocks)
            {
                // if Block is to far away continue.
                if (Vector2.Distance(b.Position, this.Position) > 2 * ModelConstants.BlockSize)
                {
                    continue;
                }

                if (b.CollideWith(this.Position, this.Size, this.IsPlayer))
                {
                    this.Position = new Vector2(this.Position.X - moveDistance.X, this.Position.Y - moveDistance.Y);
                    return b;
                }
            }

            this.Position = new Vector2(this.Position.X - moveDistance.X, this.Position.Y - moveDistance.Y);
            return null;
        }

        /// <summary>
        /// Checks the move inputs in Direction and accelerate the entity.
        /// </summary>
        /// <param name="gameTime"> nessesary for checking how much time passed since last function call.</param>
        /// <returns>a acceleration vector which should added to the current velocity.</returns>
        private Vector2 Accelerate(GameTime gameTime)
        {
            Vector2 acceleration = Vector2.Zero;

            // Move in X Axis
            // Braking
            if (this.Velocity.X * this.Direction.X < 0 && this.Direction.X + this.TouchingWall != 0)
            {
                acceleration = new Vector2(ModelConstants.BrakingSpeed * ModelConstants.BlockSize * this.Direction.X * (float)gameTime.ElapsedGameTime.TotalMilliseconds / 1000, 0);
            }

            // Accelerating
            else if (this.Velocity.X * this.Direction.X >= 0 && this.Direction.X != 0 && Math.Abs(this.Velocity.X) < ModelConstants.MaxSpeed * ModelConstants.BlockSize && this.Direction.X + this.TouchingWall != 0)
            {
                acceleration = new Vector2(ModelConstants.Accerleration * ModelConstants.BlockSize * this.Direction.X * (float)gameTime.ElapsedGameTime.TotalMilliseconds / 1000, 0);
            }

            // No Input
            else if (this.Direction.X == 0)
            {
                // Moving with a higher Velocity than BrakingSpeed*Blocksize
                if (Math.Abs(this.Velocity.X) > ModelConstants.BrakingSpeed * ModelConstants.BlockSize * (float)gameTime.ElapsedGameTime.TotalMilliseconds / 1000)
                {
                    acceleration = new Vector2(ModelConstants.BrakingSpeed * ModelConstants.BlockSize * -1 * Math.Sign(this.Velocity.X) * (float)gameTime.ElapsedGameTime.TotalMilliseconds / 1000, 0);
                }
                else
                {
                    acceleration = new Vector2(-this.Velocity.X, 0);
                }
            }

            // Move in Y Axis
            // Gravity
            if (!this.Grounded && this.Velocity.Y < ModelConstants.MaxGravity * ModelConstants.BlockSize)
            {
                acceleration += new Vector2(0, ModelConstants.Gravity * ModelConstants.BlockSize * (float)gameTime.ElapsedGameTime.TotalMilliseconds / 1000);
            }

            // Jump
            if (this.Direction.Y < 0 && this.LastDirection.Y >= 0 && this.Grounded)
            {
                acceleration += new Vector2(0, -1 * ModelConstants.JumpForce * ModelConstants.BlockSize);
            }

            // Extra Jump with 80% Jumpforce
            else if (this.Direction.Y < 0 && this.LastDirection.Y >= 0 && !this.Grounded && this.ExtraJumps > 0 && this.TouchingWall == 0)
            {
                this.ExtraJumps--;
                acceleration += new Vector2(0, (-1 * .8f * ModelConstants.JumpForce * ModelConstants.BlockSize) + -this.Velocity.Y);
            }

            // WallJump
            else if (this.Direction.Y < 0 && this.LastDirection.Y >= 0 && this.TouchingWall != 0)
            {
                acceleration += new Vector2(.6f * ModelConstants.WallJumpForce * ModelConstants.BlockSize * this.TouchingWall, (-1 * ModelConstants.WallJumpForce * ModelConstants.BlockSize) + -this.Velocity.Y);
            }

            // cancle Jump
            if (this.Direction.Y >= 0 && this.Velocity.Y < ModelConstants.BrakingJump * ModelConstants.BlockSize * (float)gameTime.ElapsedGameTime.TotalMilliseconds / 1000 && !this.Grounded)
            {
                acceleration += new Vector2(0, ModelConstants.BrakingJump * ModelConstants.BlockSize * (float)gameTime.ElapsedGameTime.TotalMilliseconds / 1000);
            }

            return acceleration;
        }

        /// <summary>
        /// Checks whether their are blocks arround the entity.
        /// sets Grounded and TouchingWall.
        /// </summary>
        /// <param name="blocks">interfaces of all blocks.</param>
        private void CheckForWalls(IEnumerable<IBlock> blocks)
        {
            this.Grounded = false;
            this.TouchingWall = 0;
            foreach (IBlock b in blocks)
            {
                // if Block is to far away continue.
                if (Vector2.Distance(b.Position, this.Position) > 2 * ModelConstants.BlockSize)
                {
                    continue;
                }

                // check for Ground
                this.Position = this.Position + this.ApplyGravity(new Vector2(0, 1));
                if (b.CollideWith(this.Position, this.Size, this.IsPlayer) && b.Type != Model.Blocks.BlockType.Speertrap)
                {
                    this.Grounded = true;
                    this.ExtraJumps = ModelConstants.ExtraJumps;

                    // stop falling
                    if (this.Velocity.Y > 0)
                    {
                        this.Velocity = new Vector2(this.Velocity.X, 0);
                    }
                }

                // chek for Wall left
                this.Position = this.Position + this.ApplyGravity(new Vector2(-1, -1));
                if (this.TouchingWall != 1 && b.CollideWith(this.Position, this.Size, this.IsPlayer))
                {
                    this.TouchingWall = 1;

                    // stop Velocity
                    if (this.Velocity.X < 0)
                    {
                        this.Velocity = new Vector2(0, this.Velocity.Y);
                    }
                }

                // chek for Wall right
                this.Position = this.Position + this.ApplyGravity(new Vector2(2, 0));
                if (this.TouchingWall != -1 && b.CollideWith(this.Position, this.Size, this.IsPlayer))
                {
                    this.TouchingWall = -1;

                    // stop Velocity
                    if (this.Velocity.X > 0)
                    {
                        this.Velocity = new Vector2(0, this.Velocity.Y);
                    }
                }

                this.Position = this.Position + this.ApplyGravity(new Vector2(-1, 0));
            }
        }

        /// <summary>
        /// updates the state by looking what the entity is doing and in which direction its moving.
        /// </summary>
        private void UpdateState()
        {
            if (this.Grounded)
            {
                if (this.Velocity.X > 0)
                {
                    this.EntityState = State.WalkRight;
                }
                else if (this.Velocity.X < 0)
                {
                    this.EntityState = State.WalkLeft;
                }
                else
                {
                    if (this.EntityState == State.WalkRight || this.EntityState == State.JumpRight || this.EntityState == State.OnRightWall)
                    {
                        this.EntityState = State.IdleRight;
                    }
                    else if (this.EntityState == State.WalkLeft || this.EntityState == State.JumpLeft || this.EntityState == State.OnLeftWall)
                    {
                        this.EntityState = State.IdleLeft;
                    }
                }
            }
            else if (this.TouchingWall != 0)
            {
                if (this.TouchingWall > 0)
                {
                    this.EntityState = State.OnLeftWall;
                }

                if (this.TouchingWall < 0)
                {
                    this.EntityState = State.OnRightWall;
                }
            }
            else
            {
                if (this.Velocity.X > 0)
                {
                    this.EntityState = State.JumpRight;
                }
                else if (this.Velocity.X < 0)
                {
                    this.EntityState = State.JumpLeft;
                }
                else
                {
                    if (this.EntityState == State.WalkRight || this.EntityState == State.IdleRight || this.EntityState == State.OnRightWall)
                    {
                        this.EntityState = State.JumpRight;
                    }
                    else if (this.EntityState == State.WalkLeft || this.EntityState == State.IdleLeft || this.EntityState == State.OnLeftWall)
                    {
                        this.EntityState = State.JumpLeft;
                    }
                }
            }
        }

        /// <summary>
        /// apply the current gravity of the entity.
        /// rotates the vector by [Gravity] * 90 degrees.
        /// </summary>
        /// <param name="v">Vector to apply gravity.</param>
        /// <returns>the vector after gravity was applied.</returns>
        private Vector2 ApplyGravity(Vector2 v)
        {
            double angle = 90 * this.Gravity;

            // deg2rad
            angle *= Math.PI / 180;
            double cos = Math.Cos(angle);
            double sin = Math.Sin(angle);

            float x = (v.X * (float)cos) + (v.Y * (float)sin);
            float y = (v.X * (float)sin) + (v.Y * (float)cos);

            return new Vector2(x, y);
        }
    }
}