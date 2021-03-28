// <copyright file="Enemy1.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System.Collections.Generic;
using GravityJumper.Model.Interfaces;
using Microsoft.Xna.Framework;

namespace GravityJumper.Model.Entities
{
    public class Enemy1 : Entity
    {
        // Velocity describes the movement speed.
        // Entity State describes the current Spritesheet which gets drawn.
        // Frame is the current frame of the Spritesheet.
        // Delay describes the speed in which the Frames of the Spritesheed cycle through.
        public Enemy1(Vector2 position)
        : base(position, new Vector2(80, 80))
        {
            this.Velocity = new Vector2(0f, 0f);
            this.Direction = new Vector2(1, 0);
            this.Frame = 0;
            this.Delay = 200f;
            this.IsPlayer = false;
    }

        public override bool Update(GameTime gameTime, IEnumerable<IBlock> blocks)
        {
            if (this.TouchingWall != 0)
            {
                this.Direction = new Vector2(this.TouchingWall, 0);
            }

            this.Move(gameTime, blocks);
            return false;
        }

        public override bool CollideWith(IEntity e)
        {
            if (this.HitBox.Intersects(e.HitBox))
            {
                return true;
            }

            return false;
        }
    }
}
