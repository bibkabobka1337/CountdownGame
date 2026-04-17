using Microsoft.Xna.Framework;

namespace CountdownGame.Models
{
    public class Enemy
    {
        public Vector2 Position { get; set; }
        public int Health { get; set; }
        public bool IsAggro { get; set; }
        public const float Speed = 110f;

        public Enemy(Vector2 pos)
        {
            Position = pos;
            Health = 3;
            IsAggro = false;
        }

        public Rectangle GetBounds()
        {
            return new Rectangle((int)Position.X - 11, (int)Position.Y - 11, 22, 22);
        }

        public void TakeDamage(int damage = 1)
        {
            Health -= damage;
        }

        public bool IsAlive() => Health > 0;
    }
}