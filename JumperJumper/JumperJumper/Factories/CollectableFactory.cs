using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace JumperJumper
{
    public class CollectableFactory
    {
        public enum CollectableType
        {
            coin, star, oneUp, fireFlower, superMushroom, ninja,
        }
        SpriteFactory factory;
        ICollectable product;
        Game1 game;

        public CollectableFactory(Game1 game)
        {
            this.game = game;
        }

        public ICollectable build(CollectableType type, Vector2 location)
        {
            factory = new SpriteFactory();
            /*if (type == CollectableType.coin)
            {
                product = new Coin(location);
            }*/
            if (type == CollectableType.star)
            {
                product = new Coin(location, game);
            }
            if (type == CollectableType.oneUp)
            {
                //product = new OneUpMushroom(location);
            }
            if (type == CollectableType.fireFlower)
            {
                //product = new FireFlower(location);
            }
            if (type == CollectableType.superMushroom)
            {
                //product = new SuperMushroom(location);
            }
            if (type == CollectableType.ninja)
            {
                //product = new Ninja(location);
            }

            return product;
        }
    }
}
