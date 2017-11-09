using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JumperJumper
{
    public class LoadLevelCommand : ICommands
    {
        Game1 game;
        String levelName;
        public LoadLevelCommand(String levelName, Game1 game)

        {
            this.game = game;
            this.levelName = levelName;
        }
        public void Execute()
        {
            game.level = new Level(game, levelName);
            if (levelName == StringHolder.levelOne)
            {
                game.gameState = new TenoGameState();
                SoundManager.PlaySong(SoundManager.songs.overworld);
            }
            if (levelName == StringHolder.levelTwo)
            {
                game.gameState = new VVVVVVGameState(game);
                SoundManager.PlaySong(SoundManager.songs.vmusic);
            }
            game.isTitle = false;
        }
    }
}
