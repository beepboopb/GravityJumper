// <copyright file="Block.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using Microsoft.Xna.Framework;
using GravityJumper.Model.Interfaces;

namespace GravityJumper.Model.Blocks
{
    // Every kind of Block that is currently in the game.
    public enum BlockType
    {
        Stone,
        Speertrap,
        Spawnpoint,
        EnemyBarrier,
        Pillar,
        Background,
        GravChange,
        Goal,
        Despawn,
        Switch,
    }

    // The direction the Block faces.
    public enum BlockDirection
    {
        Upwards,
        Downwards,
        Left,
        Right,
    }

/// <summary>
/// defines a block and implements the interfaces.
/// for a description of the methods look in Models.Interfaces.IBlock.cs.
/// </summary>
    public abstract class Block : IDrawableBlock, IBlock
    {
        public Block(Vector2 position, Vector2 size, BlockType type, BlockDirection direction = BlockDirection.Upwards)
        {
            this.Position = position;
            this.Size = size;
            this.Type = type;
            this.Hitbox = new Rectangle((int)position.X, (int)position.Y, (int)size.X, (int)size.Y);
            this.Dir = direction;
            if (type == BlockType.Switch)
            {
                this.SwitchState = false;
                this.SwitchChanged = false;
            }
        }

        public Rectangle Hitbox { get; set; }

        public Vector2 Position { get; set; }

        public BlockType Type { get; set; }

        public BlockDirection Dir { get; set; }

        public Vector2 Size { get; set; }

        public bool SwitchState { get; set; }

        public bool SwitchChanged { get; set; }

        public bool CollideWith(Vector2 pos, Vector2 size, bool isPlayer)
        {
            if (this.Type == BlockType.Spawnpoint)
            {
                return false;
            }

            if (isPlayer && this.Type == BlockType.EnemyBarrier)
            {
                return false;
            }

            if (isPlayer && this.Type == BlockType.Despawn && this.Hitbox == new Rectangle((int)this.Position.X, (int)this.Position.Y, 0, 0))
            {
                return false;
            }

            if (this.Position.X < pos.X + size.X &&
                this.Position.X + this.Size.X > pos.X &&
                this.Position.Y < pos.Y + size.Y &&
                this.Position.Y + this.Size.Y > pos.Y)
            {
                return true;
            }

            return false;
        }

        public bool IsAbove(Vector2 pos, Vector2 size)
        {
            if (this.Position.Y + this.Size.Y < pos.Y)
            {
                return true;
            }

            return false;
        }

        public bool IsBelow(Vector2 pos, Vector2 size)
        {
            if (pos.Y + size.Y < this.Position.Y)
            {
                return true;
            }

            return false;
        }

        public bool IsRightOf(Vector2 pos, Vector2 size)
        {
            if (pos.X + size.X < this.Position.X)
            {
                return true;
            }

            return false;
        }

        public bool IsLeftOf(Vector2 pos, Vector2 size)
        {
            if (this.Position.X + this.Size.X < pos.X)
            {
                return true;
            }

            return false;
        }
    }
}
