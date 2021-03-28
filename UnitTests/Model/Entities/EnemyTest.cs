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
    public class EnemyTest
    {
        [TestMethod]
        public void CollisionTest()
        {
            Player player = new Player(new Vector2(100, 100))
            {
                Direction = new Vector2(1, 0),
                Velocity = new Vector2(5, 0),
                Size = new Vector2(ModelConstants.PlayerWidth, ModelConstants.PlayerHeight)
            };
            List<Block> blocks = new List<Block>();
            Enemy1 enemy = new Enemy1(new Vector2(100 +player.Size.X, 100));
            blocks.Add(new Stone(new Vector2(0,  100 + enemy.Size.Y), new Vector2(500, ModelConstants.BlockSize), BlockType.Stone));
            //Überprüfen ob player und enemy sich berühren
            bool test = enemy.CollideWith(player);
            Assert.AreEqual(test, false);
            //player bewegt sich in Richtung enemy
            player.Move(new GameTime(TimeSpan.Zero, TimeSpan.FromMilliseconds(50)), blocks);
            bool test2 = enemy.CollideWith(player);
            Assert.AreEqual(test2, true);
        }
    }
}
