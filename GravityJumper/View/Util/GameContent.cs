// <copyright file="GameContent.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;

namespace GravityJumper.View.Util
{
    [ExcludeFromCodeCoverage]
    public class GameContent
    {
        public GameContent(ContentManager content)
        {
            // Load playeranimations.
            this.PlayerBottomIdleLeft = content.Load<Texture2D>("Player/PlayerBottom/player_idleleft");
            this.PlayerBottomIdleRight = content.Load<Texture2D>("Player/PlayerBottom/player_idleright");
            this.PlayerBottomWalkright = content.Load<Texture2D>("Player/PlayerBottom/player_walkright");
            this.PlayerBottomWalkleft = content.Load<Texture2D>("Player/PlayerBottom/player_walkleft");
            this.PlayerBottomOnRightWall = content.Load<Texture2D>("Player/PlayerBottom/player_onrightwall");
            this.PlayerBottomOnLeftWall = content.Load<Texture2D>("Player/PlayerBottom/player_onleftwall");
            this.PlayerBottomJumpLeft = content.Load<Texture2D>("Player/PlayerBottom/player_jumpleft");
            this.PlayerBottomJumpRight = content.Load<Texture2D>("Player/PlayerBottom/player_jumpright");

            // Gravitation Top.
            this.PlayerTopIdleLeft = content.Load<Texture2D>("Player/PlayerTop/player_idleleft");
            this.PlayerTopIdleRight = content.Load<Texture2D>("Player/PlayerTop/player_idleright");
            this.PlayerTopWalkright = content.Load<Texture2D>("Player/PlayerTop/player_walkright");
            this.PlayerTopWalkleft = content.Load<Texture2D>("Player/PlayerTop/player_walkleft");
            this.PlayerTopOnRightWall = content.Load<Texture2D>("Player/PlayerTop/player_onrightwall");
            this.PlayerTopOnLeftWall = content.Load<Texture2D>("Player/PlayerTop/player_onleftwall");
            this.PlayerTopJumpLeft = content.Load<Texture2D>("Player/PlayerTop/player_jumpleft");
            this.PlayerTopJumpRight = content.Load<Texture2D>("Player/PlayerTop/player_jumpright");

            // Gravitation Left.
            this.PlayerLeftIdleLeft = content.Load<Texture2D>("Player/PlayerLeft/player_idleleft");
            this.PlayerLeftIdleRight = content.Load<Texture2D>("Player/PlayerLeft/player_idleright");
            this.PlayerLeftWalkright = content.Load<Texture2D>("Player/PlayerLeft/player_walkright");
            this.PlayerLeftWalkleft = content.Load<Texture2D>("Player/PlayerLeft/player_walkleft");
            this.PlayerLeftOnRightWall = content.Load<Texture2D>("Player/PlayerLeft/player_onrightwall");
            this.PlayerLeftOnLeftWall = content.Load<Texture2D>("Player/PlayerLeft/player_onleftwall");
            this.PlayerLeftJumpLeft = content.Load<Texture2D>("Player/PlayerLeft/player_jumpleft");
            this.PlayerLeftJumpRight = content.Load<Texture2D>("Player/PlayerLeft/player_jumpright");

            // Gravitation Right.
            this.PlayerRightIdleLeft = content.Load<Texture2D>("Player/PlayerRight/player_idleleft");
            this.PlayerRightIdleRight = content.Load<Texture2D>("Player/PlayerRight/player_idleright");
            this.PlayerRightWalkright = content.Load<Texture2D>("Player/PlayerRight/player_walkright");
            this.PlayerRightWalkleft = content.Load<Texture2D>("Player/PlayerRight/player_walkleft");
            this.PlayerRightOnRightWall = content.Load<Texture2D>("Player/PlayerRight/player_onrightwall");
            this.PlayerRightOnLeftWall = content.Load<Texture2D>("Player/PlayerRight/player_onleftwall");
            this.PlayerRightJumpLeft = content.Load<Texture2D>("Player/PlayerRight/player_jumpleft");
            this.PlayerRightJumpRight = content.Load<Texture2D>("Player/PlayerRight/player_jumpright");

            // Block sprites.
            this.StoneSprite = content.Load<Texture2D>("block_middle");
            this.Pillar = content.Load<Texture2D>("block_pillar");
            this.SpeertrapSpriteUp = content.Load<Texture2D>("Speertrap/speertrap_up");
            this.SpeertrapSpriteDown = content.Load<Texture2D>("Speertrap/speertrap_down");
            this.GravChangeUp = content.Load<Texture2D>("Gravityplatform/gravblockup");
            this.GravChangeDown = content.Load<Texture2D>("Gravityplatform/gravblockdown");
            this.GravChangeLeft = content.Load<Texture2D>("Gravityplatform/gravblockleft");
            this.GravChangeRight = content.Load<Texture2D>("Gravityplatform/gravblockright");
            this.SwitchOff = content.Load<Texture2D>("switch_off");
            this.SwitchOn = content.Load<Texture2D>("switch_on");
            this.DespawnBlock = content.Load<Texture2D>("block_despawn");

            // Enemie sprites.
            this.Slime = content.Load<Texture2D>("Enemies/Slime/slime");
            this.Slime2 = content.Load<Texture2D>("Enemies/Slime/slime2");

            // Background image.
            this.Background = content.Load<Texture2D>("background");
            this.TutorialBackground = content.Load<Texture2D>("tutorialbackground");

            // Audio.
            this.Audio = new List<SoundEffect>
            {
                content.Load<SoundEffect>("audio/bgm"),
                content.Load<SoundEffect>("audio/walk"),
                content.Load<SoundEffect>("audio/jump"),
            };
        }

        // Getter setter for each sprite.
        public Texture2D PlayerBottomIdleRight { get; set; }

        public Texture2D PlayerBottomIdleLeft { get; set; }

        public Texture2D PlayerBottomOnRightWall { get; set; }

        public Texture2D PlayerBottomOnLeftWall { get; set; }

        public Texture2D PlayerBottomWalkleft { get; set; }

        public Texture2D PlayerBottomJumpLeft { get; set; }

        public Texture2D PlayerBottomJumpRight { get; set; }

        public Texture2D PlayerBottomWalkright { get; set; }

        public Texture2D PlayerLeftIdleRight { get; set; }

        public Texture2D PlayerLeftIdleLeft { get; set; }

        public Texture2D PlayerLeftOnRightWall { get; set; }

        public Texture2D PlayerLeftOnLeftWall { get; set; }

        public Texture2D PlayerLeftWalkleft { get; set; }

        public Texture2D PlayerLeftJumpLeft { get; set; }

        public Texture2D PlayerLeftJumpRight { get; set; }

        public Texture2D PlayerLeftWalkright { get; set; }

        public Texture2D PlayerRightIdleRight { get; set; }

        public Texture2D PlayerRightIdleLeft { get; set; }

        public Texture2D PlayerRightOnRightWall { get; set; }

        public Texture2D PlayerRightOnLeftWall { get; set; }

        public Texture2D PlayerRightWalkleft { get; set; }

        public Texture2D PlayerRightJumpLeft { get; set; }

        public Texture2D PlayerRightJumpRight { get; set; }

        public Texture2D PlayerRightWalkright { get; set; }

        public Texture2D PlayerTopIdleRight { get; set; }

        public Texture2D PlayerTopIdleLeft { get; set; }

        public Texture2D PlayerTopOnRightWall { get; set; }

        public Texture2D PlayerTopOnLeftWall { get; set; }

        public Texture2D PlayerTopWalkleft { get; set; }

        public Texture2D PlayerTopJumpLeft { get; set; }

        public Texture2D PlayerTopJumpRight { get; set; }

        public Texture2D PlayerTopWalkright { get; set; }

        public Texture2D SpeertrapSpriteUp { get; set; }

        public Texture2D SpeertrapSpriteDown { get; set; }

        public Texture2D Slime { get; set;  }

        public Texture2D Slime2 { get; set; }

        public Texture2D Background { get; set; }

        public Texture2D TutorialBackground { get; set; }

        public Texture2D StoneSprite { get; set; }

        public Texture2D Pillar { get; set; }

        public Texture2D GravChangeUp { get; set; }

        public Texture2D GravChangeDown { get; set; }

        public Texture2D GravChangeLeft { get; set; }

        public Texture2D GravChangeRight { get; set; }

        public Texture2D DespawnBlock { get; set; }

        public Texture2D SwitchOff { get; set; }

        public Texture2D SwitchOn { get; set; }

        public List<SoundEffect> Audio { get; set; }
    }
}
