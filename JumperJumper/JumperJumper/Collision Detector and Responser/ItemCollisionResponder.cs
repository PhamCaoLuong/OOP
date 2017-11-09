using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JumperJumper
{
    public class ItemCollisionResponder
    {
        Game1 game;

        public ItemCollisionResponder(Game1 game)
        {
            this.game = game;
        }

        public void TenoItemCollide(Teno teno, ICollectable item)
        {
            if (item.GetType().Equals(new Coin(item.position).GetType()))
            {
                //SoundManager.coinCollect.Play();
                game.gameHUD.Coins++;
                game.gameHUD.Score += ValueHolder.coinCollectPoints;
            }
        }
    }
}
