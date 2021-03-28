// <copyright file="Program.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System;
using System.Diagnostics.CodeAnalysis;
using GravityJumper.Model;
using GravityJumper.View;

namespace GravityJumper.Controller
{
    [ExcludeFromCodeCoverage]
    public static class Program
    {
        [STAThread]
        public static void Main()
        {
            GameModel model = new GameModel();
            GameView view = new GameView(model);
            using (var game = new Controller(model, view))
            {
                game.Run();
            }
        }
    }
}
