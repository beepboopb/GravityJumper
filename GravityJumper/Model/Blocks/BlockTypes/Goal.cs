// <copyright file="Goal.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using Microsoft.Xna.Framework;
using GravityJumper.Model.Interfaces;

namespace GravityJumper.Model.Blocks
{
    public class Goal : Block
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Goal"/> class.
        /// A Block that will trigger the new level to load if touched.
        /// </summary>
        /// <param name="pos">Position.</param>
        /// <param name="size">Size.</param>
        /// <param name="type">Blocktype.</param>
        public Goal(Vector2 pos, Vector2 size, BlockType type)
            : base(pos, size, type)
        {
        }
    }
}
