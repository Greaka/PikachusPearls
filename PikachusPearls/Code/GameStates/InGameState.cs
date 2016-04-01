using PikachusPearls.Code.GameStates.IngameElements;
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

        public GameState update()
        {
            player.update();
            return GameState.InGame;
        }

        public void draw(RenderWindow win)
        {
            player.draw(win);
        }

        public void drawGUI(GUI gui)
        {
        }
    }
}
