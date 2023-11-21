﻿using Raylib_CsLo;
using Spaceinvadersfinal;
using System.Numerics;
using Spaceinvadersfinal;

namespace Spaceinvadersfinal
{
    internal class Enemy
    {
        public bool isInvincible;

        public List<Bullet> bullets;
        private float bulletCooldown = 0;
        private float bulletCooldownMax = 12000;

        public Transform transform;

        public Vector2 position;
        public int health;

        public bool isAlive = true;

        private Texture texture;



        private List<Player> players;
        private float speed;
        private float size;

        public Enemy(Vector2 position, Vector2 direction, int health, string texturePath, List<Player> players)
        {
            isInvincible = false;
            this.position = position;
            this.health = health;

            this.bullets = new List<Bullet>();
            this.players = players;

            texture = Raylib.LoadTexture(texturePath);

            this.transform = new Transform(position, direction, speed, size);


            bulletCooldownMax = Raylib.GetRandomValue(5000, 15000);
        }

        public void Update(Player player, bool playerInvincible)
        {

            if (health <= 0)
            {
                isAlive = false;
                player.score += 10;
            }


            bulletCooldown -= Raylib.GetFrameTime() * 1000;

            if (bulletCooldown <= 0)
            {

                bullets.Add(new Bullet(new Vector2(position.X + 50, position.Y + 20), new Vector2(0, 1)));
                bulletCooldown = bulletCooldownMax;
            }


            foreach (Bullet bullet in bullets.ToList())
            {
                bullet.Update();
                if (playerInvincible)
                {

                    continue;
                }
                foreach (Player otherPlayer in players)
                {
                    if (Raylib.CheckCollisionCircles(bullet.position, 5, player.position, 20))
                    {

                        player.health -= 10;

                        bullets.Remove(bullet);
                        break;
                    }
                }
            }


            bullets.RemoveAll(bullet => bullet.position.Y < 0 || bullet.position.Y > Raylib.GetScreenHeight());
        }

        public void Draw()
        {
            Raylib.DrawTextureEx(texture, position, 0f, 0.1f, Raylib.WHITE);

            foreach (Bullet bullet in bullets)
                bullet.Draw();
        }
    }
}