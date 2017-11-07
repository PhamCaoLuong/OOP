using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace JumperJumper
{
    class TitleScreenGameState : IGameState
    {
        Game1 game;
        int logoTimer = 270;
        bool setLogo = false;
        SpriteFactory factory;
        IAnimatedSprite logo;
        public GUI menu;

        public TitleScreenGameState()
        {
            factory = new SpriteFactory();
            logo = factory.build(SpriteFactory.sprites.title);
            //SoundManager.PlaySong(SoundManager.songs.title);
            game = Game1.GetInstance();
            menu = new GUI(game);
            menu.options.Add(new KeyValuePair<ICommands, String>(new LoadLevelCommand(StringHolder.levelOne), "Level 1"));
            menu.options.Add(new KeyValuePair<ICommands, String>(new LoadLevelCommand(StringHolder.levelTwo), "Level 2"));
            menu.options.Add(new KeyValuePair<ICommands, String>(new LoadLevelCommand(StringHolder.levelThree), "Level 3"));
            menu.options.Add(new KeyValuePair<ICommands, String>(new LoadAchPageCommand(), "Achievements"));
            menu.options.Add(new KeyValuePair<ICommands, String>(new QuitCommand(), "Quit"));
            menu.currentCommand = menu.options[0].Key;
            game.keyboardController = new TitleKeyController(menu);
        }

        public void Update(GameTime gameTime)
        {
            game.level.Update(gameTime);
            logoTimer--;
            if (logoTimer <= 0)
            {
                setLogo = true;
                logo.Update(gameTime);
            }
            game.keyboardController.Update();
            menu.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            game.level.Draw(spriteBatch);
            if (setLogo)
            {
                logo.Draw(spriteBatch, new Vector2(100, 280), Color.White);
            }
            menu.Draw(spriteBatch);
        }
    }
}
