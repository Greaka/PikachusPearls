using System;
using PikachusPearls.Code.Utility;
using SFML.Graphics;
using SFML.Window;

namespace PikachusPearls.Code.GameStates.IngameElements
{
    enum Direction
    {
        none,
        left,
        right,
        up,
        down
    }

    public class Player
    {
        AnimatedSprite playerSprite;
        Texture playerTex;
        Pearlmon[] Pearlmons;
        private bool inAnimation;
        private Direction moveDirection = Direction.none;

        public Player(Vector2f position)
        {
            playerSprite = new AnimatedSprite(AssetManager.getTexture(AssetManager.TextureName.PlayerSpriteSheet), 0.2f, 3, new Vector2i(64, 96))
            {
                Position = new Vector2(154, 79) * 64
            };
            playerSprite.stopAnimation();
        }

        public Pearlmon GetFirstMon()
        {
            return Pearlmons[0];
        }

        public void Update(GameTime gameTime)
        {
            if (!inAnimation)
            {
                DetermineDirection();
            }
            else
            {
                playerSprite.updateFrame(gameTime);
            }
        }

        private void DetermineDirection()
        {
            inAnimation = true;
            Direction direction = Direction.none;
            var up = false;
            var down = false;
            var left = false;
            var right = false;
            if (Keyboard.IsKeyPressed(Keyboard.Key.Up))
            {
                up = true;
                direction = Direction.up;
            }
            if (Keyboard.IsKeyPressed(Keyboard.Key.Down))
            {
                down = true;
                direction = Direction.down;
            }
            if (Keyboard.IsKeyPressed(Keyboard.Key.Left))
            {
                left = true;
                direction = Direction.left;
            }
            if (Keyboard.IsKeyPressed(Keyboard.Key.Right))
            {
                right = true;
                direction = Direction.right;
            }

            switch (moveDirection)
            {
                case Direction.up:
                    if (up) return;
                    break;
                case Direction.down:
                    if (down) return;
                    break;
                case Direction.left:
                    if (left) return;
                    break;
                case Direction.right:
                    if (right) return;
                    break;
            }

            moveDirection = direction;
            if (moveDirection == Direction.none)
                inAnimation = false;
        }

        public void Draw(RenderWindow win)
        {
            win.Draw(playerSprite);
            win.GetView().Center = playerSprite.Position;
        }
    }
}
