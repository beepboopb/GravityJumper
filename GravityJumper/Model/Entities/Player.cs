// <copyright file="Player.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System.Collections.Generic;
using Microsoft.Xna.Framework;
using GravityJumper.Model.Interfaces;
using GravityJumper.Model.Util;

namespace GravityJumper.Model.Entities
{
    public class Player : Entity
    {
        // Entity Player.
        // Velocity describes the movement speed.
        // Entity State describes the current Spritesheet which gets drawn.
        // Frame is the current frame of the Spritesheet.
        // Delay describes the speed in which the Frames of the Spritesheed cycle through.
        public Player(Vector2 position)
            : base(position, new Vector2(ModelConstants.PlayerWidth, ModelConstants.PlayerHeight))
        {
            this.Velocity = new Vector2(0f, 0f);
            this.Direction = Vector2.Zero;
            this.EntityState = State.IdleRight;
            this.Frame = 0;
            this.Delay = 200f;
            this.IsPlayer = true;
        }

        public override bool Update(GameTime gameTime, IEnumerable<IBlock> blocks)
        {
            this.Move(gameTime, blocks);
            return false;
        }

        public override bool CollideWith(IEntity e)
        {
            return false;
        }
    }
}
