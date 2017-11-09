using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JumperJumper
{
    public class ResetSceneCommand : ICommands
    {
        Game1 game;
        public ResetSceneCommand(Game1 game)
        {
            this.game = game;
        }

        public void Execute()
        {   
            game.level = new Level(game, StringHolder.levelOne);
            game.background.CurrentSprite = Game1.GetInstance().background.H1Sprite;
            game.gameState = new TitleScreenGameState(game);
            game.isTitle = true;
            game.gameHUD.Coins = 0;
            game.gameHUD.Lives = ValueHolder.startingLives;
            game.gameHUD.Score = 0;
        }
    }
}
