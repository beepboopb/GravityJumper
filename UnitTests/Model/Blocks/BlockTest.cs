using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Xna.Framework;
using System.Diagnostics.CodeAnalysis;
using GravityJumper.Model.Blocks;
using GravityJumper.Model.Entities;
using GravityJumper.Model.Util;
using GravityJumper.Model.Interfaces;
using System.Collections.Generic;

namespace UnitTests.Model.Blocks
{
    [ExcludeFromCodeCoverage]
    [TestClass]
    public class BlockTest 
    {
        [TestMethod]
        public void CollideTest()
        {
            Player player = new Player(new Vector2(0, 0))
            {
                Direction = new Vector2(0, 0),
                Velocity = new Vector2(0, 0),
                Size = new Vector2(10, 10)
            };
            Block Stone = new Stone(new Vector2(0, 0), new Vector2(ModelConstants.BlockSize, ModelConstants.BlockSize), BlockType.Stone);
            bool test = Stone.CollideWith(player.Position, player.Size, true);
            Assert.AreEqual(test, true);

            Block Stone2 = new Stone(new Vector2(500, 500), new Vector2(ModelConstants.BlockSize, ModelConstants.BlockSize), BlockType.Stone);
            bool test2 = Stone2.CollideWith(player.Position, player.Size, true);
            Assert.AreNotEqual(test2, true);

            player.Position = new Vector2(500, 500);
            bool testIntersect = Stone2.CollideWith(player.Position, player.Size, true);
            Assert.AreEqual(testIntersect, true);
        }

        [TestMethod]
        public void IsAboveTest()
        {
            Player player = new Player(new Vector2(0, 0))
            {
                Direction = new Vector2(1, 0),
                Velocity = new Vector2(5, 0),
                Size = new Vector2(10, 10)
            };
            //Player über Stone
            Block Stone = new Stone(new Vector2(0, - 100), new Vector2(ModelConstants.BlockSize, ModelConstants.BlockSize), BlockType.Stone);
            bool test = Stone.IsAbove(player.Position, player.Size);
            Assert.AreEqual(test, true);
            //Player unter Stone
            player.Position = new Vector2(0 ,- 101);
            bool test2 = Stone.IsAbove(player.Position, player.Size);
            Assert.AreEqual(test2, false);
        }

        [TestMethod]
        public void IsBelowTest()
        {
            Player player = new Player(new Vector2(0, 0))
            {
                Direction = new Vector2(1, 0),
                Velocity = new Vector2(5, 0),
                Size = new Vector2(10, 10)
            };
            //Player unter Stone
            Block Stone = new Stone(new Vector2(0, 100), new Vector2(ModelConstants.BlockSize, ModelConstants.BlockSize), BlockType.Stone);
            bool test = Stone.IsBelow(player.Position, player.Size);
            Assert.AreEqual(test, true);
            //Player über Stone
            player.Position = new Vector2(0, 101);
            bool test2 = Stone.IsBelow(player.Position, player.Size);
            Assert.AreEqual(test2, false);
        }

        [TestMethod]
        public void IsLeftTest()
        {
            Player player = new Player(new Vector2(0, 0))
            {
                Direction = new Vector2(0, 0),
                Velocity = new Vector2(0, 0),
                Size = new Vector2(10, 10)
            };
            //Player links von Stone
            Block Stone = new Stone(new Vector2(- ModelConstants.BlockSize - player.Size.X,0), new Vector2(ModelConstants.BlockSize, ModelConstants.BlockSize), BlockType.Stone);
            bool test = Stone.IsLeftOf(player.Position, player.Size);
            Assert.AreEqual(test, true);
            //Player rechts von Stone
            player.Position = new Vector2(Stone.Position.X, 0);
            bool test2 = Stone.IsLeftOf(player.Position, player.Size);
            Assert.AreEqual(test2, false);
        }

        [TestMethod]
        public void IsRightTest()
        {
            Player player = new Player(new Vector2(0, 0))
            {
                Direction = new Vector2(0, 0),
                Velocity = new Vector2(0, 0),
                Size = new Vector2(10, 10)
            };
            //Player rechts von Stone
            Block Stone = new Stone(new Vector2( player.Size.X + ModelConstants.BlockSize, 0), new Vector2(ModelConstants.BlockSize, ModelConstants.BlockSize), BlockType.Stone);
            bool test = Stone.IsRightOf(player.Position, player.Size);
            Assert.AreEqual(test, true);
            //Player links von Stone
            player.Position = new Vector2(Stone.Position.X,0);
            bool test2 = Stone.IsRightOf(player.Position, player.Size);
            Assert.AreEqual(test2, false);
        }
    }
}