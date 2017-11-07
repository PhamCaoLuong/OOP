using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace JumperJumper
{
    public class HouseCollisionResponder
    {
        Game1 game;

        public HouseCollisionResponder(Game1 game)
        {
            this.game = game;
        }

        public void TenoHouseCollide(Teno teno, House house, List<House> standingHouse)
        {
            Rectangle tenoRect = teno.state.GetBoundingBox(teno.position);
            Rectangle houseRect = house.state.GetBoundingBox(house.position);
            Rectangle intersection = Rectangle.Intersect(tenoRect, houseRect);

            if (intersection.Height > intersection.Width)
            {
                if (tenoRect.Right > houseRect.Left && tenoRect.Right < houseRect.Right)
                {
                    teno.position.X -= intersection.Width;
                }
                else
                {
                    teno.position.X += intersection.Width;
                }
            }
            else if (intersection.Height < intersection.Width)
            {
                if (tenoRect.Bottom > houseRect.Top && tenoRect.Bottom < houseRect.Bottom)
                {
                    if (!teno.isJumping)
                    {
                        teno.velocity.Y = 0;
                    }
                    if (intersection.Height > 1)
                    {
                        teno.position.Y -= intersection.Height;
                    }
                    standingHouse.Add(house);
                }
            }
        }
        public void HouseItemCollide(ICollectable item, House house)
        {
            Rectangle itemRect = item.GetBoundingBox();
            Rectangle houseRect = house.GetBoundingBox(house.position);
            Rectangle intersection = Rectangle.Intersect(itemRect, houseRect);
            if (intersection.Height > intersection.Width)
            {
                if (itemRect.Right > houseRect.Left && itemRect.Right < houseRect.Right)
                {
                    item.position = new Vector2(item.position.X - intersection.Width, item.position.Y);
                    item.GoLeft();
                }
                else
                {
                    item.position = new Vector2(item.position.X + intersection.Width, item.position.Y);
                    item.GoRight();
                }
            }
            else
            {
                if (itemRect.Bottom > houseRect.Top && itemRect.Bottom < houseRect.Bottom)
                {
                    item.position = new Vector2(item.position.X, item.position.Y - intersection.Height);
                }
                else
                {
                    item.position = new Vector2(item.position.X, item.position.Y + intersection.Height);
                }
            }
        }

        public void HouseEnemyCollide(Enemy enemy, House house)
        {
            Rectangle enemyRect = enemy.state.GetBoundingBox(enemy.position);
            Rectangle pipeRect = house.GetBoundingBox(house.position);
            Rectangle intersection = Rectangle.Intersect(enemyRect, pipeRect);
            if (intersection.Height > intersection.Width)
            {
                if (enemyRect.Right > pipeRect.Left && enemyRect.Right < pipeRect.Right)
                {
                    enemy.position.X = enemy.position.X - intersection.Width;
                    enemy.GoLeft();
                }
                else
                {
                    enemy.position.X = enemy.position.X + intersection.Width;
                    enemy.GoRight();
                }
            }
            else
            {
                if (enemyRect.Bottom > pipeRect.Top && enemyRect.Bottom < pipeRect.Bottom)
                {
                    enemy.position.Y = enemy.position.Y - intersection.Height;
                }
                else
                {
                    enemy.position.Y = enemy.position.Y + intersection.Height;
                }
            }
        }
    }
}
