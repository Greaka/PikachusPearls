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
        private Map map;
        AnimatedSprite playerSprite;
        Texture playerTex;
        Pearlmon[] Pearlmons;
        private bool _inAnimation;
        private GameTime temp;
        readonly Vector2 posOffset = new Vector2(-32f, -48f);
        private Vector2i actualTile;

        private bool inAnimation
        {
            get { return _inAnimation; }
            set
            {
                if (value)
                {
                    playerSprite.restartAnimation(temp);
                }
                else
                {
                    playerSprite.updateFrame(new GameTime());
                    playerSprite.stopAnimation();
                }
                _inAnimation = value;
            }
        }

        private Direction moveDirection = Direction.none;

        public Player(Map _map, Vector2f tilePosition)
        {
            actualTile = (Vector2) tilePosition;
            playerSprite = new AnimatedSprite(AssetManager.getTexture(AssetManager.TextureName.PlayerSpriteSheet), 0.2f, 3, new Vector2i(64, 96))
            {
                Position = tilePosition * 64 + (Vector2f) posOffset
            };
            inAnimation = false;
            map = _map;
        }

        public Pearlmon GetFirstMon()
        {
            return Pearlmons[0];
        }

        public void Update(GameTime gameTime)
        {
            temp = gameTime;
            if (!inAnimation)
            {
                DetermineDirection();
            }
            else
            {
                Vector2f vector = Vector2.Zero;
                switch (moveDirection)
                {
                    case Direction.down:
                        vector = Vector2.Down;
                        break;
                    case Direction.up:
                        vector = Vector2.Up;
                        break;
                    case Direction.left:
                        vector = Vector2.Left;
                        break;
                    case Direction.right:
                        vector = Vector2.Right;
                        break;
                    case Direction.none:
                        inAnimation = false;
                        break;
                }

                float speed = 64; //pixel per 300 milliseconds
                speed /= 300f;
                speed *= (float)gameTime.EllapsedTime.TotalMilliseconds;

                playerSprite.Position += (Vector2f) (vector * speed);
                playerSprite.updateFrame(gameTime);

                if ((((Vector2) playerSprite.Position - posOffset)/64) != actualTile)
                    inAnimation = false;
            }
        }

        private void DetermineDirection()
        {
            Direction direction = Direction.none;
            var up = false;
            var down = false;
            var left = false;
            var right = false;
            if (Keyboard.IsKeyPressed(Keyboard.Key.Up))
            {
                if (map.IsWalkable(actualTile + (Vector2i) Vector2.Up))
                {
                    up = true;
                    direction = Direction.up;
                }
                playerSprite.upperLeftCorner = new Vector2i(0, 96);
            }
            if (Keyboard.IsKeyPressed(Keyboard.Key.Down))
            {
                if (map.IsWalkable(actualTile + (Vector2i)Vector2.Down))
                {
                    down = true;
                    direction = Direction.down;
                }
                playerSprite.upperLeftCorner = new Vector2i(0, 0);
            }
            if (Keyboard.IsKeyPressed(Keyboard.Key.Left))
            {
                if (map.IsWalkable(actualTile + (Vector2i)Vector2.Left))
                {
                    left = true;
                    direction = Direction.left;
                }
                playerSprite.upperLeftCorner = new Vector2i(0, 288);
            }
            if (Keyboard.IsKeyPressed(Keyboard.Key.Right))
            {
                if (map.IsWalkable(actualTile + (Vector2i)Vector2.Up))
                {
                    right = true;
                    direction = Direction.right;
                }
                playerSprite.upperLeftCorner = new Vector2i(0, 192);
            }

            if (up || down || left || right)
                inAnimation = true;
            else
                inAnimation = false;

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
        }

        public Sprite Draw(RenderWindow win)
        {
            View v = win.GetView();
            v.Center = playerSprite.Position - (Vector2f) posOffset;
            win.SetView(v);
            return playerSprite;
        }
    }
}
