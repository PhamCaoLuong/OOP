using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JumperJumper
{
    public class ResetSceneCommand : ICommands
    {
        Game1 game;
        public ResetSceneCommand()
        {
            this.game = Game1.GetInstance();
        }

        public void Execute()
        {
            Game1.GetInstance().level = new Level(game, StringHolder.levelOne);
            Game1.GetInstance().background.CurrentSprite = Game1.GetInstance().background.OverworldSprite;
            Game1.GetInstance().gameState = new TitleScreenGameState();
            Game1.GetInstance().isTitle = true;
            Game1.GetInstance().gameHUD.Coins = 0;
            Game1.GetInstance().gameHUD.Lives = ValueHolder.startingLives;
            Game1.GetInstance().gameHUD.Score = 0;
        }
    }
}
