using GravityJumper.Model;
using GravityJumper.Model.Blocks;
using GravityJumper.Model.Entities;
using GravityJumper.Model.Util;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace UnitTests.Model
{
    [ExcludeFromCodeCoverage]
    [TestClass]
    public class LevelTest
    {
        [TestMethod]
        public void LoadLevelName()
        {
            Level testlevel = new Level("Testlevel");
            String levelname = testlevel.GetLevelname();
            Assert.AreEqual("Testlevel", levelname);
        }

        [TestMethod]
        public void LoadPlayerPosition()
        {
            Level testlevel = new Level("Testlevel");
            Entity player = testlevel.GetPlayer();
            Vector2 testspawnpoint = testlevel.GetPlayerSpawn();
            Assert.AreEqual(new Vector2(player.Position.X, player.Position.Y), testspawnpoint);
        }

        [TestMethod]
        public void TestDespawnableBlocks()
        {
            Level testlevel = new Level("Testlevel");
            List<Block> testblocks = testlevel.GetBlocks();
            testlevel.DespawnBlock();
            foreach(Block block in testblocks)
            {
                if(block.Type == BlockType.Despawn)
                {
                    Assert.AreEqual(block.Hitbox, new Rectangle((int)block.Position.X, (int)block.Position.Y, 0, 0));
                }
            }
            testlevel.SpawnBlock();
            foreach (Block block in testblocks)
            {
                if (block.Type == BlockType.Despawn)
                {
                    Assert.AreEqual(block.Hitbox, new Rectangle((int)block.Position.X, (int)block.Position.Y, ModelConstants.BlockSize, ModelConstants.BlockSize));
                }
            }
        }
    }
}
