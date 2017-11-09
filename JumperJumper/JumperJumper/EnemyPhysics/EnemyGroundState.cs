using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JumperJumper
{
    public class EnemyGroundState : IEnemyPhysicsState
    {
        private Vector2 oldPos;
        private float positionDifference = .5f;

        public EnemyGroundState(Enemy enemy)
        {
            enemy.velocity = new Vector2(enemy.velocity.X, 0);
            oldPos = enemy.position;
        }
        public void Update(Enemy enemy, GameTime gameTime)
        {
            if ((enemy.position.Y - oldPos.Y) > positionDifference)
            {
                enemy.physState = new EnemyFallingState(enemy);
            }
            oldPos = enemy.position;
        }
    }
}
