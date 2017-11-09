using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;

namespace JumperJumper
{
    public class TitleKeyController : IController
    {
        private KeyboardState keyboardState;

        Game1 game;
        ICommands currentCommand;
        Dictionary<Keys, ICommands> commandLibrary;

        public TitleKeyController(GUI menu, Game1 game)
        {
            this.game = game;
            commandLibrary = new Dictionary<Keys, ICommands>();
            commandLibrary.Add(Keys.Q, currentCommand = new QuitCommand(game));
            commandLibrary.Add(Keys.S, new MenuDownCommand(menu));
            commandLibrary.Add(Keys.W, new MenuUpCommand(menu));
            commandLibrary.Add(Keys.Enter, new MenuSelectCommand(menu));
        }

        public void Update()
        {
            currentCommand = new NullCommand();
            keyboardState = Keyboard.GetState();
            foreach (Keys key in keyboardState.GetPressedKeys())
            {
                if (commandLibrary.ContainsKey(key))
                {
                    currentCommand = commandLibrary[key];
                    currentCommand.Execute();
                }
            }
        }
    }
}
