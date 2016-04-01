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

        public GameState Update()
        {
            player.update();
            return GameState.InGame;
        }

        public void Draw(RenderWindow win, View view)
        {
            player.draw(win, view);
        }

        public void DrawGUI(GUI gui)
        {
        }
    }
}
