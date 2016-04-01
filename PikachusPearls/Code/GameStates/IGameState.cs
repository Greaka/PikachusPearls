using SFML.Graphics;

namespace PikachusPearls.Code.GameStates
{
    interface IGameState
    {
        GameState update();
        void draw(RenderWindow win, View view);
        void drawGUI(GUI gui);
    }
}
