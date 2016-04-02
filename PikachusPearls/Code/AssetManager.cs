﻿using System.Collections.Generic;
using SFML.Graphics;

namespace PikachusPearls.Code
{
    public class AssetManager
    {
        static Dictionary<TextureName, Texture> textures = new Dictionary<TextureName, Texture>();

        public static Texture getTexture(TextureName textureName)
        {
            if (textures.Count == 0)
            {
                LoadTextures();
            }
            return textures[textureName];
        }

        static void LoadTextures()
        {
            textures.Add(TextureName.WhitePixel, new Texture("Textures/pixel.png"));
            textures.Add(TextureName.MainMenuBackground, new Texture("Textures/BG.png"));
            textures.Add(TextureName.PressEnter, new Texture("Textures/enter.png"));
            textures.Add(TextureName.AttackButton, new Texture("Textures/button_Attack.png"));
            textures.Add(TextureName.ItemsButton, new Texture("Textures/button_Items.png"));
            textures.Add(TextureName.PearlmonButton, new Texture("Textures/button_Pearlmon.png"));
            textures.Add(TextureName.RunButton, new Texture("Textures/button_Run.png"));
        }

        public enum TextureName
        {
            WhitePixel,
            MainMenuBackground,
            PressEnter,
            AttackButton,
            ItemsButton,
            PearlmonButton,
            RunButton
        }
    }
}
