using PikachusPearls.Code.GameStates.IngameElements;
using PikachusPearls.Code.Utility;
using SFML.Graphics;
using SFML.Window;

namespace PikachusPearls.Code.GameStates
{
    class InGameState : IGameState
    {
        Player player;

        public InGameState()
        {
            player = new Player(new Vector2f(10F, 10F));
        }

        public GameState Update(GameTime gameTime)
        {
            player.update();
            return GameState.InGame;
        }

        public void Draw(RenderWindow win)
        {
            player.draw(win);
        }

        public void DrawGUI(GUI gui)
        {
        }
    }
}
