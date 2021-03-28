using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using GravityJumper.Model.Blocks;
using GravityJumper.Model.Entities;
using GravityJumper.Model.Util;

namespace UnitTests.Model.Blocks
{
    [ExcludeFromCodeCoverage]
    [TestClass]
    public class SpeertrapTest
    {
        [TestMethod]
        public void HitboxTest()
        {
            Player player = new Player(new Vector2(0, 0))
            {
                Direction = new Vector2(0, 0),
                Velocity = new Vector2(0, 0),
                Size = new Vector2(10, 10)
            };
            List<Block> blocks = new List<Block>();
            blocks.Add(new Speertrap(new Vector2(0, 0), new Vector2(ModelConstants.BlockSize, ModelConstants.BlockSize), BlockType.Speertrap));
            player.Move(new GameTime(TimeSpan.Zero, TimeSpan.FromMilliseconds(20)), blocks);
            Assert.AreEqual(player.EntityState, State.Dead);
        }
    }
}
