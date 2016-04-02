using System.Runtime.CompilerServices;
using PikachusPearls.Code.Utility;
using SFML.Graphics;
using SFML.Window;

namespace PikachusPearls.Code.GameStates
{
    class MainMenuState : IGameState
    {
        Sprite background;
        private Sprite entertext;
        private bool scaled;
        private bool oppositive = true;
        private double alpha;

        private Shader FadeShader;
        private RenderStates FadeShaderState;

        public MainMenuState()
        {
            background = new Sprite(AssetManager.getTexture(AssetManager.TextureName.MainMenuBackground));
            entertext = new Sprite(AssetManager.getTexture(AssetManager.TextureName.PressEnter))
            {
                Color = new Color(0, 0, 0, 0)
            };

            FadeShader = new Shader(null, "Shaders/FadeShader.frag");
            FadeShaderState = new RenderStates(FadeShader);
        }

        public GameState Update(GameTime gameTime)
        {
            FadeShaderState.Shader.SetParameter("time", (float)gameTime.TotalTime.TotalSeconds);
            if (Keyboard.IsKeyPressed(Keyboard.Key.Return))
            {
                return GameState.InGame;
            }

            return GameState.MainMenu;
        }

        public void Draw(RenderWindow win)
        {
            if (!scaled)
            {
                var x = win.GetView().Size.X/background.Texture.Size.X;
                var y = win.GetView().Size.Y/background.Texture.Size.Y;
                background.Scale = new Vector2f(x, y);
                scaled = !scaled;
            }

            win.Draw(background);

            entertext.Position = new Vector2f(win.GetView().Center.X - entertext.Texture.Size.X/2,
                win.GetView().Center.Y - entertext.Texture.Size.Y/2);
            win.Draw(entertext, FadeShaderState);
        }

        public void DrawGUI(GUI gui)
        {
            //gui.Draw(entertext);
        }
    }
}
