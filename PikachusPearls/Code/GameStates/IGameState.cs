using PikachusPearls.Code.Utility;
using SFML.Graphics;

namespace PikachusPearls.Code.GameStates
{
    interface IGameState
    {
        GameState Update(GameTime gameTime);
        void Draw(RenderWindow win);
        void DrawGUI(GUI gui);
    }
}
