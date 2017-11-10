using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace JumperJumper
{
    class KeyboardController : IController
    {
        private KeyboardState keyboardState;
        Teno teno;
        ICommands currentCommand;
        Dictionary<Keys, ICommands> commandLibrabry;

        public  KeyboardController(Teno teno, Game1 game)
        {
            this.teno = teno;
            commandLibrabry = new Dictionary<Keys, ICommands>();
            commandLibrabry.Add(Keys.W, currentCommand = new UpCommand(teno));
            commandLibrabry.Add(Keys.LeftShift, currentCommand = new RunCommand(teno));
            commandLibrabry.Add(Keys.A, currentCommand = new LeftCommand(teno));
            commandLibrabry.Add(Keys.D, currentCommand = new RightCommand(teno));
            commandLibrabry.Add(Keys.S, currentCommand = new DownCommand(teno));
            commandLibrabry.Add(Keys.Escape, currentCommand = new QuitCommand(game));
            commandLibrabry.Add(Keys.Enter, currentCommand = new PauseCommand(game));
        }

        public void Update()
        {
            currentCommand = new NullCommand();
            keyboardState = Keyboard.GetState();
            foreach (Keys key in commandLibrabry.Keys)
            {
                currentCommand = commandLibrabry[key];
                currentCommand.Execute();
            }
            teno.Idle();
        }
    }
}
