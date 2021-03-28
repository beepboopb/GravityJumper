// <copyright file="IModelForController.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using Microsoft.Xna.Framework;

namespace GravityJumper.Model.Interfaces
{
    public interface IModelForController
    {
        // Provides interface for keyboardhandler (different input logic for each gravity state).
        IDrawableEntity Player { get; }

        // Provides screen size (width, height) from ModelConstants as Vector.
        Vector2 StandardScreenSize { get; }

      /// <summary>
      /// Bewegt den Player.
      /// </summary>
      /// <param name="direction">direction.</param>
        void MovePlayer(Vector2 direction);

        void Update(GameTime gameTime);
    }
}