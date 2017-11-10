using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace JumperJumper
{
    public class TenoGameState : IGameState
    {
        int gameStateTransitionBuffer = 5;
        Game1 game;

        public TenoGameState(Game1 game)
        {
            this.game = game;
            game.keyboardController = new KeyboardController(game.level.teno, game);
            game.gameHUD.PausedCheck = false;
            game.gameHUD.gameEnded = false;
            game.isVVVVVV = false;
            game.isVictory = false;
        }
        public void Update(GameTime gameTime)
        {
            game.gameHUD.Update(gameTime);
            if (gameStateTransitionBuffer > 0)
            {
                gameStateTransitionBuffer--;
            }
            else
            {
                game.keyboardController.Update();
                game.level.Update(gameTime);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            game.level.Draw(spriteBatch);
        }
    }
}
