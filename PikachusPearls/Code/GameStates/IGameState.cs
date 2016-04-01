using SFML.Graphics;

namespace PikachusPearls.Code.GameStates
{
    interface IGameState
    {
        GameState Update();
        void Draw(RenderWindow win, View view);
        void DrawGUI(GUI gui);
    }
}
