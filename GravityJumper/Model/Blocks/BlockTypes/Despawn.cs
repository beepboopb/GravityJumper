// <copyright file="Despawn.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using Microsoft.Xna.Framework;
using GravityJumper.Model.Interfaces;

namespace GravityJumper.Model.Blocks
{
    public class Despawn : Block
    {
        /// <summary>
        /// A Block that despawns if a Switch is turned on and spawns again if it is turned of.
        /// </summary>
        /// <param name="pos">Position.</param>
        /// <param name="size">Size.</param>
        /// <param name="type">Blocktype.</param>
        /// <param name="direction">Direction of the Block(updwards if not given).</param>
        public Despawn(Vector2 pos, Vector2 size, BlockType type, BlockDirection direction = BlockDirection.Upwards)
            : base(pos, size, type, direction)
        {
        }
    }
}
