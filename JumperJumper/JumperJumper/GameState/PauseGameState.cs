using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace JumperJumper
{
    public class PauseGameState : IGameState
    {
        int inputBuffer = 10;
        Game1 game;

        public PauseGameState(Game1 game)
        {
            this.game = game;
            game.isPaused = true;
            game.keyboardController = new PauseMenuKeyController();
            //SoundManager.pause.Play();
            game.gameHUD.PausedCheck = true;
        }

        public void Update(GameTime gameTime)
        {
            inputBuffer--;
            if (inputBuffer <= 0)
            {
                game.keyboardController.Update();
                inputBuffer = 10;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            game.level.Draw(spriteBatch);
        }
    }
}
