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
        readonly Vector2 posOffset = new Vector2(0, -32f);
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
                Vector2 vector = Vector2.Zero;
                switch (moveDirection)
                {
                    case Direction.down:
                        playerSprite.upperLeftCorner = new Vector2i(0, 0);
                        vector = Vector2.Down;
                        break;
                    case Direction.up:
                        playerSprite.upperLeftCorner = new Vector2i(0, 96);
                        vector = Vector2.Up;
                        break;
                    case Direction.left:
                        playerSprite.upperLeftCorner = new Vector2i(0, 288);
                        vector = Vector2.Left;
                        break;
                    case Direction.right:
                        playerSprite.upperLeftCorner = new Vector2i(0, 192);
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

                if (Math.Abs((((Vector2) playerSprite.Position - posOffset) - (((Vector2) actualTile + vector) * 64)).length) <= 1f)
                {
                    actualTile = actualTile + (Vector2i) vector;
                    playerSprite.Position = (Vector2) actualTile * 64 + posOffset;
                    inAnimation = false;
                }
            }
        }

        private void DetermineDirection()
        {
            Direction direction = Direction.none;
            var up = false;
            var down = false;
            var left = false;
            var right = false;
            var animation = playerSprite.upperLeftCorner;
            if (Keyboard.IsKeyPressed(Keyboard.Key.Up))
            {
                if (map.IsWalkable(actualTile + (Vector2i) Vector2.Up))
                {
                    up = true;
                    direction = Direction.up;
                }
                animation = new Vector2i(0, 96);
            }
            if (Keyboard.IsKeyPressed(Keyboard.Key.Down))
            {
                if (map.IsWalkable(actualTile + (Vector2i)Vector2.Down))
                {
                    down = true;
                    direction = Direction.down;
                }
                animation = new Vector2i(0, 0);
            }
            if (Keyboard.IsKeyPressed(Keyboard.Key.Left))
            {
                if (map.IsWalkable(actualTile + (Vector2i)Vector2.Left))
                {
                    left = true;
                    direction = Direction.left;
                }
                animation = new Vector2i(0, 288);
            }
            if (Keyboard.IsKeyPressed(Keyboard.Key.Right))
            {
                if (map.IsWalkable(actualTile + (Vector2i)Vector2.Right))
                {
                    right = true;
                    direction = Direction.right;
                }
                animation = new Vector2i(0, 192);
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

            playerSprite.upperLeftCorner = animation;
            moveDirection = direction;
        }

        public Sprite Draw(RenderWindow win)
        {
            View v = win.GetView();
            v.Center = playerSprite.Position - (Vector2f)posOffset;
            Vector2i centertile = (Vector2) v.Center/64;
            var x = win.Size.X/64/2;
            var y = win.Size.Y/64/2;
            if (centertile.X < x)
                v.Center = new Vector2f(x * 64, v.Center.Y);
            if (centertile.Y < y + 1)
                v.Center = new Vector2f(v.Center.X, (y + 1) * 64);
            if (centertile.X > 256-x - 2)
                v.Center = new Vector2f((256 - x - 1) * 64, v.Center.Y);
            if (centertile.Y > 256-y - 3)
                v.Center = new Vector2f(v.Center.X, (256 - y - 2) * 64);
            win.SetView(v);
            return playerSprite;
        }
    }
}
