using PikachusPearls.Code.GameStates.IngameElements;
using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PikachusPearls.Code.GameStates
{
    class FightState
    {
        public enum EFightState
        {
            None = -1,

            BeginAnimation,
            Main
        }

        enum Phase
        {
            None = -1,

            Fetch,
            Execute,

            Count
        }

        enum Selected
        {
            None = -1,

            Attack,
            Pearlmon,
            Items,
            Run,

            Count
        }

        enum SelectedAttack
        {
            None = -1,

            Attack1,
            Attack2,
            Attack3,
            Attack4,

            Count
        }

        enum FetchMenu
        {
            None = -1,

            Menu,
            Attacks,
            Pearlmons,
            Items,

            Count
        }

        Sprite Background;
        Player player;
        Pearlmon playersMon;
        Pearlmon enemyMon;
        public EFightState State { get; private set; }

        Phase phase;
        Selected selected;
        SelectedAttack selectedAttack;
        FetchMenu selectedMenu;

        RectangleShape Menubackground;
        Sprite[] Menu;

        Shader SelectedShader;
        RenderStates SelectedState;

        Attack enemyAttackBuffer;
        Attack playerAttackBuffer;

        public FightState()
        {
            State = EFightState.None;
            phase = Phase.None;
            selected = Selected.None;
            selectedAttack = SelectedAttack.None;


            Menubackground = new RectangleShape(new SFML.Window.Vector2f(400, 300));
            Menubackground.Position = new SFML.Window.Vector2f(880, 420);
            Menubackground.OutlineColor = new Color(0, 0, 0);
            Menubackground.OutlineThickness = 2;
            Menu = new Sprite[]{ new Sprite(AssetManager.getTexture(AssetManager.TextureName.AttackButton)),
                new Sprite(AssetManager.getTexture(AssetManager.TextureName.PearlmonButton)),
                new Sprite(AssetManager.getTexture(AssetManager.TextureName.ItemsButton)),
                new Sprite(AssetManager.getTexture(AssetManager.TextureName.RunButton))};

            SelectedShader = new Shader(null, "Shaders/SelectedShader.frag");
            SelectedState = new RenderStates(SelectedShader);
        }

        /// <summary>
        /// prepares the fightState for entering the state
        /// </summary>
        /// <param name="texture">the Background Texture</param>
        /// <param name="player">the player instance</param>
        /// <param name="enemy">the encountered enemy</param>
        public void EnterState(AssetManager.TextureName texture, Player player, Pearlmon enemy)
        {
            if (!AssetManager.getTexture(texture).Equals(Background.Texture))
                Background = new Sprite(AssetManager.getTexture(AssetManager.TextureName.MainMenuBackground));

            State = EFightState.BeginAnimation;
            enemyMon = enemy;
            this.player = player;
            //playersMon = player.getFirstMon();
        }

        public void Draw(RenderWindow win)
        {
            win.Draw(Background);
            enemyMon.Draw(win);
            playersMon.Draw(win);

            if (phase == Phase.Fetch)
                win.Draw(Menubackground);
        }

        public void DrawGUI(GUI gui)
        {
            if(phase == Phase.Fetch)
            {
                for(int i = 0; i<(int)Selected.Count; ++i)
                {
                    if ((Selected)i == selected)
                        gui.Draw(Menu[i], SelectedState);
                    else
                        gui.Draw(Menu[i]);
                }
            }
        }

        public void Update()
        {
            switch (State)
            {
                case EFightState.BeginAnimation:
                    UpdateAnimate();
                    break;
                case EFightState.Main:
                    UpdateMain();
                    break;
                default:
                    EndFight();
                    break;
            }
        }

        void UpdateAnimate()
        {


            State = EFightState.Main;
            phase = Phase.Fetch;
            selected = Selected.Attack;
            selectedMenu = FetchMenu.Menu;
        }

        void UpdateMain()
        {
            if (phase == Phase.Fetch)
            {
                if (enemyAttackBuffer == null)
                {
                    //enemyAttackBuffer = enemyMon.getRandomAttack();
                }

                if (KeyboardInputManager.Downward(SFML.Window.Keyboard.Key.Down))
                    switch (selectedMenu)
                    {
                        case FetchMenu.Menu:
                            selected += 2;
                            break;
                        case FetchMenu.Attacks:
                            selectedAttack += 2;
                            break;

                        default:
                            break;
                    }

                if (KeyboardInputManager.Downward(SFML.Window.Keyboard.Key.Up))
                    switch (selectedMenu)
                    {
                        case FetchMenu.Menu:
                            selected += 2;
                            break;
                        case FetchMenu.Attacks:
                            selectedAttack += 2;
                            break;
                        default:
                            break;
                    }

                if (KeyboardInputManager.Downward(SFML.Window.Keyboard.Key.Right))
                    switch (selectedMenu)
                    {
                        case FetchMenu.Menu:
                            selected++;
                            break;
                        case FetchMenu.Attacks:
                            selectedAttack++;
                            break;
                        default:
                            break;
                    }

                if (KeyboardInputManager.Downward(SFML.Window.Keyboard.Key.Left))
                    switch (selectedMenu)
                    {
                        case FetchMenu.Menu:
                            selected += 3;
                            break;
                        case FetchMenu.Attacks:
                            selectedAttack += 3;
                            break;
                        default:
                            break;
                    }

                if (KeyboardInputManager.Downward(SFML.Window.Keyboard.Key.Return))
                {
                    switch (selectedMenu)
                    {
                        case FetchMenu.Menu:
                            switch (selected)
                            {
                                case Selected.Attack:
                                    selectedMenu = FetchMenu.Attacks;
                                    selectedAttack = SelectedAttack.Attack1;
                                    selected = Selected.Attack;
                                    break;

                                default:
                                    break;
                            }
                            break;

                        case FetchMenu.Attacks:

                            break;

                        default:
                            break;
                    }
                }

                selected = (Selected)((int)selected % (int)Selected.Count);
                selectedAttack = (SelectedAttack)((int)selectedAttack % (int)SelectedAttack.Count);
            }
            if (phase == Phase.Execute)
            {

            }
            if (phase == Phase.None)
                EndFight();
        }

        void EndFight()
        {
            State = EFightState.None;
            selected = Selected.None;
            selectedAttack = SelectedAttack.None;
            selectedMenu = FetchMenu.None;
        }
    }
}
