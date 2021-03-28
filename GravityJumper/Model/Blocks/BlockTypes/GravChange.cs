// <copyright file="GravChange.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using Microsoft.Xna.Framework;
using GravityJumper.Model.Interfaces;

namespace GravityJumper.Model.Blocks
{
    public class GravChange : Block
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GravChange"/> class.
        /// A Block that changes the Gravity of the Player according to the direction of the Block.
        /// </summary>
        /// <param name="pos">Position.</param>
        /// <param name="size">Size.</param>
        /// <param name="type">Blocktype.</param>
        /// <param name="direction">Direction of the Block(updwards if not given).</param>
        public GravChange(Vector2 pos, Vector2 size, BlockType type, BlockDirection direction = BlockDirection.Upwards)
            : base(pos, size, type, direction)
        {
        }
    }
}