// <copyright file="IDrawableBlock.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using GravityJumper.Model.Blocks;
using Microsoft.Xna.Framework;

namespace GravityJumper.Model.Interfaces
{
    /// <summary>
    /// Interface für das Zeichnen des Blocks.
    /// </summary>
    public interface IDrawableBlock
    {
        /// <summary>
        /// Gets Schnittstelle zur Hitbox( Beinhaltet Position und Größe des Blocks).
        /// </summary>
        Rectangle Hitbox { get; }

        // Gets or sets the state of the switch (on/off).
        public bool SwitchState { get; set; }

        // Gets the Type of the Block.
        public BlockType Type { get; }

        // Gets the Direction of the Block (will be upwards if not given).
        public BlockDirection Dir { get; }
    }
}
