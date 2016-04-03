using PikachusPearls.Code.Utility;
using SFML.Graphics;

namespace PikachusPearls.Code.IngameElements.GameStates
{
    interface IGameState
    {
        GameState Update(GameTime gameTime);
        void Draw(RenderWindow win);
        void DrawGUI(GUI gui);
    }
}
