using System;
using System.Collections.Generic;
using System.Globalization;
using PikachusPearls.Code.IngameElements.GameStates;
using PikachusPearls.Code.Utility;
using SFML.Graphics;
using SFML.Window;

namespace PikachusPearls.Code
{
    class Program
    {
        public static Font Font { get; private set; }

        public const float fixedFps = 120F;
        static List<int> debugFps;
        static List<int> theoFps;
        public static GameTime gameTime { get; private set; }
        public static int inGameFrameCount { get; private set; }

        static bool running = true;

        static GameState currentGameState = GameState.MainMenu;
        static GameState prevGameState = GameState.InGame;//changed
        static IGameState state;

        static RenderWindow win;
        static GUI gui;
        private static Vector2i windowPosition;

        static void Main(string[] args)
        {
            debugFps = new List<int>();
            theoFps = new List<int>();
            Font = new Font("Fonts/calibri.ttf");
            // initialize window and view
            win = new RenderWindow(new VideoMode(1280, 720), "Hadoken!!!");
            windowPosition = win.Position;
            win.Resized += (sender, e) =>
            {
                ((RenderWindow) sender).Size = new Vector2u(1280, 720);
                ((RenderWindow) sender).Position = windowPosition;
            };
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
                View v = win.GetView();

                windowPosition = win.Position;
                KeyboardInputManager.Update();

                if (currentGameState == GameState.InGame) { inGameFrameCount++; }
                currentGameState = state.Update(gameTime);

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
                    deltaPlusIdleTime += (float)gameTime.EllapsedTime.TotalSeconds;
                }

                //some fps Debug
                if (debugFps.Count < fixedFps * 3)
                {
                    debugFps.Add((int)(1F / deltaPlusIdleTime));
                }
                else
                {
                    for (int i = 1; i < debugFps.Count; i++)
                    {
                        debugFps[i - 1] = debugFps[i];
                    }
                    debugFps[debugFps.Count - 1] = (int)(1F / deltaPlusIdleTime);
                }
                if (theoFps.Count < 10000)
                {
                    theoFps.Add((int)(1F / deltaTime));
                }
                else
                {
                    for (int i = 1; i < theoFps.Count; i++)
                    {
                        theoFps[i - 1] = theoFps[i];
                    }
                    theoFps[theoFps.Count - 1] = (int)(1F / deltaTime);
                }
                
                var rFps = (int)Helper.Median(debugFps);
                var tFps = (int)Helper.Median(theoFps);
                debugText.DisplayedString = "real fps: " + rFps + ", theo fps: " + tFps;
                
                gui.Draw(debugText);

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