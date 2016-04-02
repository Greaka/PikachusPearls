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
            textures.Add(TextureName.AttackButton, new Texture("Textures/AttackButton.png"));
            textures.Add(TextureName.ItemsButton, new Texture("Textures/ItemsButton.png"));
            textures.Add(TextureName.PearlmonButton, new Texture("Textures/PearlmonButton.png"));
            textures.Add(TextureName.RunButton, new Texture("Textures/RunButton.png"));
        }

        public enum TextureName
        {
            WhitePixel,
            MainMenuBackground,
            AttackButton,
            ItemsButton,
            PearlmonButton,
            RunButton
        }
    }
}
