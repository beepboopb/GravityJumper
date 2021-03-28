// <copyright file="IBlock.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using GravityJumper.Model.Blocks;
using Microsoft.Xna.Framework;

namespace GravityJumper.Model.Interfaces
{
    public interface IBlock
    {
        /// <summary>
        /// gets the position of the block.
        /// </summary>
        public Vector2 Position { get; }

        /// <summary>
        /// gets the size of the block.
        /// X = witdh, y = height.
        /// </summary>
        public Vector2 Size { get; }

        /// <summary>
        /// gets the type of the block.
        /// BlockType is a enum defined in Models.Blocks.Block.cs.
        /// </summary>
        public BlockType Type { get; }

        /// <summary>
        /// gets the direction of the block.
        /// BlockDirection is a enum defined in Models.Blocks.Block.cs.
        /// </summary>
        public BlockDirection Dir { get; }

        // TODO: describe what this is for, and removes [???]

        /// <summary>
        /// Gets or sets a value indicating whether ???.
        /// </summary>
        public bool SwitchState { get; set; }

        /// <summary>
        ///  Gets or  sets a value indicating whether ???.
        /// </summary>
        public bool SwitchChanged { get; set; }

        /// <summary>
        /// Checks whether an entity(or something similar) collides with the block.
        /// </summary>
        /// <param name="pos">position of the entity.</param>
        /// <param name="size">size of the entity.</param>
        /// <param name="isPlayer">a value indivating whether the entity is the player or not.</param>
        /// <returns>true means they collide. false not.</returns>
        public bool CollideWith(Vector2 pos, Vector2 size, bool isPlayer);

        /// <summary>
        /// Checks whether an entity(or something similar) is above the block.
        /// </summary>
        /// <param name="pos">position of the entity.</param>
        /// <param name="size">size of the entity.</param>
        /// <returns>true means it is above. false not.</returns>
        public bool IsAbove(Vector2 pos, Vector2 size);

        /// <summary>
        /// Checks whether an entity(or something similar) is below the block.
        /// </summary>
        /// <param name="pos">position of the entity.</param>
        /// <param name="size">size of the entity.</param>
        /// <returns>true means it is below. false not.</returns>
        public bool IsBelow(Vector2 pos, Vector2 size);

        /// <summary>
        /// Checks whether an entity(or something similar) is right of the block.
        /// </summary>
        /// <param name="pos">position of the entity.</param>
        /// <param name="size">size of the entity.</param>
        /// <returns>true means it is right of. false not.</returns>
        public bool IsRightOf(Vector2 pos, Vector2 size);

        /// <summary>
        /// Checks whether an entity(or something similar) is left of the block.
        /// </summary>
        /// <param name="pos">position of the entity.</param>
        /// <param name="size">size of the entity.</param>
        /// <returns>true means it is left of. false not.</returns>
        public bool IsLeftOf(Vector2 pos, Vector2 size);
    }
}
