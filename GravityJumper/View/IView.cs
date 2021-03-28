// <copyright file="IView.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System.Collections.Generic;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace GravityJumper.View
{
    public interface IView
    {
        float Scale { get; }

        List<SoundEffect> Audio { get; }

        void LoadContent(GraphicsDevice graphicsDevice, ContentManager content);

        void Draw();
    }
}
