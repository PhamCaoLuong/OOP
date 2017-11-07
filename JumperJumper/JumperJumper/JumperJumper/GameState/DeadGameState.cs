using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace JumperJumper.GameState
{
    public class DeadGameState
    {
        Game1 game;
        Teno teno;
        int pauseTimer = 30, upTimer = 30, downTimer = 180;
        int positionChange = 5;

        public DeadGameState(Teno teno)
        {
            game = Game1.GetInstance();
            this.teno = teno;
            teno.isDead = true;
        }

        public void Update(GameTime gameTime)
        {
            if (pauseTimer > 0)
            {
                pauseTimer--;
            }
            if (pauseTimer <= 0 && upTimer > 0)
            {
                upTimer--;
                teno.position.Y -= positionChange;
            }
            if (upTimer <= 0 && downTimer > 0)
            {
                teno.position.Y += positionChange;
                downTimer--;
            }
            if (downTimer <= 0)
            {
                game.gameState = new GameOverState();
               
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            game.level.Draw(spriteBatch);
        }
    }
}
