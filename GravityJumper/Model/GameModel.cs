// <copyright file="GameModel.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System.Collections.Generic;
using GravityJumper.Model.Blocks;
using GravityJumper.Model.Entities;
using GravityJumper.Model.Interfaces;
using GravityJumper.Model.Util;
using Microsoft.Xna.Framework;

namespace GravityJumper.Model
{
    /// <summary>
    /// GameMode.
    /// </summary>
    public class GameModel : IModelForController, IModelForView
    {
        private IEntity player;
        private Level level;
        private Camera camera;

        public GameModel()
        {
            this.Loadlevel("Level1");
            this.camera = new Camera();
            this.player = this.level.GetPlayer();
        }

        public Vector2 StandardScreenSize => new Vector2(ModelConstants.ScreenWidth, ModelConstants.ScreenWidth * ModelConstants.ScreenAspectRatio);

        public IDrawableEntity Player => this.level.GetPlayer();

        /// <summary>
        /// Gets Blöcke.
        /// </summary>
        public IEnumerable<IDrawableBlock> Blocks => this.level.GetBlocks();

        public IEnumerable<IDrawableEntity> Entities => this.level.GetEntities();

        public Matrix Transform => this.camera.Transform;

        public string CurrentLevel => this.level.GetLevelname();

        /// <summary>
        /// summary.
        /// </summary>
        /// <param name="direction">.</param>
        public void MovePlayer(Vector2 direction)
        {
            this.player.Direction = direction;
        }

        // Creates a Level with the given String.
        public void Loadlevel(string levelname)
        {
            this.level = new Level(levelname);
        }

        public void Update(GameTime gameTime)
        {
            // Resets the Players Position to the Block Spawnpoint if his State is "Dead".
            if (this.player.EntityState == State.Dead)
            {
                this.player.Velocity = Vector2.Zero;
                this.player.Gravity = 0;
                this.player.Position = this.level.GetPlayerSpawn();
                this.player.EntityState = State.IdleRight;
                this.level.SpawnBlock();
            }

            // Loads new Level if the Players state is "Goal".
            if (this.player.EntityState == State.Goal)
            {
                this.player.Velocity = Vector2.Zero;
                int levelindex = int.Parse(this.CurrentLevel.Remove(0, 5));
                this.level = new Level("Level" + (levelindex + 1));
                this.player = this.level.GetPlayer();
            }

            this.player.Update(gameTime, this.level.GetBlocks());
            this.camera.Follow(this.player);
            foreach (IEntity e in this.level.GetEntities())
            {
                // Move Entity returns true if Entity should be removed
                if (e.Update(gameTime, this.level.GetBlocks()))
                {
                   // this.entities.Remove(e);
                    continue;
                }

                // Sets the state Dead if the Player collides with an Enemy.
                if (e.CollideWith(this.player))
                 {
                    this.player.EntityState = State.Dead;
                }

                // Cycles trough the Spritesheet of the Entity.
                e.ElapsedTime += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
                if (e.ElapsedTime >= e.Delay)
                {
                    e.Frame = (e.Frame + 1) % 5;
                    e.ElapsedTime = 0;
                }
            }

            // Logic which removes/adds every despawnable Block if the Block Switch is turned on/off.
            foreach (IBlock b in this.level.GetBlocks())
            {
                if (b.Type == BlockType.Switch)
                {
                    if (b.SwitchChanged && b.SwitchState)
                    {
                        this.level.DespawnBlock();
                    }
                    else if (b.SwitchChanged && !b.SwitchState)
                    {
                        this.level.SpawnBlock();
                    }
                }
            }

            // Cycles through the Spritesheet of the Player.
            this.player.ElapsedTime += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            if (this.player.ElapsedTime >= this.player.Delay)
            {
                this.player.Frame = (this.player.Frame + 1) % 11;
                this.player.ElapsedTime = 0;
            }
        }
    }
}
