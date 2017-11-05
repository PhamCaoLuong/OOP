using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace JumperJumper
{
    public class DeadFlipGameState
    {
        Game1 game;
        Teno teno;
        int timer = 20;

        public DeadFlipGameState(Teno teno)
        {
            game = Game1.GetInstance();
            this.teno = teno;
        }

        public void Update(GameTime gameTime)
        {
            timer--;
            if (timer <= 0)
            {
                teno.Respawn();
                game.gameState = new VVVVVVGameState();
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            game.level.Draw(spriteBatch);
        }
    }
}
