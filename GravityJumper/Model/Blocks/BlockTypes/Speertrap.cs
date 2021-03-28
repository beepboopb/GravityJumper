// <copyright file="Speertrap.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using Microsoft.Xna.Framework;
using GravityJumper.Model.Interfaces;

namespace GravityJumper.Model.Blocks
{
    public class Speertrap : Block
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Speertrap"/> class.
        /// A Speertrap that sets the Playerstate to "Dead" if touched which will result in moving the Player back to the Spawnpoint.
        /// </summary>
        /// <param name="pos">Position.</param>
        /// <param name="size">Size.</param>
        /// <param name="type">Blocktype.</param>
        /// <param name="direction">Direction of the Block(updwards if not given).</param>
        public Speertrap(Vector2 pos, Vector2 size, BlockType type, BlockDirection direction = BlockDirection.Upwards)
            : base(pos, size, type, direction)
        {
        }
    }
}
