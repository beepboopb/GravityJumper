// <copyright file="Level.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using GravityJumper.Model.Blocks;
using GravityJumper.Model.Entities;
using GravityJumper.Model.Interfaces;
using GravityJumper.Model.Util;
using Microsoft.Xna.Framework;

namespace GravityJumper.Model
{
    /// <summary>
    /// Level.
    /// </summary>
    public class Level
    {
        private List<Block> blocks;
        private List<Entity> entities;
        private Entity player;
        private Vector2 playerSpawn;
        private Vector2 size;
        private string levelname;

        public Level(string level)
        {
            this.blocks = new List<Block>();
            this.entities = new List<Entity>();

            this.LoadLevel(level);
            this.player = new Player(this.playerSpawn);
        }

        public Entity GetPlayer()
        {
            return this.player;
        }

        public Vector2 GetPlayerSpawn()
        {
            return this.playerSpawn;
        }

        /// <summary>
        /// Gets Blocks.
        /// </summary>
        /// <returns>List of Blocks.</returns>
        public List<Block> GetBlocks()
        {
            return this.blocks;
        }

        public List<Entity> GetEntities()
        {
            return this.entities;
        }

        public string GetLevelname()
        {
            return this.levelname;
        }

        // Make hitbox of despawn blocks 0 and change alls switch states on.
        public void DespawnBlock()
        {
            foreach (Block b in this.blocks.ToArray())
            {
                if (b.Type == BlockType.Despawn)
                {
                    b.Hitbox = new Rectangle((int)b.Position.X, (int)b.Position.Y, 0, 0);
                }
                else if (b.Type == BlockType.Switch)
                {
                    b.SwitchState = true;
                }
            }
        }

        // Make despawn blocks appear again, reset their Hitbox and turn every switch off.
        public void SpawnBlock()
        {
            foreach (Block b in this.blocks.ToArray())
            {
                if (b.Type == BlockType.Despawn)
                {
                    b.Hitbox = new Rectangle((int)b.Position.X, (int)b.Position.Y, ModelConstants.BlockSize, ModelConstants.BlockSize);
                }
                else if (b.Type == BlockType.Switch)
                {
                    b.SwitchState = false;
                }
            }
        }

        /// <summary>
        /// Lädt das Level aus einer Textdatei.
        /// # ist ein Stein.
        /// </summary>
        /// <param name="name">Pfad zum Level.</param>
        private void LoadLevel(string name)
        {
            this.levelname = name;
            string line;
            int i = 0, j = 0, k = 0;
            this.blocks.Clear();
            string path = System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            System.IO.StreamReader file = new System.IO.StreamReader(Path.Combine(path, "..", "..", "..", "Content", "Level", name + ".txt"));
            while ((line = file.ReadLine()) != null)
            {
                if (k < 2)
                {
                    k++;
                    continue;
                }

                foreach (char c in line.ToCharArray())
                {
                    System.Console.WriteLine(line);

                    if (c == '/')
                    {
                        continue;
                    }

                    // Kein Block
                    if (c == ' ')
                    {
                    }

                    // Stone
                    else if (c == 'G')
                    {
                        this.blocks.Add(new Stone(new Vector2(i * ModelConstants.BlockSize, j * ModelConstants.BlockSize), new Vector2(ModelConstants.BlockSize, ModelConstants.BlockSize), BlockType.Stone));
                    }
                    else if (c == '#')
                    {
                        this.blocks.Add(new Stone(new Vector2(i * ModelConstants.BlockSize, j * ModelConstants.BlockSize), new Vector2(ModelConstants.BlockSize, ModelConstants.BlockSize), BlockType.Background));
                    }
                    else if (c == 'W')
                    {
                        this.blocks.Add(new Stone(new Vector2(i * ModelConstants.BlockSize, j * ModelConstants.BlockSize), new Vector2(ModelConstants.BlockSize, ModelConstants.BlockSize), BlockType.Pillar));
                    }
                    else if (c == 'T')
                    {
                        this.blocks.Add(new Speertrap(new Vector2(i * ModelConstants.BlockSize, j * ModelConstants.BlockSize), new Vector2(ModelConstants.BlockSize, ModelConstants.BlockSize), BlockType.Speertrap, BlockDirection.Downwards));
                    }
                    else if (c == 'P')
                    {
                        this.playerSpawn = new Vector2(i * ModelConstants.BlockSize, (j * ModelConstants.BlockSize) - (ModelConstants.PlayerHeight - ModelConstants.BlockSize));
                        this.blocks.Add(new SpawnPoint(new Vector2(i * ModelConstants.BlockSize, j * ModelConstants.BlockSize), new Vector2(ModelConstants.BlockSize, ModelConstants.BlockSize), BlockType.Spawnpoint));
                    }
                    else if (c == 'E')
                    {
                        this.entities.Add(new Enemy1(new Vector2(i * ModelConstants.BlockSize, j * ModelConstants.BlockSize)));
                    }
                    else if (c == 'B')
                    {
                        this.blocks.Add(new EnemyBarrier(new Vector2(i * ModelConstants.BlockSize, j * ModelConstants.BlockSize), new Vector2(ModelConstants.BlockSize, ModelConstants.BlockSize), BlockType.EnemyBarrier));
                    }
                    else if (c == '1')
                    {
                        this.blocks.Add(new Speertrap(new Vector2(i * ModelConstants.BlockSize, j * ModelConstants.BlockSize), new Vector2(ModelConstants.BlockSize, ModelConstants.BlockSize), BlockType.Speertrap));
                    }
                    else if (c == 'U')
                    {
                        this.blocks.Add(new GravChange(new Vector2(i * ModelConstants.BlockSize, j * ModelConstants.BlockSize), new Vector2(ModelConstants.BlockSize, ModelConstants.BlockSize), BlockType.GravChange));
                    }
                    else if (c == 'L')
                    {
                        this.blocks.Add(new GravChange(new Vector2(i * ModelConstants.BlockSize, j * ModelConstants.BlockSize), new Vector2(ModelConstants.BlockSize, ModelConstants.BlockSize), BlockType.GravChange, BlockDirection.Left));
                    }
                    else if (c == 'R')
                    {
                        this.blocks.Add(new GravChange(new Vector2(i * ModelConstants.BlockSize, j * ModelConstants.BlockSize), new Vector2(ModelConstants.BlockSize, ModelConstants.BlockSize), BlockType.GravChange, BlockDirection.Right));
                    }
                    else if (c == 'D')
                    {
                        this.blocks.Add(new GravChange(new Vector2(i * ModelConstants.BlockSize, j * ModelConstants.BlockSize), new Vector2(ModelConstants.BlockSize, ModelConstants.BlockSize), BlockType.GravChange, BlockDirection.Downwards));
                    }
                    else if (c == 'Z')
                    {
                        this.blocks.Add(new Goal(new Vector2(i * ModelConstants.BlockSize, j * ModelConstants.BlockSize), new Vector2(ModelConstants.BlockSize, ModelConstants.BlockSize), BlockType.Goal));
                    }
                    else if (c == 'S')
                    {
                        this.blocks.Add(new Switch(new Vector2(i * ModelConstants.BlockSize, j * ModelConstants.BlockSize), new Vector2(ModelConstants.BlockSize, ModelConstants.BlockSize), BlockType.Switch));
                    }
                    else if (c == 'M')
                    {
                        this.blocks.Add(new Despawn(new Vector2(i * ModelConstants.BlockSize, j * ModelConstants.BlockSize), new Vector2(ModelConstants.BlockSize, ModelConstants.BlockSize), BlockType.Despawn));
                    }

                    i++;
                }

                if (this.size.X < i * ModelConstants.BlockSize)
                {
                    this.size = new Vector2(i * ModelConstants.BlockSize, this.size.Y);
                }

                i = 0;
                j++;
            }

            this.size = new Vector2(this.size.X, j * ModelConstants.BlockSize);

            file.Close();
        }
    }
}
