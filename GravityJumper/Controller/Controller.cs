// <copyright file="Controller.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System.Diagnostics.CodeAnalysis;
using GravityJumper.Model.Interfaces;
using GravityJumper.View;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Input;

namespace GravityJumper.Controller
{
    [ExcludeFromCodeCoverage]
    public class Controller : Game
    {
        private readonly IModelForController model;
        private readonly IView view;

        private readonly GraphicsDeviceManager graphics;
        private readonly KeyboardHandler keyboardHandler;

        public Controller(IModelForController model, IView view)
        {
            this.model = model;
            this.view = view;
            this.keyboardHandler = new KeyboardHandler(model, view);
            this.graphics = new GraphicsDeviceManager(this);
            this.Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            base.Initialize();

            this.graphics.PreferredBackBufferWidth = (int)(this.view.Scale * this.model.StandardScreenSize.X);
            this.graphics.PreferredBackBufferHeight = (int)(this.view.Scale * this.model.StandardScreenSize.Y);
            this.graphics.ApplyChanges();
        }

        protected override void Update(GameTime gameTime)
        {
            KeyboardState state = Keyboard.GetState();
            this.keyboardHandler.HandleKeyboardPlayingInput(gameTime, state);

            this.model.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            this.view.Draw();
            base.Draw(gameTime);
        }

        protected override void LoadContent()
        {
            this.view.LoadContent(this.GraphicsDevice, this.Content);
            var bgm = this.view.Audio[0].CreateInstance();
            bgm.IsLooped = true;
            bgm.Volume = 0.1f;
            bgm.Play();
        }

        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }
    }
}
