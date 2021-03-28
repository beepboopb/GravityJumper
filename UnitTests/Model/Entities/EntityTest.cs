using GravityJumper.Model;
using GravityJumper.Model.Entities;
using GravityJumper.Model.Util;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using GravityJumper.Model.Blocks;

namespace UnitTests.Model.Entities
{
    [ExcludeFromCodeCoverage]
    [TestClass]
    public class EntityTest
    {
        [TestMethod]
        public void MoveTest()
        {
            Player player = new Player(new Vector2(0, 0))
            {
                Direction = new Vector2(1, 0),
                Velocity = new Vector2(5, 0),
                Size = new Vector2(10, 10)
        };
            List<Block>blocks = new List<Block>();
            blocks.Add(new Stone(new Vector2( 200, - player.Size.Y), new Vector2(ModelConstants.BlockSize * 2000, ModelConstants.BlockSize), BlockType.Stone));
            Assert.AreEqual(0, player.Position.X);
            player.Move(new GameTime(TimeSpan.Zero, TimeSpan.FromMilliseconds(20)), blocks);
            Assert.AreNotEqual(0, player.Position.X);

        }
        [TestMethod]
        public void AccelerationTest()
        {
            Entity entity1 = new Player(new Vector2(100,100));
        }
    }
}
