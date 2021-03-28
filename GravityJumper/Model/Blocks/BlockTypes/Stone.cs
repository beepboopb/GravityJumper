// <copyright file="Stone.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using Microsoft.Xna.Framework;
using GravityJumper.Model.Interfaces;

namespace GravityJumper.Model.Blocks
{
    /// <summary>
    /// Ein Stein.#besteDokuEver.
    /// </summary>
    public class Stone : Block
    {
        /// <summary>
        /// A Block which is used as a platform to move on.
        /// </summary>
        /// <param name="pos">Position.</param>
        /// <param name="size">Blocksize.</param>
        /// <param name="type">Blocktype.</param>
        public Stone(Vector2 pos, Vector2 size, BlockType type)
            : base(pos, size, type)
        {
        }
    }
}
