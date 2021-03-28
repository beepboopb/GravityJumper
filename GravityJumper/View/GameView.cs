// <copyright file="GameView.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using GravityJumper.Model.Interfaces;
using GravityJumper.View.Util;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace GravityJumper.View
{
    [ExcludeFromCodeCoverage]
    public class GameView : IView
    {
        private readonly IModelForView model;
        private Drawing drawing;

        public GameView(IModelForView model)
        {
            this.model = model;
            this.Scale = ViewConstants.ViewScaleFactor;
        }

        public float Scale { get; set; }

        public List<SoundEffect> Audio { get; set; }

        public void LoadContent(GraphicsDevice graphicsDevice, ContentManager content)
        {
            GameContent gameContent = new GameContent(content);
            this.drawing = new Drawing(this.model, gameContent, graphicsDevice, this.Scale);
            this.Audio = new List<SoundEffect>(gameContent.Audio);
        }

        public void Draw()
        {
            this.drawing.DrawBackground();
            this.drawing.DrawBackgroundImage();
            this.drawing.DrawEntities();
            this.drawing.DrawBlocks();
            this.drawing.DrawPlayer();
            this.drawing.DrawOutput();
        }
    }
}
