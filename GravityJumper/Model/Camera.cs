// <copyright file="Camera.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using Microsoft.Xna.Framework;
using GravityJumper.Model.Interfaces;
using GravityJumper.Model.Util;

namespace GravityJumper.Model
{
    // Camera is the View that follows the Player model based on its position.
    public class Camera
    {
        // Getter for the Draw method in View.
        public Matrix Transform { get; private set; }

        // Make the Screen follow the Player.
        public void Follow(IEntity target)
        {
            float coordx = target.Position.X;
            float coordy = target.Position.Y;
            this.Transform = Calculate(coordx, coordy);
        }

        // Calculates the Position of the View so that the Player will be in the middle of it.
        private static Matrix Calculate(float coordx, float coordy)
        {
            Rectangle targetRectangle = new Rectangle((int)coordx, (int)coordy, 80, 80);
            var position = Matrix.CreateTranslation(
               -coordx - (targetRectangle.Width / 2),
               -coordy - (targetRectangle.Height / 2),
               0);

            var offset = Matrix.CreateTranslation(
                ModelConstants.ScreenWidth / 2,
                ((ModelConstants.ScreenWidth * ModelConstants.ScreenAspectRatio) / 2) + 100,
                0);
            return position * offset;
        }
    }
}