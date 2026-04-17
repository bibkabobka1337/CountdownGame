using Microsoft.Xna.Framework;
using System.Collections.Generic;
using CountdownGame.Models;

namespace CountdownGame.Controllers
{
    public class EnemyController
    {
        public void Update(float dt, Vector2 playerPos, List<Enemy> enemies, List<Rectangle> walls)
        {
            foreach (var enemy in enemies)
            {
                float dist = Vector2.Distance(enemy.Position, playerPos);
                if (dist < 320) enemy.IsAggro = true;

                if (enemy.IsAggro && dist > 15)
                {
                    var dir = playerPos - enemy.Position;
                    dir.Normalize();
                    Vector2 nextPos = enemy.Position + dir * Enemy.Speed * dt;

                    if (!WillCollide(nextPos, walls, playerPos))
                    {
                        enemy.Position = nextPos;
                    }
                }
            }
        }

        private bool WillCollide(Vector2 newPos, List<Rectangle> walls, Vector2 playerPos)
        {
            var rect = new Rectangle((int)newPos.X - 11, (int)newPos.Y - 11, 22, 22);

            foreach (var w in walls)
                if (rect.Intersects(w)) return true;

            var pRect = new Rectangle((int)playerPos.X - 14, (int)playerPos.Y - 14, 28, 28);
            return rect.Intersects(pRect);
        }
    }
}