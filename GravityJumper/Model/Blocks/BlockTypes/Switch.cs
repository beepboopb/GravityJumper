// <copyright file="Switch.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using Microsoft.Xna.Framework;
using GravityJumper.Model.Interfaces;

namespace GravityJumper.Model.Blocks
{
    public class Switch : Block
    {
        /// <summary>
        /// A Block that makes all Despawn Blocks invisible and sets their Hitbox to 0 if touched. The Blocks will be visible again if the Switch is turned off.
        /// </summary>
        /// <param name="pos">Position.</param>
        /// <param name="size">Size.</param>
        /// <param name="type">Blocktype.</param>
        /// <param name="direction">Direction of the Block(updwards if not given).</param>
        public Switch(Vector2 pos, Vector2 size, BlockType type, BlockDirection direction = BlockDirection.Upwards)
            : base(pos, size, type, direction)
        {
        }
    }
}
