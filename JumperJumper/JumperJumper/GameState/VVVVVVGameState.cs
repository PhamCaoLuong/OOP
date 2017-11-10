using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JumperJumper
{
    public class VVVVVVGameState : IGameState
    {
        Game1 game;

        public VVVVVVGameState(Game1 game)
        {
            this.game = game;
            game.level.teno.physState = new VVVVVVGroundState(game.level.teno, 1, game);
            game.keyboardController = new VVVVVVKeyController(game.level.teno, game);
            game.background.CurrentSprite = new NullSprite();
            game.gameHUD.PausedCheck = false;
            game.gameHUD.gameEnded = false;
            game.isVVVVVV = true;
            game.isTitle = false;
        }
        public void Update(GameTime gameTime)
        {
            game.keyboardController.Update();
            game.level.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            game.level.Draw(spriteBatch);
        }
    }
}
