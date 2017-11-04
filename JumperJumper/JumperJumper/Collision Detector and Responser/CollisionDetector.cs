using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace JumperJumper
{
    public class CollisionDetector
    {
        Game1 game;
        ISpriteFactory factory = new SpriteFactory();
        public List<Block> detroyedBlock = new List<Block>();
        public List<Block> standingBlock = new List<Block>();
        public List<ICollectable> ontainedItems = new List<ICollectable>();
        public List<House> standingHouse = new List<House>();

        public BlockCollisionResponder blockResponser;
        public HouseCollisionResponder houseResponser;
        public EnemyCollisionResponder enemyResponser;
        public ItemCollisionResponder itemResponser;

        public CollisionDetector(Teno teno, Game1 game)
        {
            this.game = game;
            blockResponser = new BlockCollisionResponder(game);
            houseResponser = new HouseCollisionResponder(game);
            enemyResponser = new EnemyCollisionResponder(game);
            itemResponser = new ItemCollisionResponder(game);
        }

        public void Detect(Teno teno, List<Enemy> levelEnemies, List<Block> levelBlocks, List<House> levelHouses,
                            List<ICollectable> levelItems)
        {
            Rectangle tenoRect = teno.state.GetBoundingBox(teno.position);
            foreach (Enemy enemy in levelEnemies)
            {
                Rectangle eneRect = enemy.state.GetBoundingBox(enemy.position);
                if (!enemy.isDead)
                {
                    if (tenoRect.Intersects(eneRect))
                        enemyResponser.TenoEnemyCollide(teno, enemy);
                }

                foreach (Block block in levelBlocks)
                {
                    Rectangle blockRect = block.GetBoundingBox();
                    if (eneRect.Intersects(blockRect))
                        blockResponser.EnemyBlockCollide(enemy,block);
                }
                foreach (Enemy otherEnemy in levelEnemies)
                {
                    Rectangle otherEnemy = otherEnemy.state.GetBoundingBox(otherEnemy.position);
                    if (otherEnemy != enemy && otherEnemy.Intersects(eneRect))
                        enemyResponser.EnemyEnemyCollide(enemy, otherEnemy);
                }
                foreach (House house in levelHouses)
                {
                    Rectangle houseRect = house.state.GetBoundingBox(house.position);
                    if (houseRect.Intersects(eneRect))
                        houseResponser.HouseEnemyCollide(enemy, house);

                }

            }
            foreach (House house in levelHouses)
            {
                Rectangle houseRect = house.GetBoundingBox(house.position);
                if (houseRect.Intersects(tenoRect))
                    houseResponser.TenoHouseCollide(teno, house, standingHouse);
            }
            foreach (ICollectable item in levelItems)
            {
                Rectangle itemRect = item.GetBoundingBox();
                if (itemRect.Intersects(tenoRect) && !item.isSpawning)
                {
                    ontainedItems.Add(item);
                    itemResponser.TenoItemCollide(teno, item);
                }
            }

            foreach (Block block in levelBlocks)
            {
                Rectangle blockRect = block.GetBoundingBox();
                if (tenoRect.Intersects(blockRect))
                {
                    blockResponser.TenoBlockCollide(teno,block, detroyedBlock, standingBlock);
                }
            }
            foreach (ICollectable obtainedItem in ontainedItems)
            {
                levelItems.Remove(obtainedItem);
            }
            foreach (Block destroyedBlock in detroyedBlock)
            {
                levelBlocks.Remove(destroyedBlock);
            }
        }
    }
}
