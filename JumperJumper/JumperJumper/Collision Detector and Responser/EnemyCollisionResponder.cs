﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace JumperJumper
{
    public class EnemyCollisionResponder
    {
        Random random;
        Game1 game;
        int bounce = 10;

        public EnemyCollisionResponder(Game1 game)
        {
            random = new Random();
            this.game = game;
        }

        public void TenoEnemyCollide(Teno teno, Enemy enemy)
        {
            Rectangle tenoRect = teno.state.GetBoundingBox(teno.position);
            Rectangle eneRect = enemy.state.GetBoundingBox(enemy.position);
            Rectangle intersection = Rectangle.Intersect(tenoRect, eneRect);

            if(intersection != null)
            {
                teno.MakeDeadTeno();
            }
        }

        public void EnemyEnemyCollide(Enemy enemy1, Enemy enemy2)
        {
            Rectangle ene1Rect = enemy1.state.GetBoundingBox(enemy1.position);
            Rectangle ene2Rect = enemy2.state.GetBoundingBox(enemy2.position);
            Rectangle intersection = Rectangle.Intersect(ene1Rect, ene2Rect);

            if(intersection != null)
            {
                if(enemy1.GetType().Equals(new LeftSXTKState().GetType()) || enemy1.GetType().Equals(new RightSXTKState().GetType()))
                    enemy1.position.Y += random.Next(-2, 2);
                enemy1.position.X += random.Next(-2, 2);
                if (enemy2.GetType().Equals(new RightSXTKState().GetType())|| enemy2.GetType().Equals(new RightSXTKState().GetType()))
                    enemy2.position.Y += random.Next(-2, 2);
                enemy2.position.X += random.Next(-2, 2);
            }
        }
    }
}
