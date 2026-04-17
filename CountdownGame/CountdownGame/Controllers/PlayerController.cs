using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using CountdownGame.Models;

namespace CountdownGame.Controllers
{
    public class PlayerController
    {
        private Player _player;
        private float _attackTimer;

        public PlayerController(Player player)
        {
            _player = player;
            _attackTimer = 0;
        }

        public void Update(GameTime gt, List<Enemy> enemies, List<Rectangle> walls)
        {
            float dt = (float)gt.ElapsedGameTime.TotalSeconds;
            HandleMovement(dt, walls, enemies);
            HandleAttack(dt, enemies);
        }

        private void HandleMovement(float dt, List<Rectangle> walls, List<Enemy> enemies)
        {
            var kb = Keyboard.GetState();
            var dir = Vector2.Zero;

            if (kb.IsKeyDown(Keys.W)) dir.Y -= 1;
            if (kb.IsKeyDown(Keys.S)) dir.Y += 1;
            if (kb.IsKeyDown(Keys.A)) dir.X -= 1;
            if (kb.IsKeyDown(Keys.D)) dir.X += 1;

            if (dir != Vector2.Zero)
            {
                dir.Normalize();
                MoveWithCollision(dir * Player.Speed * dt, walls, enemies);
            }
        }

        private void MoveWithCollision(Vector2 delta, List<Rectangle> walls, List<Enemy> enemies)
        {
            Vector2 newPos = _player.Position;

            if (!CheckCollision(new Vector2(_player.Position.X + delta.X, _player.Position.Y), walls, enemies))
                newPos.X += delta.X;

            if (!CheckCollision(new Vector2(newPos.X, _player.Position.Y + delta.Y), walls, enemies))
                newPos.Y += delta.Y;

            _player.Position = newPos;
        }

        private bool CheckCollision(Vector2 newPos, List<Rectangle> walls, List<Enemy> enemies)
        {
            var rect = new Rectangle((int)newPos.X - 13, (int)newPos.Y - 13, 26, 26);

            foreach (var w in walls)
                if (rect.Intersects(w)) return true;

            foreach (var e in enemies)
                if (rect.Intersects(e.GetBounds())) return true;

            return false;
        }

        private void HandleAttack(float dt, List<Enemy> enemies)
        {
            var kb = Keyboard.GetState();

            if (kb.IsKeyDown(Keys.Space) && !_player.IsAttacking)
            {
                _player.StartAttack();
                _attackTimer = 0.2f;

                for (int i = enemies.Count - 1; i >= 0; i--)
                {
                    if (_player.AttackArea.Intersects(enemies[i].GetBounds()))
                    {
                        enemies[i].TakeDamage();
                        if (!enemies[i].IsAlive())
                            enemies.RemoveAt(i);
                    }
                }
            }

            if (_player.IsAttacking)
            {
                _attackTimer -= dt;
                if (_attackTimer <= 0)
                    _player.IsAttacking = false;
            }
        }
    }
}