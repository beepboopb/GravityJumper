// <copyright file="IEntity.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System.Collections.Generic;
using GravityJumper.Model.Entities;
using Microsoft.Xna.Framework;

namespace GravityJumper.Model.Interfaces
{
    public interface IEntity
    {
        /// <summary>
        /// gets or sets position of the entity.
        /// </summary>
        Vector2 Position { get; set; }

        // TODO replace ???? whith helpful description

        /// <summary>
        /// Gets or sets the Current frame of the Spritesheet.
        /// </summary>
        public int Frame { get; set; }

        /// <summary>
        /// gets or sets the State.
        /// State is a enum defined in Models.Entities.Entity.cs.
        /// </summary>
        State EntityState { get; set; }

        /// <summary>
        /// gets or sets the current gravity of the entity.
        /// 0 is normal and each number adds 90 degree rotation.
        /// </summary>
        int Gravity { get; set; }

        /// <summary>
        /// gets or sets the size of the entity.
        /// </summary>
        Vector2 Size { get; set; }

        /// <summary>
        /// gets or sets the direction the entity should move.
        /// </summary>
        public Vector2 Direction { get; set; }

        /// <summary>
        /// Gets or sets the current velocity of the entity.
        /// </summary>
        public Vector2 Velocity { get; set; }

        /// <summary>
        /// Gets or sets the Direction of the prev game loop.
        /// </summary>
        public Vector2 LastDirection { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the entity touches the ground.
        /// </summary>
        public bool Grounded { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the entity is the player.
        /// </summary>
        public bool IsPlayer { get; set; }

        /// <summary>
        /// gets or sets a value indivating whtether the entity touches a wall.
        /// 1 means right wall.
        /// 0 means doesn't touch a wall.
        /// -1 means left wall.
        /// </summary>
        public int TouchingWall { get; set; }

        /// <summary>
        /// gets or sets the amount of extraJumps.
        /// </summary>
        public int ExtraJumps { get; set; }

        /// <summary>
        /// gets or sets ????.
        /// </summary>
        public float Delay { get; set; }

        /// <summary>
        /// gets or sets ????.
        /// </summary>
        public float ElapsedTime { get; set; }

        /// <summary>
        /// gets or sets hitbox.
        /// its position and size combined.
        /// </summary>
        public Rectangle HitBox { get; set; }

        /// <summary>
        /// updates the entity.
        /// </summary>
        /// <param name="gameTime">current gametime for checking how much time past since last call.</param>
        /// <param name="blocks">interfaces of all blocks.</param>
        /// <returns>true = entity can be deleted. false means its allive.</returns>
        public abstract bool Update(GameTime gameTime, IEnumerable<IBlock> blocks);

        /// <summary>
        /// checks wheter the entity collides with another entity.
        /// </summary>
        /// <param name="e">another entity.</param>
        /// <returns>true means they collide. false not.</returns>
        public abstract bool CollideWith(IEntity e);
    }
}
