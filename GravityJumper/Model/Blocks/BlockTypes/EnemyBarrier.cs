// <copyright file="EnemyBarrier.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using GravityJumper.Model.Interfaces;
using Microsoft.Xna.Framework;

namespace GravityJumper.Model.Blocks
{
    public class EnemyBarrier : Block
    {
        /// <summary>
        /// Enemy Barrier is a invisible Block that only collides with the entity Enemy1 and other Blocks but not with the Player.
        /// </summary>
        /// <param name="pos">Position.</param>
        /// <param name="size">Size.</param>
        /// <param name="type">Blocktype.</param>
        public EnemyBarrier(Vector2 pos, Vector2 size, BlockType type)
            : base(pos, size, type)
        {
        }
    }
}
