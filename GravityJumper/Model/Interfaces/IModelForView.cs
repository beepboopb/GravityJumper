// <copyright file="IModelForView.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace GravityJumper.Model.Interfaces
{
    public interface IModelForView
    {
        // Provides interface to draw Player model.
        IDrawableEntity Player { get; }

        // gets matrix that follows the player.
        public Matrix Transform { get; }

        // Name of the current level.
        string CurrentLevel { get; }

        /// <summary>
        /// Gets Schnittstelle zu allen Blöcken.
        /// </summary>
        IEnumerable<IDrawableBlock> Blocks { get; }

        // Gets Interface to Entities.
        IEnumerable<IDrawableEntity> Entities { get; }
    }
}