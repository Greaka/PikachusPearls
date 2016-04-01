using SFML.Graphics;

namespace GameProject2D
{
    interface IGameState
    {
        GameState Update();
        void Draw(RenderWindow win, View view);
        void DrawGUI(GUI gui);
    }
}
