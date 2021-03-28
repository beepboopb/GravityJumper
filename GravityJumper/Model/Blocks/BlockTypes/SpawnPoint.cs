// <copyright file="SpawnPoint.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using Microsoft.Xna.Framework;
using GravityJumper.Model.Interfaces;

namespace GravityJumper.Model.Blocks
{
    public class SpawnPoint : Block
    {
        /// <summary>
        /// This invisible Block marks the Spawn point of the player.
        /// </summary>
        /// <param name="pos">Position.</param>
        /// <param name="size">Blocksize.</param>
        /// <param name="type">Blocktype.</param>
        public SpawnPoint(Vector2 pos, Vector2 size, BlockType type)
            : base(pos, size, type)
        {
        }
    }
}