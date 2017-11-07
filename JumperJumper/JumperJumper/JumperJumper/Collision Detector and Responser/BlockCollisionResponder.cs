using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
namespace JumperJumper
{
    public class BlockCollisionResponder
    {
        Game1 game;

        public BlockCollisionResponder(Game1 game)
        {
            this.game = game;
        }

        public void TenoBlockCollide(Teno teno, Block block, List<Block> detroyedBlocks, List<Block> standingBlock)
        {
            Rectangle tenoRect = teno.state.GetBoundingBox(teno.position);
            Rectangle blockRect = block.GetBoundingBox();
            Rectangle intersection = Rectangle.Intersect(tenoRect, blockRect);

            if(intersection.Height > intersection.Width)
            {
                if(tenoRect.Right > blockRect.Left && tenoRect.Right < blockRect.Right)
                {
                    teno.position.X -= intersection.Width;
                }
                else
                {
                    teno.position.X += intersection.Width;
                }
            }
            else if(intersection.Height < intersection.Width)
            {
                if(tenoRect.Bottom > blockRect.Top && tenoRect.Bottom < blockRect.Bottom)
                {
                    if(!teno.isJumping)
                    {
                        teno.velocity.Y = 0;
                    }
                    if(intersection.Height > 1)
                    {
                        teno.position.Y -= intersection.Height;
                    }
                    standingBlock.Add(block);
                }
                else
                {
                    teno.position.Y += intersection.Height;
                    if (!game.isVVVVVV)
                    {
                        block.Reaction();
                        teno.physState = new FallingState(teno);
                        teno.tenoHight = 0;
                        /*if (block.state.GetType().Equals(new BrickBlockState().GetType()) && mario.isBig)
                        {
                            block.Explode();
                        }*/
                    }
                    else
                        standingBlock.Add(block);
                }
            }
        }
        public void EnemyBlockCollide(Enemy enemy, Block block)
        {
            Rectangle eneRect = enemy.state.GetBoundingBox(enemy.position);
            Rectangle blockRect = block.GetBoundingBox();
            Rectangle intersection = Rectangle.Intersect(eneRect, blockRect);

            if(intersection.Height > intersection.Width)
            {
                if(eneRect.Right > blockRect.Left && eneRect.Right < blockRect.Right)
                {
                    enemy.position.X -= intersection.Width;
                    enemy.GoLeft();
                }
                else
                {
                    enemy.position.X += intersection.Width;
                    enemy.GoRight();
                }
            }
            else if(intersection.Height < intersection.Width)
            {
                if(eneRect.Bottom > blockRect.Top && eneRect.Bottom < blockRect.Bottom)
                {
                    enemy.veclocity.Y = 0;
                    if(intersection.Height > 1)
                    {
                        enemy.position.Y -= intersection.Height;
                    }
                }
                else
                {
                    enemy.position.Y += intersection.Height;
                }
            }

        }
    }
}
