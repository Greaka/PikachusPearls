using System;
using SFML.Graphics;
using SFML.Window;

namespace PikachusPearls.Code.IngameElements.GameStates
{
    class FightState
    {
        Random rand = new Random();

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
            Attack4
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

            Menu[0].Position = Menubackground.Position;
            Menu[1].Position = Menubackground.Position + new Vector2f(200, 0);
            Menu[2].Position = Menubackground.Position + new Vector2f(0, 150);
            Menu[3].Position = Menubackground.Position + new Vector2f(200, 150);

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
            if (Background == null || !AssetManager.getTexture(texture).Equals(Background.Texture))
            {
                if (Background != null)
                    Background.Dispose();

                Background = new Sprite(AssetManager.getTexture(texture));
                Background.Scale = new Vector2f(1280f / Background.Texture.Size.X, 720f / Background.Texture.Size.Y);
            }
            State = EFightState.BeginAnimation;
            enemyMon = enemy;
            this.player = player;
            playersMon = player.GetFirstMon();

            enemyMon.GetSprite().Scale = new Vector2f(0.5f, 0.5f);
            playersMon.GetSprite().Scale = new Vector2f(0.75f, 0.75f);

            enemyMon.GetSprite().Position = new Vector2f((Background.Texture.Size.X * Background.Scale.X) / 2 + 50, 50);

            Vector2f playmonPos = new Vector2f((1130 / 2) * Background.Scale.X, Background.Texture.Size.Y * Background.Scale.Y - 50);
            playmonPos += new Vector2f(-playersMon.GetSprite().Texture.Size.X * playersMon.GetSprite().Scale.X / 2, -playersMon.GetSprite().Texture.Size.Y * playersMon.GetSprite().Scale.Y);
            playersMon.GetSprite().Position = playmonPos;

            playersMon.GetSprite().Texture = AssetManager.getTexture(AssetManager.TextureName.TRexBack);
            playersMon.HpBar_Base.Position = Menubackground.Position + new Vector2f(0, -50);
            playersMon.HpBar_Current.Position = playersMon.HpBar_Base.Position;
        }

        public void Draw(RenderWindow win)
        {
            View v = win.GetView();
            v.Center = v.Size / 2;
            win.SetView(v);

            win.Draw(Background);
            enemyMon.Draw(win);
            playersMon.Draw(win);

            if (phase == Phase.Fetch)
            {
                win.Draw(Menubackground);

                if (selectedMenu == FetchMenu.Menu)
                    for (int i = 0; i < (int)Selected.Count; ++i)
                    {
                        if ((Selected)i == selected)
                            win.Draw(Menu[i], SelectedState);
                        else
                            win.Draw(Menu[i]);
                    }

                if (selectedMenu == FetchMenu.Attacks)
                    for (int i = 0; i < playersMon.CountOfKnownAttacks; ++i)
                    {
                        playersMon.GetAttack(i).Draw(win, (i <= 1) ? (Menubackground.Position + i * new Vector2f(Menubackground.Size.X / 2, 0)) : ((i == 2) ? (Menubackground.Position + new Vector2f(0, Menubackground.Size.Y)) : (Menubackground.Position + Menubackground.Size / 2)), i == (int)selectedAttack);
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
                    enemyAttackBuffer = enemyMon.GetRandomAttack();
                }

                if (KeyboardInputManager.Downward(Keyboard.Key.Down))
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

                if (KeyboardInputManager.Downward(Keyboard.Key.Up))
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

                if (KeyboardInputManager.Downward(Keyboard.Key.Right))
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

                if (KeyboardInputManager.Downward(Keyboard.Key.Left))
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

                if (KeyboardInputManager.Downward(Keyboard.Key.Return))
                {
                    switch (selectedMenu)
                    {
                        case FetchMenu.Menu:
                            switch (selected)
                            {
                                case Selected.Attack:
                                    EnterAttacks();
                                    break;
                                case Selected.Run:
                                    EndFight();
                                    break;
                                default:
                                    break;
                            }
                            break;

                        case FetchMenu.Attacks:
                            playerAttackBuffer = playersMon.GetAttack((int)selectedAttack);
                            EnterExecute();
                            break;

                        default:
                            break;
                    }
                }

                selected = (Selected)((int)selected % (int)Selected.Count);
                selectedAttack = (SelectedAttack)((int)selectedAttack % playersMon.CountOfKnownAttacks);
            }
            if (phase == Phase.Execute)
            {
                if(playersMon.Speed > enemyMon.Speed)
                {
                    enemyMon.BeAttackedByWith(playersMon, playerAttackBuffer);
                    playersMon.BeAttackedByWith(enemyMon, enemyAttackBuffer);
                }
                if(playersMon.Speed < enemyMon.Speed)
                {
                    playersMon.BeAttackedByWith(enemyMon, enemyAttackBuffer);
                    enemyMon.BeAttackedByWith(playersMon, playerAttackBuffer);
                }
                if(playersMon.Speed == enemyMon.Speed)
                {
                    
                    int i = rand.Next(0, 1);
                    if(i == 0)
                    {
                        enemyMon.BeAttackedByWith(playersMon, playerAttackBuffer);
                        playersMon.BeAttackedByWith(enemyMon, enemyAttackBuffer);
                    }
                    else
                    {
                        playersMon.BeAttackedByWith(enemyMon, enemyAttackBuffer);
                        enemyMon.BeAttackedByWith(playersMon, playerAttackBuffer);
                    }
                }
                EnterFetch();

                if(playersMon.CurrentHp <= 0 || enemyMon.CurrentHp <= 0)
                {
                    if (enemyMon.CurrentHp <= 0)
                        Console.WriteLine("You Win!!");
                    else
                        Console.WriteLine("You Lost … NOOOOOOB");

                    EndFight();
                }
            }
            if (phase == Phase.None)
                EndFight();
        }

        void EnterFetch()
        {
            phase = Phase.Fetch;
            selected = Selected.Attack;
            selectedMenu = FetchMenu.Menu;

            playerAttackBuffer = null;
            enemyAttackBuffer = null;
        }

        void EnterAttacks()
        {
            selectedMenu = FetchMenu.Attacks;
            selectedAttack = SelectedAttack.Attack1;
            selected = Selected.Attack;
        }

        void ExitAttacks()
        {
            selectedAttack = SelectedAttack.None;
            selectedMenu = FetchMenu.Menu;
        }

        void EnterExecute()
        {
            ExitAttacks();
            selectedMenu = FetchMenu.None;
            selected = Selected.None;
            phase = Phase.Execute;
        }

        void EndFight()
        {
            State = EFightState.None;
            selected = Selected.None;
            selectedAttack = SelectedAttack.None;
            selectedMenu = FetchMenu.None;
            enemyMon.Dispose();
        }
    }
}
