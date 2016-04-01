using System;
using PikachusPearls.Code.GameStates;
using PikachusPearls.Code.Utility;
using SFML.Graphics;
using SFML.Window;

namespace PikachusPearls.Code
{
    class Program
    {
        public static readonly float fixedFps = 120F;
        public static GameTime gameTime;
        public static int inGameFrameCount { get; private set; }

        static bool running = true;

        static GameState currentGameState = GameState.MainMenu;
        static GameState prevGameState = GameState.InGame;//changed
        static IGameState state;

        static RenderWindow win;
        static GUI gui;

        static void Main(string[] args)
        {
            // initialize window and view
            win = new RenderWindow(new VideoMode(800, 600), "Hadoken!!!");
            resetView();
            gui = new GUI(win);

            // exit Program, when window is being closed
            //win.Closed += new EventHandler(closeWindow);
            win.Closed += (sender, e) => { (sender as Window).Close(); };

            // initialize GameState
            handleNewGameState();

            // initialize GameTime
            gameTime = new GameTime();
            gameTime.Start();

            // debug Text
            Text debugText = new Text("debug Text", new Font("Fonts/calibri.ttf"));

            while (running && win.IsOpen())
            {
                KeyboardInputManager.update();

                if (currentGameState == GameState.InGame) { inGameFrameCount++; }
                currentGameState = state.Update();

                if (currentGameState != prevGameState)
                {
                    handleNewGameState();
                }

                // gather drawStuff from State
                win.Clear(new Color(100, 149, 237));    //cornflowerblue ftw!!! 1337
                state.Draw(win);
                state.DrawGUI(gui);

                // check for window-events. e.g. window closed        
                win.DispatchEvents();

                // update GameTime
                gameTime.Update();
                float deltaTime = (float)gameTime.EllapsedTime.TotalSeconds;

                // idleLoop for fixed FrameRate
                float deltaPlusIdleTime = deltaTime;
                while (deltaPlusIdleTime < (1F / fixedFps))
                {
                    gameTime.Update();
                    deltaPlusIdleTime += (float)gameTime.EllapsedTime.TotalSeconds;
                }

                //some fps Debug
                debugText.DisplayedString = "real fps: " + (int) (1F/deltaPlusIdleTime) + ", theo fps: " +
                                            (int) (1F/deltaTime);
                win.Draw(debugText);

                win.Display();
            }
        }

        static void handleNewGameState()
        {
            switch (currentGameState)
            {
                case GameState.None:
                    running = false;
                    break;

                case GameState.MainMenu:
                    state = new MainMenuState();
                    break;

                case GameState.InGame:
                    state = new InGameState();
                    break;

                case GameState.Reset:
                    currentGameState = prevGameState;
                    prevGameState = GameState.Reset;
                    handleNewGameState();
                    break;
            }

            prevGameState = currentGameState;

            resetView();
        }

        static void resetView()
        {
            win.GetView().Center = new Vector2(win.Size.X / 2F, win.Size.Y / 2F);
            win.GetView().Size = new Vector2(win.Size.X, win.Size.Y);
        }
    }
}