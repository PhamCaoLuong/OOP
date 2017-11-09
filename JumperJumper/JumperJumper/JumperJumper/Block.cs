using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace JumperJumper
{
    public class Block
    {
        public IBlockState state;
        public ICollectable prize;
        bool prizeSpawned = false;
        public Vector2 position = new Vector2(0, 0);
        int explosionTimer = 20;
        bool isExploding = false;
        Game1 game;
        public Block(Vector2 location, ICollectable prize, IBlockState state, Game1 game)
        {
            this.game = game;
            this.prize = prize;
            this.state = state;
            position = location;
        }

        public void Update(GameTime gameTime)
        {
            if (isExploding)
            {
                explosionTimer--;
            }
            if (explosionTimer < 0)
            {
                game.level.collision.destroyedBlocks.Add(this);
            }
            state.Update(gameTime, this);
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            state.Draw(spriteBatch, location);
        }
        public void Reaction()
        {
            state.Reaction(this);
            if (prize != null && !prizeSpawned)
            {
                prize.Spawn();
                prizeSpawned = true;
            }
        }
        public Rectangle GetBoundingBox()
        {
            return state.GetBoundingBox(position);
        }

        public void Explode()
        {
            state = new ExplodingBlockState();
            isExploding = true;
        }
    }
}
}
