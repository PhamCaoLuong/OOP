using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
namespace JumperJumper
{
    public class AchievementMenuGameState : IGameState
    {
        Game1 game;
        public GUI menu;
        int inputBuffer = 0;
        Texture2D level1;
        Texture2D level2;
        //Texture2D level3;

        public AchievementMenuGameState(Game1 game)
        {
            this.game = game;
            menu = new GUI(game);
            menu.options.Add(new KeyValuePair<ICommands, String>(new LoadMenuCommand(game), "Back"));
            menu.currentCommand = menu.options[0].Key;
            game.keyboardController = new TitleKeyController(menu, game);
            //level1 = Game1.gameContent.Load<Texture2D>("level1");
            //level2 = Game1.gameContent.Load<Texture2D>("level2");
            //level3 = Game1.gameContent.Load<Texture2D>("level3");
        }

        public void Update(GameTime gametime)
        {
            game.level.Update(gametime);
            inputBuffer++;
            if (inputBuffer > 6)
            {
                game.keyboardController.Update();
                inputBuffer = 0;
            }
            menu.Update();
            if (game.ach.achievementKeeper[AchievementsManager.AchievementType.Level1].isUnlocked)
            {
                level1 = game.ach.achievementKeeper[AchievementsManager.AchievementType.Level1].greyImage;
            }
            if (game.ach.achievementKeeper[AchievementsManager.AchievementType.Level2].isUnlocked)
            {
                level2 = game.ach.achievementKeeper[AchievementsManager.AchievementType.Level2].greyImage;
            }
            /*if (game.ach.achievementKeeper[AchievementsManager.AchievementType.level3].isUnlocked)
            {
                level3 = game.ach.achievementKeeper[AchievementsManager.AchievementType.level3].greyImage;
            }*/
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            game.level.Draw(spriteBatch);
            menu.Draw(spriteBatch);

            spriteBatch.Draw(level1, new Rectangle(84, 250, 75, 51), Color.White);
            spriteBatch.Draw(level2, new Rectangle(160, 250, 75, 51), Color.White);
            //spriteBatch.Draw(level3, new Rectangle(236, 250, 75, 51), Color.White);
        }

    }
}
