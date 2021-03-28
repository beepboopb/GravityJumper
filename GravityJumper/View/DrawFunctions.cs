// <copyright file="DrawFunctions.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System.Diagnostics.CodeAnalysis;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GravityJumper.View
{
    [ExcludeFromCodeCoverage]
    public class DrawFunctions
    {
        private readonly SpriteBatch spriteBatch;
        private readonly float scale;

        public DrawFunctions(GraphicsDevice graphicsDevice, float scale)
        {
            this.spriteBatch = new SpriteBatch(graphicsDevice);
            this.scale = scale;
        }

        public void BeginDraw(Matrix transform)
        {
            this.spriteBatch.Begin(transformMatrix: transform);
        }

        public void EndDraw()
        {
            this.spriteBatch.End();
        }

        /// <summary>
        /// Überladung von DrawSprites.
        /// </summary>
        /// <param name="sprite">Textur.</param>
        /// <param name="destination">Rectangle.</param>
        /// <param name ="c">Color.</param>
        /// <param name ="frame"><see cref="Rectangle"/>.</param>
        public void DrawSprite(Texture2D sprite, Rectangle destination, Color c, Rectangle frame = default)
        {
            if (frame != default)
            {
                this.spriteBatch.Draw(sprite, destination, frame, c);
            }
            else
            {
                this.spriteBatch.Draw(sprite, destination, c);
            }
        }
    }
}
