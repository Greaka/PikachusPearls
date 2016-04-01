using SFML.Graphics;

namespace PikachusPearls.Code.GameStates
{
    interface IGameState
    {
        GameState Update();
        void Draw(RenderWindow win);
        void DrawGUI(GUI gui);
    }
}
