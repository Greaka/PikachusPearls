using System.Collections.Generic;
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
            textures.Add(TextureName.MainMenuBackground, new Texture("Textures/MainMenu_Background.jpg"));

        }

        public enum TextureName
        {
            WhitePixel,
            MainMenuBackground,
        }
    }
}
