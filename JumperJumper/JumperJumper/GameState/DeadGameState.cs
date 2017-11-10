using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace JumperJumper
{
    class DeadGameState : IGameState
    {
        Game1 game;
        Teno teno;
        int pauseTimer = 30, upTimer = 30, downTimer = 180;
        int positionChange = 5;

        public DeadGameState(Teno mario, Game1 game)
        {
            this.game = game;
            this.teno = mario;
            SoundManager.StopMusic();
            //SoundManager.death.Play();
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
                if (game.gameHUD.Lives > 0)
                {
                    game.gameState = new LivesScreenGameState(game);
                }
                else
                {
                    game.gameState = new GameOverState(game);
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            game.level.Draw(spriteBatch);
            game.gameHUD.Draw(spriteBatch);
        }
    }
}
