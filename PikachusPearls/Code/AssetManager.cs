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
            textures.Add(TextureName.MainMenuBackground, new Texture("Textures/BG.png"));
            textures.Add(TextureName.PressEnter, new Texture("Textures/enter.png"));
            textures.Add(TextureName.AttackButton, new Texture("Textures/button_Attack.png"));
            textures.Add(TextureName.ItemsButton, new Texture("Textures/button_Items.png"));
            textures.Add(TextureName.PearlmonButton, new Texture("Textures/button_Pearlmon.png"));
            textures.Add(TextureName.RunButton, new Texture("Textures/button_Run.png"));
            textures.Add(TextureName.GrassHigh, new Texture("Textures/grass_High.png"));
            textures.Add(TextureName.GrassPlain, new Texture("Textures/grass_Plain.png"));
            textures.Add(TextureName.SandBottom, new Texture("Textures/sand_bottom.png"));
            textures.Add(TextureName.SandBottomLeft, new Texture("Textures/sand_bottomLeft.png"));
            textures.Add(TextureName.SandBottomRight, new Texture("Textures/sand_bottomRight.png"));
            textures.Add(TextureName.SandLeft, new Texture("Textures/sand_left.png"));
            textures.Add(TextureName.SandMiddle, new Texture("Textures/sand_middle.png"));
            textures.Add(TextureName.SandRight, new Texture("Textures/sand_right.png"));
            textures.Add(TextureName.SandTop, new Texture("Textures/sand_top.png"));
            textures.Add(TextureName.SandTopLeft, new Texture("Textures/sand_topLeft.png"));
            textures.Add(TextureName.SandTopRight, new Texture("Textures/sand_topRight.png"));
            textures.Add(TextureName.Tree, new Texture("Textures/tree.png"));
            textures.Add(TextureName.WaterBottom, new Texture("Textures/water_bottom.png"));
            textures.Add(TextureName.WaterBottomLeft, new Texture("Textures/water_bottomLeft.png"));
            textures.Add(TextureName.WaterBottomRight, new Texture("Textures/water_bottomRight.png"));
            textures.Add(TextureName.WaterInnerBottomLeft, new Texture("Textures/water_innerBottomLeft.png"));
            textures.Add(TextureName.WaterInnerBottomRight, new Texture("Textures/water_innerBottomRight.png"));
            textures.Add(TextureName.WaterInnerTopLeft, new Texture("Textures/water_innerTopLeft.png"));
            textures.Add(TextureName.WaterInnerTopRight, new Texture("Textures/water_innerTopRight.png"));
            textures.Add(TextureName.WaterLeft, new Texture("Textures/water_left.png"));
            textures.Add(TextureName.WaterMiddle, new Texture("Textures/water_middle.png"));
            textures.Add(TextureName.WaterRight, new Texture("Textures/water_right.png"));
            textures.Add(TextureName.WaterTop, new Texture("Textures/water_top.png"));
            textures.Add(TextureName.WaterTopLeft, new Texture("Textures/water_topLeft.png"));
            textures.Add(TextureName.WaterTopRight, new Texture("Textures/water_topRight.png"));
            textures.Add(TextureName.TRexBack, new Texture("Textures/T-Rex_back.png"));
            textures.Add(TextureName.TRexFront, new Texture("Textures/T-Rex_front.png"));

            textures.Add(TextureName.PlayerSpriteSheet, new Texture("Textures/player_spritesheet.png"));
        }

        public enum TextureName
        {
            WhitePixel,
            MainMenuBackground,
            PressEnter,
            AttackButton,
            ItemsButton,
            PearlmonButton,
            RunButton,
            GrassHigh,
            GrassPlain,
            SandBottom,
            SandBottomLeft,
            SandBottomRight,
            SandLeft,
            SandMiddle,
            SandRight,
            SandTop,
            SandTopLeft,
            SandTopRight,
            Tree,
            WaterBottom,
            WaterBottomLeft,
            WaterBottomRight,
            WaterInnerBottomLeft,
            WaterInnerBottomRight,
            WaterInnerTopLeft,
            WaterInnerTopRight,
            WaterLeft,
            WaterMiddle,
            WaterRight,
            WaterTop,
            WaterTopLeft,
            WaterTopRight,
            TRexBack,
            TRexFront,
            PlayerSpriteSheet


        }
    }
}
