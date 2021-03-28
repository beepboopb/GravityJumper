using GravityJumper.Model;
using GravityJumper.Model.Entities;
using GravityJumper.Model.Util;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using GravityJumper.Model.Blocks;


namespace UnitTests.Model
{
    [ExcludeFromCodeCoverage]
    [TestClass]
    public class CameraTest
    {
        [TestMethod]
        public void MoveCamTest()
        {
            Camera testcam = new Camera();
            Player player = new Player(new Vector2(500,0))
            {
                Direction = new Vector2(1, 0),
                Velocity = new Vector2(5, 0),
                Size = new Vector2(10, 10)
            };
            testcam.Follow(player);
            Matrix transform1 = testcam.Transform;
            List<Block> blocks = new List<Block>();
            blocks.Add(new Stone(new Vector2(0, 0), new Vector2(ModelConstants.BlockSize, ModelConstants.BlockSize), BlockType.Stone));
            //No blocks under Player-> Player should fall and therefore "move"
            player.Move(new GameTime(TimeSpan.Zero, TimeSpan.FromMilliseconds(20)), blocks);
            testcam.Follow(player);
            Matrix transform2 = testcam.Transform;
            Assert.AreNotEqual(transform2, transform1);
        }
    }
}