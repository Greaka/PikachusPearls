using SFML.Graphics;
using SFML.Window;

namespace PikachusPearls.Code.GameStates
{
    class MainMenuState : IGameState
    {
        Sprite background;

        public MainMenuState()
        {
            background = new Sprite(AssetManager.getTexture(AssetManager.TextureName.MainMenuBackground));
        }

        public GameState Update()
        {
            if (Keyboard.IsKeyPressed(Keyboard.Key.Return))
            {
                return GameState.InGame;
            }

            return GameState.MainMenu;
        }

        public void Draw(RenderWindow win)
        {
            //win.Draw(background);
        }

        public void DrawGUI(GUI gui)
        {
            gui.Draw(background);
        }
    }
}
