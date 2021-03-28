// <copyright file="ModelConstants.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace GravityJumper.Model.Util
{
    public class ModelConstants
    {
        // ScreenAndLevel
        public const int ScreenWidth = 1280;
        public const float ScreenAspectRatio = 0.5625f;
        public const int LevelWidth = 8250;
        public const int LevelHeight = 2500;
        public const int BlockSize = 50;

        // Entity
        public const float MaxSpeed = 12f;
        public const float BrakingSpeed = 20f;
        public const float Accerleration = 10f;
        public const float JumpForce = 20f;
        public const float BrakingJump = 50f;
        public const float Gravity = 50f;
        public const float MaxGravity = 1000f;
        public const float WallJumpForce = 15;
        public const int ExtraJumps = 1;

        // Player
        public const int PlayerWidth = 40;
        public const int PlayerHeight = 60;
    }
}
