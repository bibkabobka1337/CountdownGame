using Microsoft.Xna.Framework;

namespace CountdownGame.Models
{
    public class Player
    {
        public Vector2 Position { get; set; }
        public bool IsAttacking { get; set; }
        public Rectangle AttackArea { get; set; }
        public int Health { get; set; } = 5;
        public const float Speed = 300f;
        
        public Player(Vector2 pos)
        {
            Position = pos;
            IsAttacking = false;
        }
        
        public Rectangle GetBounds()
        {
            return new Rectangle((int)Position.X - 13, (int)Position.Y - 13, 26, 26);
        }
        
        public void StartAttack()
        {
            IsAttacking = true;
            AttackArea = new Rectangle((int)Position.X - 55, (int)Position.Y - 55, 110, 110);
        }
    }
}