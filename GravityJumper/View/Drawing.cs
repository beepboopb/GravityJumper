// <copyright file="Drawing.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System.Diagnostics.CodeAnalysis;
using GravityJumper.Model.Interfaces;
using GravityJumper.Model.Util;
using GravityJumper.View.Util;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GravityJumper.View
{
    [ExcludeFromCodeCoverage]
    public class Drawing
    {
        private readonly IModelForView model;
        private readonly GameContent gameContent;
        private readonly DrawFunctions drawFunctions;
        private readonly GraphicsDevice graphicsDevice;

        public Drawing(IModelForView model, GameContent gameContent, GraphicsDevice graphicsDevice, float scale)
        {
            this.graphicsDevice = graphicsDevice;
            this.drawFunctions = new DrawFunctions(this.graphicsDevice, scale);
            this.gameContent = gameContent;
            this.model = model;
        }

        // Draw the Blocks in the Background and make the Camera follow the player.
        public void DrawBackground()
        {
            this.graphicsDevice.Clear(Color.SaddleBrown);
            this.drawFunctions.BeginDraw(this.model.Transform);
        }

        // Draws the Backgroundimage depending on the level name.
        public void DrawBackgroundImage()
        {
            if (this.model.CurrentLevel.Equals("Level1"))
            {
                this.drawFunctions.DrawSprite(this.gameContent.TutorialBackground, new Rectangle(0, 0, ModelConstants.LevelWidth, ModelConstants.LevelHeight), Color.White);
            }
            else
            {
                this.drawFunctions.DrawSprite(this.gameContent.Background, new Rectangle(0, 0, ModelConstants.LevelWidth, ModelConstants.LevelHeight), Color.White);
            }
        }

        /// <summary>
        /// Zeichnet alle Blöcke.
        /// </summary>
        public void DrawBlocks()
        {
            foreach (IDrawableBlock block in this.model.Blocks)
            {
                if (block != null)
                {
                    if (block.Type == Model.Blocks.BlockType.Stone)
                    {
                        this.drawFunctions.DrawSprite(this.gameContent.StoneSprite, block.Hitbox, Color.White);
                    }
                    else if (block.Type == Model.Blocks.BlockType.Speertrap && block.Dir == Model.Blocks.BlockDirection.Downwards)
                    {
                        this.drawFunctions.DrawSprite(this.gameContent.SpeertrapSpriteDown, block.Hitbox, Color.White);
                    }
                    else if (block.Type == Model.Blocks.BlockType.Speertrap && block.Dir == Model.Blocks.BlockDirection.Upwards)
                    {
                        this.drawFunctions.DrawSprite(this.gameContent.SpeertrapSpriteUp, block.Hitbox, Color.White);
                    }
                    else if (block.Type == Model.Blocks.BlockType.Pillar)
                    {
                        this.drawFunctions.DrawSprite(this.gameContent.Pillar, block.Hitbox, Color.White);
                    }
                    else if (block.Type == Model.Blocks.BlockType.GravChange && block.Dir == Model.Blocks.BlockDirection.Upwards)
                    {
                        this.drawFunctions.DrawSprite(this.gameContent.GravChangeUp, block.Hitbox, Color.White);
                    }
                    else if (block.Type == Model.Blocks.BlockType.GravChange && block.Dir == Model.Blocks.BlockDirection.Left)
                    {
                        this.drawFunctions.DrawSprite(this.gameContent.GravChangeLeft, block.Hitbox, Color.White);
                    }
                    else if (block.Type == Model.Blocks.BlockType.GravChange && block.Dir == Model.Blocks.BlockDirection.Downwards)
                    {
                        this.drawFunctions.DrawSprite(this.gameContent.GravChangeDown, block.Hitbox, Color.White);
                    }
                    else if (block.Type == Model.Blocks.BlockType.GravChange && block.Dir == Model.Blocks.BlockDirection.Right)
                    {
                        this.drawFunctions.DrawSprite(this.gameContent.GravChangeRight, block.Hitbox, Color.White);
                    }
                    else if (block.Type == Model.Blocks.BlockType.Background)
                    {
                        this.drawFunctions.DrawSprite(this.gameContent.StoneSprite, block.Hitbox, new Color(77, 0, 9));
                    }
                    else if (block.Type == Model.Blocks.BlockType.Despawn && block.SwitchState == false)
                    {
                        this.drawFunctions.DrawSprite(this.gameContent.DespawnBlock, block.Hitbox, Color.White);
                    }
                    else if (block.Type == Model.Blocks.BlockType.Switch && block.SwitchState == false)
                    {
                        this.drawFunctions.DrawSprite(this.gameContent.SwitchOff, block.Hitbox, Color.White);
                    }
                    else if (block.Type == Model.Blocks.BlockType.Switch && block.SwitchState == true)
                    {
                        this.drawFunctions.DrawSprite(this.gameContent.SwitchOn, block.Hitbox, Color.White);
                    }
                }
            }
        }

        // Draw every entity which is not the player.
        public void DrawEntities()
        {
            foreach (IDrawableEntity entity in this.model.Entities)
            {
                if (entity != null)
                {
                    if (entity.EntityState == Model.Entities.State.WalkLeft)
                    {
                        this.drawFunctions.DrawSprite(this.gameContent.Slime, new Rectangle((int)entity.Position.X, (int)entity.Position.Y, (int)entity.Size.X, (int)entity.Size.Y), new Color(255, 255, 255), new Rectangle(entity.Frame * 80, 0, 80, 80));
                    }
                    else
                    {
                        this.drawFunctions.DrawSprite(this.gameContent.Slime2, new Rectangle((int)entity.Position.X, (int)entity.Position.Y, (int)entity.Size.X, (int)entity.Size.Y), new Color(255, 255, 255), new Rectangle(entity.Frame * 80, 0, 80, 80));
                    }
                }
            }
        }

        // Draw Player with each Gravity option.
        public void DrawPlayer()
        {
            switch (this.model.Player.Gravity)
            {
                case 0:
                 switch (this.model.Player.EntityState)
                {
                    case Model.Entities.State.IdleRight:
                         this.drawFunctions.DrawSprite(this.gameContent.PlayerBottomIdleRight, new Rectangle((int)this.model.Player.Position.X, (int)this.model.Player.Position.Y, (int)this.model.Player.Size.X, (int)this.model.Player.Size.Y), Color.White, new Rectangle(this.model.Player.Frame * 40, 0, 40, 60));
                         break;
                    case Model.Entities.State.IdleLeft:
                         this.drawFunctions.DrawSprite(this.gameContent.PlayerBottomIdleLeft, new Rectangle((int)this.model.Player.Position.X, (int)this.model.Player.Position.Y, (int)this.model.Player.Size.X, (int)this.model.Player.Size.Y), Color.White, new Rectangle(this.model.Player.Frame * 40, 0, 40, 60));
                         break;
                    case Model.Entities.State.WalkRight:
                         this.drawFunctions.DrawSprite(this.gameContent.PlayerBottomWalkright, new Rectangle((int)this.model.Player.Position.X, (int)this.model.Player.Position.Y, (int)this.model.Player.Size.X, (int)this.model.Player.Size.Y), Color.White, new Rectangle(this.model.Player.Frame * 40, 0, 40, 60));
                         break;
                    case Model.Entities.State.WalkLeft:
                         this.drawFunctions.DrawSprite(this.gameContent.PlayerBottomWalkleft, new Rectangle((int)this.model.Player.Position.X, (int)this.model.Player.Position.Y, (int)this.model.Player.Size.X, (int)this.model.Player.Size.Y), Color.White, new Rectangle(this.model.Player.Frame * 40, 0, 40, 60));
                         break;
                    case Model.Entities.State.JumpRight:
                         this.drawFunctions.DrawSprite(this.gameContent.PlayerBottomJumpRight, new Rectangle((int)this.model.Player.Position.X, (int)this.model.Player.Position.Y, (int)this.model.Player.Size.X, (int)this.model.Player.Size.Y), Color.White, new Rectangle(this.model.Player.Frame * 40, 0, 40, 60));
                         break;
                    case Model.Entities.State.JumpLeft:
                         this.drawFunctions.DrawSprite(this.gameContent.PlayerBottomJumpLeft, new Rectangle((int)this.model.Player.Position.X, (int)this.model.Player.Position.Y, (int)this.model.Player.Size.X, (int)this.model.Player.Size.Y), Color.White, new Rectangle(this.model.Player.Frame * 40, 0, 40, 60));
                         break;
                    case Model.Entities.State.OnLeftWall:
                         this.drawFunctions.DrawSprite(this.gameContent.PlayerBottomOnLeftWall, new Rectangle((int)this.model.Player.Position.X, (int)this.model.Player.Position.Y, (int)this.model.Player.Size.X, (int)this.model.Player.Size.Y), Color.White, new Rectangle(this.model.Player.Frame * 40, 0, 40, 60));
                         break;
                    case Model.Entities.State.OnRightWall:
                         this.drawFunctions.DrawSprite(this.gameContent.PlayerBottomOnRightWall, new Rectangle((int)this.model.Player.Position.X, (int)this.model.Player.Position.Y, (int)this.model.Player.Size.X, (int)this.model.Player.Size.Y), Color.White, new Rectangle(this.model.Player.Frame * 40, 0, 40, 60));
                         break;
                 }

                 break;
                case 1:
                 switch (this.model.Player.EntityState)
                    {
                        case Model.Entities.State.IdleRight:
                            this.drawFunctions.DrawSprite(this.gameContent.PlayerRightIdleLeft, new Rectangle((int)this.model.Player.Position.X, (int)this.model.Player.Position.Y, (int)this.model.Player.Size.Y, (int)this.model.Player.Size.X), Color.White, new Rectangle(this.model.Player.Frame * 60, 0, 60, 40));
                            break;
                        case Model.Entities.State.IdleLeft:
                            this.drawFunctions.DrawSprite(this.gameContent.PlayerRightIdleRight, new Rectangle((int)this.model.Player.Position.X, (int)this.model.Player.Position.Y, (int)this.model.Player.Size.Y, (int)this.model.Player.Size.X), Color.White, new Rectangle(this.model.Player.Frame * 60, 0, 60, 40));
                            break;
                        case Model.Entities.State.WalkRight:
                            this.drawFunctions.DrawSprite(this.gameContent.PlayerRightWalkleft, new Rectangle((int)this.model.Player.Position.X, (int)this.model.Player.Position.Y, (int)this.model.Player.Size.Y, (int)this.model.Player.Size.X), Color.White, new Rectangle(this.model.Player.Frame * 60, 0, 60, 40));
                            break;
                        case Model.Entities.State.WalkLeft:
                            this.drawFunctions.DrawSprite(this.gameContent.PlayerRightWalkright, new Rectangle((int)this.model.Player.Position.X, (int)this.model.Player.Position.Y, (int)this.model.Player.Size.Y, (int)this.model.Player.Size.X), Color.White, new Rectangle(this.model.Player.Frame * 60, 0, 60, 40));
                            break;
                        case Model.Entities.State.JumpRight:
                            this.drawFunctions.DrawSprite(this.gameContent.PlayerRightJumpLeft, new Rectangle((int)this.model.Player.Position.X, (int)this.model.Player.Position.Y, (int)this.model.Player.Size.Y, (int)this.model.Player.Size.X), Color.White, new Rectangle(this.model.Player.Frame * 60, 0, 60, 40));
                            break;
                        case Model.Entities.State.JumpLeft:
                            this.drawFunctions.DrawSprite(this.gameContent.PlayerRightJumpRight, new Rectangle((int)this.model.Player.Position.X, (int)this.model.Player.Position.Y, (int)this.model.Player.Size.Y, (int)this.model.Player.Size.X), Color.White, new Rectangle(this.model.Player.Frame * 60, 0, 60, 40));
                            break;
                        case Model.Entities.State.OnLeftWall:
                            this.drawFunctions.DrawSprite(this.gameContent.PlayerRightOnRightWall, new Rectangle((int)this.model.Player.Position.X, (int)this.model.Player.Position.Y, (int)this.model.Player.Size.Y, (int)this.model.Player.Size.X), Color.White, new Rectangle(this.model.Player.Frame * 60, 0, 60, 40));
                            break;
                        case Model.Entities.State.OnRightWall:
                            this.drawFunctions.DrawSprite(this.gameContent.PlayerRightOnLeftWall, new Rectangle((int)this.model.Player.Position.X, (int)this.model.Player.Position.Y, (int)this.model.Player.Size.Y, (int)this.model.Player.Size.X), Color.White, new Rectangle(this.model.Player.Frame * 60, 0, 60, 40));
                            break;
                    }

                 break;
                case 2:
                 switch (this.model.Player.EntityState)
                    {
                        case Model.Entities.State.IdleRight:
                            this.drawFunctions.DrawSprite(this.gameContent.PlayerTopIdleLeft, new Rectangle((int)this.model.Player.Position.X, (int)this.model.Player.Position.Y, (int)this.model.Player.Size.X, (int)this.model.Player.Size.Y), Color.White, new Rectangle(this.model.Player.Frame * 40, 0, 40, 60));
                            break;
                        case Model.Entities.State.IdleLeft:
                            this.drawFunctions.DrawSprite(this.gameContent.PlayerTopIdleRight, new Rectangle((int)this.model.Player.Position.X, (int)this.model.Player.Position.Y, (int)this.model.Player.Size.X, (int)this.model.Player.Size.Y), Color.White, new Rectangle(this.model.Player.Frame * 40, 0, 40, 60));
                            break;
                        case Model.Entities.State.WalkRight:
                            this.drawFunctions.DrawSprite(this.gameContent.PlayerTopWalkleft, new Rectangle((int)this.model.Player.Position.X, (int)this.model.Player.Position.Y, (int)this.model.Player.Size.X, (int)this.model.Player.Size.Y), Color.White, new Rectangle(this.model.Player.Frame * 40, 0, 40, 60));
                            break;
                        case Model.Entities.State.WalkLeft:
                            this.drawFunctions.DrawSprite(this.gameContent.PlayerTopWalkright, new Rectangle((int)this.model.Player.Position.X, (int)this.model.Player.Position.Y, (int)this.model.Player.Size.X, (int)this.model.Player.Size.Y), Color.White, new Rectangle(this.model.Player.Frame * 40, 0, 40, 60));
                            break;
                        case Model.Entities.State.JumpRight:
                            this.drawFunctions.DrawSprite(this.gameContent.PlayerTopJumpLeft, new Rectangle((int)this.model.Player.Position.X, (int)this.model.Player.Position.Y, (int)this.model.Player.Size.X, (int)this.model.Player.Size.Y), Color.White, new Rectangle(this.model.Player.Frame * 40, 0, 40, 60));
                            break;
                        case Model.Entities.State.JumpLeft:
                            this.drawFunctions.DrawSprite(this.gameContent.PlayerTopJumpRight, new Rectangle((int)this.model.Player.Position.X, (int)this.model.Player.Position.Y, (int)this.model.Player.Size.X, (int)this.model.Player.Size.Y), Color.White, new Rectangle(this.model.Player.Frame * 40, 0, 40, 60));
                            break;
                        case Model.Entities.State.OnLeftWall:
                            this.drawFunctions.DrawSprite(this.gameContent.PlayerTopOnRightWall, new Rectangle((int)this.model.Player.Position.X, (int)this.model.Player.Position.Y, (int)this.model.Player.Size.X, (int)this.model.Player.Size.Y), Color.White, new Rectangle(this.model.Player.Frame * 40, 0, 40, 60));
                            break;
                        case Model.Entities.State.OnRightWall:
                            this.drawFunctions.DrawSprite(this.gameContent.PlayerTopOnLeftWall, new Rectangle((int)this.model.Player.Position.X, (int)this.model.Player.Position.Y, (int)this.model.Player.Size.X, (int)this.model.Player.Size.Y), Color.White, new Rectangle(this.model.Player.Frame * 40, 0, 40, 60));
                            break;
                    }

                 break;
                case 3:
                 switch (this.model.Player.EntityState)
                    {
                        case Model.Entities.State.IdleRight:
                            this.drawFunctions.DrawSprite(this.gameContent.PlayerLeftIdleLeft, new Rectangle((int)this.model.Player.Position.X, (int)this.model.Player.Position.Y, (int)this.model.Player.Size.Y, (int)this.model.Player.Size.X), Color.White, new Rectangle(this.model.Player.Frame * 60, 0, 60, 40));
                            break;
                        case Model.Entities.State.IdleLeft:
                            this.drawFunctions.DrawSprite(this.gameContent.PlayerLeftIdleRight, new Rectangle((int)this.model.Player.Position.X, (int)this.model.Player.Position.Y, (int)this.model.Player.Size.Y, (int)this.model.Player.Size.X), Color.White, new Rectangle(this.model.Player.Frame * 60, 0, 60, 40));
                            break;
                        case Model.Entities.State.WalkRight:
                            this.drawFunctions.DrawSprite(this.gameContent.PlayerLeftWalkleft, new Rectangle((int)this.model.Player.Position.X, (int)this.model.Player.Position.Y, (int)this.model.Player.Size.Y, (int)this.model.Player.Size.X), Color.White, new Rectangle(this.model.Player.Frame * 60, 0, 60, 40));
                            break;
                        case Model.Entities.State.WalkLeft:
                            this.drawFunctions.DrawSprite(this.gameContent.PlayerLeftWalkright, new Rectangle((int)this.model.Player.Position.X, (int)this.model.Player.Position.Y, (int)this.model.Player.Size.Y, (int)this.model.Player.Size.X), Color.White, new Rectangle(this.model.Player.Frame * 60, 0, 60, 40));
                            break;
                        case Model.Entities.State.JumpRight:
                            this.drawFunctions.DrawSprite(this.gameContent.PlayerLeftJumpLeft, new Rectangle((int)this.model.Player.Position.X, (int)this.model.Player.Position.Y, (int)this.model.Player.Size.Y, (int)this.model.Player.Size.X), Color.White, new Rectangle(this.model.Player.Frame * 60, 0, 60, 40));
                            break;
                        case Model.Entities.State.JumpLeft:
                            this.drawFunctions.DrawSprite(this.gameContent.PlayerLeftJumpRight, new Rectangle((int)this.model.Player.Position.X, (int)this.model.Player.Position.Y, (int)this.model.Player.Size.Y, (int)this.model.Player.Size.X), Color.White, new Rectangle(this.model.Player.Frame * 60, 0, 60, 40));
                            break;
                        case Model.Entities.State.OnLeftWall:
                            this.drawFunctions.DrawSprite(this.gameContent.PlayerLeftOnRightWall, new Rectangle((int)this.model.Player.Position.X, (int)this.model.Player.Position.Y, (int)this.model.Player.Size.Y, (int)this.model.Player.Size.X), Color.White, new Rectangle(this.model.Player.Frame * 60, 0, 60, 40));
                            break;
                        case Model.Entities.State.OnRightWall:
                            this.drawFunctions.DrawSprite(this.gameContent.PlayerLeftOnLeftWall, new Rectangle((int)this.model.Player.Position.X, (int)this.model.Player.Position.Y, (int)this.model.Player.Size.Y, (int)this.model.Player.Size.X), Color.White, new Rectangle(this.model.Player.Frame * 60, 0, 60, 40));
                            break;
                    }

                 break;
            }
        }

        public void DrawOutput()
        {
            this.drawFunctions.EndDraw();
        }
    }
}
