// <copyright file="KeyboardHandler.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using GravityJumper.Model.Interfaces;
using GravityJumper.View;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Input;

namespace GravityJumper.Controller
{
    [ExcludeFromCodeCoverage]
    public class KeyboardHandler
    {
        private readonly IModelForController model;
        private readonly IView view;
        private SoundEffectInstance walksound;
        private SoundEffectInstance jumpsound;

        public KeyboardHandler(IModelForController model, IView view)
        {
            this.model = model;
            this.view = view;
        }

        public void HandleKeyboardPlayingInput(GameTime gameTime, KeyboardState state)
        {
            this.HandleKeyboardPlayerMovement(gameTime, state);
        }

        private void HandleKeyboardPlayerMovement(GameTime gameTime, KeyboardState state)
        {
            Vector2 moveDirection = Vector2.Zero;
            if (this.model.Player.Gravity == 0)
            {
                // move Left
                if (state.IsKeyDown(Keys.A) && !state.IsKeyDown(Keys.D))
                {
                    moveDirection.X = -1;
                    this.Playsound("walk");
                }

                // move Right
                if (state.IsKeyDown(Keys.D) && !state.IsKeyDown(Keys.A))
                {
                    moveDirection.X = 1;
                    this.Playsound("walk");
                }
            }

            if (this.model.Player.Gravity == 1)
            {
                // move Right
                if (state.IsKeyDown(Keys.A) && !state.IsKeyDown(Keys.D))
                {
                    moveDirection.Y = 1;
                    this.Playsound("walk");
                }

                // move Left
                if (state.IsKeyDown(Keys.D) && !state.IsKeyDown(Keys.A))
                {
                    moveDirection.Y = -1;
                    this.Playsound("walk");
                }
            }

            if (this.model.Player.Gravity == 2)
            {
                // move Left
                if (state.IsKeyDown(Keys.A) && !state.IsKeyDown(Keys.D))
                {
                    moveDirection.X = 1;
                    this.Playsound("walk");
                }

                // move Right
                if (state.IsKeyDown(Keys.D) && !state.IsKeyDown(Keys.A))
                {
                    moveDirection.X = -1;
                    this.Playsound("walk");
                }
            }

            if (this.model.Player.Gravity == 3)
            {
                // move Left
                if (state.IsKeyDown(Keys.W) && !state.IsKeyDown(Keys.S))
                {
                    moveDirection.Y = -1;
                    this.Playsound("walk");
                }

                // move Right
                if (state.IsKeyDown(Keys.S) && !state.IsKeyDown(Keys.W))
                {
                    moveDirection.Y = 1;
                    this.Playsound("walk");
                }
            }

            // jump
            if (state.IsKeyDown(Keys.Space))
            {
                moveDirection.Y = -1;
                this.Playsound("jump");
            }

            this.model.MovePlayer(moveDirection);
        }

        private void Playsound(string sound)
        {
            if (sound.Equals("walk"))
            {
                if (this.view.Audio != null && this.walksound == null)
                {
                    this.walksound = this.view.Audio[1].CreateInstance();
                    this.walksound.Volume = 0.05f;
                }

                this.walksound.Play();
                return;
            }
            else if (sound.Equals("jump"))
            {
                if (this.view.Audio != null && this.jumpsound == null)
                {
                    this.jumpsound = this.view.Audio[2].CreateInstance();
                    this.jumpsound.Volume = 0.05f;
                }

                if (this.model.Player.Grounded || this.model.Player.ExtraJumps > 0)
                {
                    this.jumpsound.Play();
                    return;
                }
            }
        }
    }
}
