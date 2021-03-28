// <copyright file="IDrawableEntity.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using GravityJumper.Model.Entities;
using Microsoft.Xna.Framework;

namespace GravityJumper.Model.Interfaces
{
    public interface IDrawableEntity
    {
        // Player position as x and y coordinate.
        Vector2 Position { get; }

        // Get the current Frame of the Spritesheet.
        public int Frame { get; }

        // Get the current state of the Player: moving, jumping etc.
        State EntityState { get; }

        // Vector Player width and height.
        Vector2 Size { get; }

        // Gets or Sets the Current Gravity of the Player (integer between 0 and 3).
        // 0 = Gravity Bottom
        // 1 = Gravity Right
        // 2 = Gravity Top
        // 3 = Gravity Left
        int Gravity { get; set; }

        // Gets if Player is on ground (used for jumpsound).
        public bool Grounded { get; }

        // Gets number of remaining extra jumps (used for jumpsound).
        public int ExtraJumps { get; }
    }
}
