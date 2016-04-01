﻿using SFML.Graphics;
using SFML.Window;

namespace GameProject2D
{
    class MainMenuState : IGameState
    {
        Sprite background;

        public MainMenuState()
        {
            background = new Sprite(new Texture("Textures/MainMenu_Background.jpg"));
        }

        public GameState update()
        {
            if (Keyboard.IsKeyPressed(Keyboard.Key.Return))
            {
                return GameState.InGame;
            }

            return GameState.MainMenu;
        }

        public void draw(RenderWindow win, View view)
        {
            //win.Draw(background);
        }

        public void drawGUI(GUI gui)
        {
            gui.Draw(background);
        }
    }
}
