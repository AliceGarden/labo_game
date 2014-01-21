using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Magic___Scroll.ScreenManagerFolder;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Magic___Scroll.Screens
{
    class ChoixMonde : Screen
    {
        Game1 game;
        KeyboardState keyboard;
        Texture2D MondeSuivant0, MondeSuivant1, MondePrecedent1, MondePrecedent2, Texte0, sceptre, Background0, Background1, Background2, BackgroundFond;
        Texture2D MondeSuivant0A, MondeSuivant1A, MondeSuivant2A, MondePrecedent1A, MondePrecedent2A;
        Texture2D Niv0, Niv1, Niv2;
        Texture2D Niv0A, Niv1A, Niv2A;
        Texture2D niveauReussi0, niveauReussi1, niveauReussi2;
        Rectangle  MondeSuivantPos,MondePrecedentPos,TextePos;
        MouseState souris;
        Rectangle sourisCol;
        SpriteFont showcardFont;
        Rectangle Niv1Pos, Niv2Pos, Niv3Pos, Niv4Pos, Niv5Pos, Niv6Pos, Niv7Pos, Niv8Pos, Niv9Pos, Niv10Pos;
        Setting setting;
        int screenHeight;
        int screenWidth;
        int mondeMax;
        bool bouttonCliquer;
        bool MondeSuivantBol,MondePrecedentBol;
        bool MondeSuivantSurvol,MondePrecedentSurvol;
        bool Niv1Bol, Niv2Bol, Niv3Bol, Niv4Bol, Niv5Bol, Niv6Bol, Niv7Bol, Niv8Bol, Niv9Bol, Niv10Bol;
        bool Niv1Survol,Niv2Survol,Niv3Survol,Niv4Survol,Niv5Survol,Niv6Survol,Niv7Survol,Niv8Survol,Niv9Survol,Niv10Survol;
        bool kbescape;

        public ChoixMonde(Game1 game, ScreenManager screenManager, int _mondeMax) : base(screenManager)
        {
            setting = Setting.getInstance();
            this.game = game;
            screenManager = new ScreenManager(game.Content);    
            mondeMax = _mondeMax;
        }
        public override void Initialize()
        {
            screenHeight = game.Window.ClientBounds.Height;
            screenWidth = game.Window.ClientBounds.Width;
            sourisCol = new Rectangle();
            MondeSuivantPos = new Rectangle();
            MondePrecedentPos = new Rectangle();
            TextePos = new Rectangle();
            setting.currentLevel = 0;
        }
        public override void LoadContent(ContentManager content)
        {
            MondeSuivant1 = content.Load<Texture2D>("ElementsMenu/Niveau suivant foret");
            MondeSuivant0 = content.Load<Texture2D>("ElementsMenu/Niveau suivant");

            MondePrecedent1 = content.Load<Texture2D>("ElementsMenu/Niveau précédent foret");
            MondePrecedent2 = content.Load<Texture2D>("ElementsMenu/Niveau précédent volcan");

            Texte0 = content.Load<Texture2D>("ElementsMenu/Niveau precedentA ");
            showcardFont = content.Load<SpriteFont>("ShowCard");
            Background0 = content.Load<Texture2D>("ElementsMenu/Select niveau 0");
            Background1 = content.Load<Texture2D>("ElementsMenu/Select niveau foret");
            Background2 = content.Load<Texture2D>("ElementsMenu/Select niveau volcan");
            BackgroundFond = content.Load<Texture2D>("ElementsMenu/Menu Paysage");

            Niv0 = content.Load<Texture2D>("ElementsMenu/Bouton vierge Tuto");
            Niv1 = content.Load<Texture2D>("ElementsMenu/Bouton vierge foret");
            Niv2 = content.Load<Texture2D>("ElementsMenu/Bouton vierge volcan");

            Niv0A = content.Load<Texture2D>("ElementsMenu/Bouton vierge Tuto A");
            Niv1A = content.Load<Texture2D>("ElementsMenu/Bouton vierge foret A");
            Niv2A = content.Load<Texture2D>("ElementsMenu/Bouton vierge volcan A");
            
            niveauReussi0 = content.Load<Texture2D>("ElementsMenu/Bouton reussi tuto");
            niveauReussi1 = content.Load<Texture2D>("ElementsMenu/Bouton reussi foret");
            niveauReussi2 = content.Load<Texture2D>("ElementsMenu/Bouton reussi volcan");

            MondeSuivant0A = content.Load<Texture2D>("ElementsMenu/Niveau suivantA");
            MondeSuivant1A = content.Load<Texture2D>("ElementsMenu/Niveau suivant foretA");
            MondeSuivant2A = content.Load<Texture2D>("ElementsMenu/Niveau suivant volcan A");
            
            MondePrecedent1A = content.Load<Texture2D>("ElementsMenu/Niveau précédent foret A");
            MondePrecedent2A = content.Load<Texture2D>("ElementsMenu/Niveau précédent volcan A");

            sceptre = content.Load<Texture2D>("RouePouvoir-Sceptre/Sceptre");

        }
        public override void Update(GameTime gameTime)
        {
            keyboard = Keyboard.GetState();
            souris = Mouse.GetState();
            bouttonCliquer = false;

            #region Mise à jour coordonnées
            sourisCol = new Rectangle(souris.X, souris.Y, 50, 50);
            MondeSuivantPos = new Rectangle((screenWidth / 2) + (Texte0.Width ), (screenHeight / 2) - (screenHeight / 6), MondeSuivant1.Width, MondeSuivant1.Height);
            TextePos = new Rectangle((screenWidth / 2) - (Texte0.Width / 2), (screenHeight / 2) - (screenHeight / 6), Texte0.Width, Texte0.Height);
            MondePrecedentPos = new Rectangle((screenWidth / 2) - (Texte0.Width + MondePrecedent1.Width ), (screenHeight / 2) - (screenHeight/6) , MondePrecedent1.Width, MondePrecedent1.Height);

            Niv1Pos = new Rectangle((screenWidth / 2) - (Niv0.Width *3), (screenHeight / 2), Niv0.Width, Niv0.Height);
            Niv2Pos = new Rectangle((screenWidth / 2) - (Niv0.Width * 2 - (Niv0.Width/4)), (screenHeight / 2), Niv0.Width, Niv0.Height);
            Niv3Pos = new Rectangle((screenWidth / 2) - (Niv0.Width/2), (screenHeight / 2), Niv0.Width, Niv0.Height);
            Niv4Pos = new Rectangle((screenWidth / 2) + (Niv0.Width  - (Niv0.Width / 4)), (screenHeight / 2), Niv0.Width, Niv0.Height);
            Niv5Pos = new Rectangle((screenWidth / 2) + (Niv0.Width * 2), (screenHeight / 2), Niv0.Width, Niv0.Height);
            Niv6Pos = new Rectangle((screenWidth / 2) - (Niv0.Width * 3), (screenHeight / 2) + Niv0.Height*6/5, Niv0.Width, Niv0.Height);
            Niv7Pos = new Rectangle((screenWidth / 2) - (Niv0.Width * 2 - (Niv0.Width / 4)), (screenHeight / 2) + Niv0.Height * 6 / 5, Niv0.Width, Niv0.Height);
            Niv8Pos = new Rectangle((screenWidth / 2) - (Niv0.Width / 2), (screenHeight / 2) + Niv0.Height * 6 / 5, Niv0.Width, Niv0.Height);
            Niv9Pos = new Rectangle((screenWidth / 2) + (Niv0.Width - (Niv0.Width / 4)), (screenHeight / 2) + Niv0.Height * 6 / 5, Niv0.Width, Niv0.Height);
            Niv10Pos = new Rectangle((screenWidth / 2) + (Niv0.Width * 2), (screenHeight / 2) + Niv0.Height * 6 / 5, Niv0.Width, Niv0.Height);
            #endregion

            if (keyboard.IsKeyDown(Keys.Escape))
            {
                kbescape = true;
            }
            if (kbescape && keyboard.IsKeyUp(Keys.Escape))
            {
                screenManagerstock.Pop(1);
            }

            #region Souris Enfoncé (Vérification de la posiition de la souris

            if (souris.X >= MondeSuivantPos.X && souris.X <= MondeSuivantPos.X + MondeSuivantPos.Width && souris.Y >= MondeSuivantPos.Y && souris.Y <= MondeSuivantPos.Y + MondeSuivantPos.Height)
            {
                MondeSuivantSurvol = true;
            }
            else { MondeSuivantSurvol = false; }
            if (souris.X >= MondePrecedentPos.X && souris.X <= MondePrecedentPos.X + MondePrecedentPos.Width && souris.Y >= MondePrecedentPos.Y && souris.Y <= MondePrecedentPos.Y + MondePrecedentPos.Height)
            {
                MondePrecedentSurvol = true;
            }
            else { MondePrecedentSurvol = false; }
            if (souris.X >= Niv1Pos.X && souris.X <= Niv1Pos.X + Niv1Pos.Width && souris.Y >= Niv1Pos.Y && souris.Y <= Niv1Pos.Y + Niv1Pos.Height)
            {
                Niv1Survol = true;
            }
            else { Niv1Survol = false; }
            if (souris.X >= Niv2Pos.X && souris.X <= Niv2Pos.X + Niv2Pos.Width && souris.Y >= Niv2Pos.Y && souris.Y <= Niv2Pos.Y + Niv2Pos.Height)
            {
                Niv2Survol = true;
            }
            else { Niv2Survol = false; }
            if (souris.X >= Niv3Pos.X && souris.X <= Niv3Pos.X + Niv3Pos.Width && souris.Y >= Niv3Pos.Y && souris.Y <= Niv3Pos.Y + Niv3Pos.Height)
            {
                Niv3Survol = true;
            }
            else { Niv3Survol = false; }
            if (souris.X >= Niv4Pos.X && souris.X <= Niv4Pos.X + Niv4Pos.Width && souris.Y >= Niv4Pos.Y && souris.Y <= Niv4Pos.Y + Niv4Pos.Height)
            {
                Niv4Survol = true;
            }
            else { Niv4Survol = false; }
            if (souris.X >= Niv5Pos.X && souris.X <= Niv5Pos.X + Niv5Pos.Width && souris.Y >= Niv5Pos.Y && souris.Y <= Niv5Pos.Y + Niv5Pos.Height)
            {
                Niv5Survol = true;
            }
            else { Niv5Survol = false; }

            if (setting.currentWorld != 0)
            {
                if (souris.X >= Niv6Pos.X && souris.X <= Niv6Pos.X + Niv6Pos.Width && souris.Y >= Niv6Pos.Y && souris.Y <= Niv6Pos.Y + Niv6Pos.Height)
                {
                    Niv6Survol = true;
                }
                else { Niv6Survol = false; }
                if (souris.X >= Niv7Pos.X && souris.X <= Niv7Pos.X + Niv7Pos.Width && souris.Y >= Niv7Pos.Y && souris.Y <= Niv7Pos.Y + Niv7Pos.Height)
                {
                    Niv7Survol = true;
                }
                else { Niv7Survol = false; }
                if (souris.X >= Niv8Pos.X && souris.X <= Niv8Pos.X + Niv8Pos.Width && souris.Y >= Niv8Pos.Y && souris.Y <= Niv8Pos.Y + Niv8Pos.Height)
                {
                    Niv8Survol = true;
                }
                else { Niv8Survol = false; }
                if (souris.X >= Niv9Pos.X && souris.X <= Niv9Pos.X + Niv9Pos.Width && souris.Y >= Niv9Pos.Y && souris.Y <= Niv9Pos.Y + Niv9Pos.Height)
                {
                    Niv9Survol = true;
                }
                else { Niv9Survol = false; }
                if (souris.X >= Niv10Pos.X && souris.X <= Niv10Pos.X + Niv10Pos.Width && souris.Y >= Niv10Pos.Y && souris.Y <= Niv10Pos.Y + Niv10Pos.Height)
                {
                    Niv10Survol = true;
                }
                else { Niv10Survol = false; }
            }




            if (souris.LeftButton == ButtonState.Pressed)
            {
                if (MondeSuivantSurvol)
                {
                    MondeSuivantBol = true;
                }
                else { MondeSuivantBol = false; }

                if (MondePrecedentSurvol)
                {
                    MondePrecedentBol = true;
                }
                else { MondePrecedentBol = false; }

                if (Niv1Survol)
                {
                    Niv1Bol = true;
                }
                else { Niv1Bol = false; }
                if (Niv2Survol)
                {
                    Niv2Bol = true;
                }
                else { Niv2Bol = false; }
                if (Niv3Survol)
                {
                    Niv3Bol = true;
                }
                else { Niv3Bol = false; }
                if (Niv3Survol)
                {
                    Niv3Bol = true;
                }
                else { Niv3Bol = false; }
                if (Niv4Survol)
                {
                    Niv4Bol = true;
                }
                else { Niv4Bol = false; }
                if (Niv5Survol)
                {
                    Niv5Bol = true;
                }
                else { Niv5Bol = false; }
                if (Niv6Survol)
                {
                    Niv6Bol = true;
                }
                else { Niv6Bol = false; }
                if (Niv7Survol)
                {
                    Niv7Bol = true;
                }
                else { Niv7Bol = false; }
                if (Niv8Survol)
                {
                    Niv8Bol = true;
                }
                else { Niv8Bol = false; }
                if (Niv9Survol)
                {
                    Niv9Bol = true;
                }
                else { Niv9Bol = false; }
                if (Niv10Survol)
                {
                    Niv10Bol = true;
                }
                else { Niv10Bol = false; }
            }
            #endregion
            if (MondeSuivantBol && souris.LeftButton == ButtonState.Released)
            {
                MondeSuivantBol = false;
                if (setting.currentWorld < mondeMax)
                {
                    setting.currentWorld++;
                }
            }
            if (MondePrecedentBol && souris.LeftButton == ButtonState.Released)
            {
                MondePrecedentBol = false;
                if (setting.currentWorld > 0)
                {
                    setting.currentWorld--;
                }
            }
            if (Niv1Bol && souris.LeftButton == ButtonState.Released)
            {
                if(setting.currentWorld == 0 && setting.currentLevel == 0)
                    setting.currentLevel = 1;
                else
                    if(setting.DisponibiliteNivMonde[setting.currentWorld][setting.currentLevel])
                        setting.currentLevel = 1;
            }
            if (Niv2Bol && souris.LeftButton == ButtonState.Released && setting.DisponibiliteNivMonde[setting.currentWorld][1])
            {
                setting.currentLevel = 2;
            }
            if (Niv3Bol && souris.LeftButton == ButtonState.Released && setting.DisponibiliteNivMonde[setting.currentWorld][2])
            {
                setting.currentLevel = 3;
            }
            if (Niv4Bol && souris.LeftButton == ButtonState.Released && setting.DisponibiliteNivMonde[setting.currentWorld][3])
            {
                setting.currentLevel = 4;
            }
            if (Niv5Bol && souris.LeftButton == ButtonState.Released && setting.DisponibiliteNivMonde[setting.currentWorld][4])
            {
                setting.currentLevel = 5;
            }
            if (Niv6Bol && souris.LeftButton == ButtonState.Released && setting.DisponibiliteNivMonde[setting.currentWorld][5])
            {
                setting.currentLevel = 6;
            }
            if (Niv7Bol && souris.LeftButton == ButtonState.Released && setting.DisponibiliteNivMonde[setting.currentWorld][6])
            {
                setting.currentLevel = 7;
            }
            if (Niv8Bol && souris.LeftButton == ButtonState.Released && setting.DisponibiliteNivMonde[setting.currentWorld][7])
            {
                setting.currentLevel = 8;
            }
            if (Niv9Bol && souris.LeftButton == ButtonState.Released && setting.DisponibiliteNivMonde[setting.currentWorld][8])
            {
                setting.currentLevel = 9;
            }
            if (Niv10Bol && souris.LeftButton == ButtonState.Released && setting.DisponibiliteNivMonde[setting.currentWorld][9])
            {
                setting.currentLevel = 10;
            }
            if (setting.currentLevel != 0)
            {
                base.screenManagerstock.Push(new Jeu(game, base.screenManagerstock));
            }
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            //screenManagerstock.drawBeforeScreen(spriteBatch);
            spriteBatch.Begin();
            spriteBatch.Draw(BackgroundFond, new Rectangle(0, 0, screenWidth, screenHeight), Color.White);

            switch (setting.currentWorld)
            {
                case 0:
                    spriteBatch.Draw(Background0, new Rectangle((screenWidth / 2) - (Background0.Width / 2), (screenHeight / 2) - (Background0.Height / 2), Background0.Width, Background0.Height), Color.White);
                    spriteBatch.DrawString(showcardFont, "Tutoriel", new Vector2(TextePos.X, TextePos.Y), Color.White);                    
                    if (MondeSuivantSurvol)
                    {
                        spriteBatch.Draw(MondeSuivant0A, MondeSuivantPos, Color.White);
                    }
                    else
                    {
                        spriteBatch.Draw(MondeSuivant0, MondeSuivantPos, Color.White);
                    }
                    break;
                case 1:
                    spriteBatch.Draw(Background1, new Rectangle((screenWidth / 2) - (Background0.Width / 2), (screenHeight / 2) - (Background0.Height / 2), Background0.Width, Background0.Height), Color.White);
                    spriteBatch.DrawString(showcardFont,"Foret", new Vector2(TextePos.X, TextePos.Y), Color.White);
                    if (MondeSuivantSurvol)
                    {
                        spriteBatch.Draw(MondeSuivant1A, MondeSuivantPos, Color.White);
                    }
                    else
                    {
                        spriteBatch.Draw(MondeSuivant1, MondeSuivantPos, Color.White);
                    }
                    if (MondePrecedentSurvol)
                    {
                        spriteBatch.Draw(MondePrecedent1A, MondePrecedentPos, Color.White);
                    }
                    else
                    {
                        spriteBatch.Draw(MondePrecedent1, MondePrecedentPos, Color.White);
                    }
                    break;
                case 2:
                    spriteBatch.Draw(Background2, new Rectangle((screenWidth / 2) - (Background0.Width / 2), (screenHeight / 2) - (Background0.Height / 2), Background0.Width, Background0.Height), Color.White);
                    spriteBatch.DrawString(showcardFont, "Volcan", new Vector2(TextePos.X, TextePos.Y), Color.White);
                    if (MondePrecedentSurvol)
                    {
                        spriteBatch.Draw(MondePrecedent2A, MondePrecedentPos, Color.White);
                    }
                    else
                    {
                        spriteBatch.Draw(MondePrecedent2, MondePrecedentPos, Color.White);
                    }
                    break;
            }
            
            if (setting.currentWorld == 0)
            {
                #region affichage mouette verte de réussite
                if (setting.RealisationNivMonde[0][0])
                    spriteBatch.Draw(niveauReussi0, new Rectangle(Niv1Pos.X + Niv1Pos.Width - 30, Niv1Pos.Y + Niv1Pos.Height - 30, 30, 30), Color.White);
                if (setting.RealisationNivMonde[0][1])
                    spriteBatch.Draw(niveauReussi0, new Rectangle(Niv2Pos.X + Niv2Pos.Width - 30, Niv2Pos.Y + Niv2Pos.Height - 30, 30, 30), Color.White);
                if (setting.RealisationNivMonde[0][2])
                    spriteBatch.Draw(niveauReussi0, new Rectangle(Niv3Pos.X + Niv3Pos.Width - 30, Niv3Pos.Y + Niv3Pos.Height - 30, 30, 30), Color.White);
                if (setting.RealisationNivMonde[0][3])
                    spriteBatch.Draw(niveauReussi0, new Rectangle(Niv4Pos.X + Niv4Pos.Width - 30, Niv4Pos.Y + Niv4Pos.Height - 30, 30, 30), Color.White);
                if (setting.RealisationNivMonde[0][4])
                    spriteBatch.Draw(niveauReussi0, new Rectangle(Niv5Pos.X + Niv5Pos.Width - 30, Niv5Pos.Y + Niv5Pos.Height - 30, 30, 30), Color.White);
                #endregion

                Color cl = new Color();
                if (setting.DisponibiliteNivMonde[0][0])
                    cl = Color.White;
                else cl = Color.Black;
                if (Niv1Survol)
                {
                    spriteBatch.Draw(Niv0A, Niv1Pos, cl);
                }
                else { spriteBatch.Draw(Niv0, Niv1Pos, cl); }

                if (setting.DisponibiliteNivMonde[0][1])
                    cl = Color.White;
                else cl = Color.Black;
                if (Niv2Survol)
                {
                    spriteBatch.Draw(Niv0A, Niv2Pos, cl);
                }
                else { spriteBatch.Draw(Niv0, Niv2Pos, cl); }

                if (setting.DisponibiliteNivMonde[0][2])
                    cl = Color.White;
                else cl = Color.Black;
                if (Niv3Survol)
                {
                    spriteBatch.Draw(Niv0A, Niv3Pos, cl);
                }
                else { spriteBatch.Draw(Niv0, Niv3Pos, cl); }

                if (setting.DisponibiliteNivMonde[0][3])
                    cl = Color.White;
                else cl = Color.Black;
                if (Niv4Survol)
                {
                    spriteBatch.Draw(Niv0A, Niv4Pos, cl);
                }
                else { spriteBatch.Draw(Niv0, Niv4Pos, cl); }

                if (setting.DisponibiliteNivMonde[0][4])
                    cl = Color.White;
                else cl = Color.Black;
                if (Niv5Survol)
                {
                    spriteBatch.Draw(Niv0A, Niv5Pos, cl);
                }
                else { spriteBatch.Draw(Niv0, Niv5Pos, cl); }
                
            }
            if (setting.currentWorld == 1)
            {
                #region affichage mouette verte de réussite
                if (setting.RealisationNivMonde[1][0])
                    spriteBatch.Draw(niveauReussi1, new Rectangle(Niv1Pos.X + Niv1Pos.Width - 30, Niv1Pos.Y + Niv1Pos.Height - 30, 30, 30), Color.White);
                if (setting.RealisationNivMonde[1][1])
                    spriteBatch.Draw(niveauReussi1, new Rectangle(Niv2Pos.X + Niv2Pos.Width - 30, Niv2Pos.Y + Niv2Pos.Height - 30, 30, 30), Color.White);
                if (setting.RealisationNivMonde[1][2])
                    spriteBatch.Draw(niveauReussi1, new Rectangle(Niv3Pos.X + Niv3Pos.Width - 30, Niv3Pos.Y + Niv3Pos.Height - 30, 30, 30), Color.White);
                if (setting.RealisationNivMonde[1][3])
                    spriteBatch.Draw(niveauReussi1, new Rectangle(Niv4Pos.X + Niv4Pos.Width - 30, Niv4Pos.Y + Niv4Pos.Height - 30, 30, 30), Color.White);
                if (setting.RealisationNivMonde[1][4])
                    spriteBatch.Draw(niveauReussi1, new Rectangle(Niv5Pos.X + Niv5Pos.Width - 30, Niv5Pos.Y + Niv5Pos.Height - 30, 30, 30), Color.White);
                if (setting.RealisationNivMonde[1][5])
                    spriteBatch.Draw(niveauReussi1, new Rectangle(Niv6Pos.X + Niv6Pos.Width - 30, Niv6Pos.Y + Niv6Pos.Height - 30, 30, 30), Color.White);
                if (setting.RealisationNivMonde[1][6])
                    spriteBatch.Draw(niveauReussi1, new Rectangle(Niv7Pos.X + Niv7Pos.Width - 30, Niv7Pos.Y + Niv7Pos.Height - 30, 30, 30), Color.White);
                if (setting.RealisationNivMonde[1][7])
                    spriteBatch.Draw(niveauReussi1, new Rectangle(Niv8Pos.X + Niv8Pos.Width - 30, Niv8Pos.Y + Niv8Pos.Height - 30, 30, 30), Color.White);
                if (setting.RealisationNivMonde[1][8])
                    spriteBatch.Draw(niveauReussi1, new Rectangle(Niv9Pos.X + Niv9Pos.Width - 30, Niv9Pos.Y + Niv9Pos.Height - 30, 30, 30), Color.White);
                if (setting.RealisationNivMonde[1][9])
                    spriteBatch.Draw(niveauReussi1, new Rectangle(Niv10Pos.X + Niv10Pos.Width - 30, Niv10Pos.Y + Niv10Pos.Height - 30, 30, 30), Color.White);
                #endregion

                Color cl = new Color();

                if (setting.DisponibiliteNivMonde[1][0])
                    cl = Color.White;
                else cl = Color.Black;
                if (Niv1Survol)
                {
                    spriteBatch.Draw(Niv1A, Niv1Pos, cl);
                }
                else { spriteBatch.Draw(Niv1, Niv1Pos, cl); }

                if (setting.DisponibiliteNivMonde[1][1])
                    cl = Color.White;
                else cl = Color.Black;
                if (Niv2Survol)
                {
                    spriteBatch.Draw(Niv1A, Niv2Pos, cl);
                }
                else { spriteBatch.Draw(Niv1, Niv2Pos, cl); }

                if (setting.DisponibiliteNivMonde[1][2])
                    cl = Color.White;
                else cl = Color.Black;
                if (Niv3Survol)
                {
                    spriteBatch.Draw(Niv1A, Niv3Pos, cl);
                }
                else { spriteBatch.Draw(Niv1, Niv3Pos, cl); }

                if (setting.DisponibiliteNivMonde[1][3])
                    cl = Color.White;
                else cl = Color.Black;
                if (Niv4Survol)
                {
                    spriteBatch.Draw(Niv1A, Niv4Pos, cl);
                }
                else { spriteBatch.Draw(Niv1, Niv4Pos, cl); }

                if (setting.DisponibiliteNivMonde[1][4])
                    cl = Color.White;
                else cl = Color.Black;
                if (Niv5Survol)
                {
                    spriteBatch.Draw(Niv1A, Niv5Pos, cl);
                }
                else { spriteBatch.Draw(Niv1, Niv5Pos, cl); }

                if (setting.DisponibiliteNivMonde[1][5])
                    cl = Color.White;
                else cl = Color.Black;
                if (Niv6Survol)
                {
                    spriteBatch.Draw(Niv1A, Niv6Pos, cl);
                }
                else { spriteBatch.Draw(Niv1, Niv6Pos, cl); }

                if (setting.DisponibiliteNivMonde[1][6])
                    cl = Color.White;
                else cl = Color.Black;
                if (Niv7Survol)
                {
                    spriteBatch.Draw(Niv1A, Niv7Pos, cl);
                }
                else { spriteBatch.Draw(Niv1, Niv7Pos, cl); }

                if (setting.DisponibiliteNivMonde[1][7])
                    cl = Color.White;
                else cl = Color.Black;
                if (Niv8Survol)
                {
                    spriteBatch.Draw(Niv1A, Niv8Pos, cl);
                }
                else { spriteBatch.Draw(Niv1, Niv8Pos, cl); }

                if (setting.DisponibiliteNivMonde[1][8])
                    cl = Color.White;
                else cl = Color.Black;
                if (Niv9Survol)
                {
                    spriteBatch.Draw(Niv1A, Niv9Pos, cl);
                }
                else { spriteBatch.Draw(Niv1, Niv9Pos, cl); }

                if (setting.DisponibiliteNivMonde[1][9])
                    cl = Color.White;
                else cl = Color.Black;
                if (Niv10Survol)
                {
                    spriteBatch.Draw(Niv1A, Niv10Pos, cl);
                }
                else { spriteBatch.Draw(Niv1, Niv10Pos, cl); }
            }
            if (setting.currentWorld == 2)
            {
                #region affichage mouette verte de réussite
                if (setting.RealisationNivMonde[2][0])
                    spriteBatch.Draw(niveauReussi2, new Rectangle(Niv1Pos.X + Niv1Pos.Width - 30, Niv1Pos.Y + Niv1Pos.Height - 30, 30, 30), Color.White);
                if (setting.RealisationNivMonde[2][1])
                    spriteBatch.Draw(niveauReussi2, new Rectangle(Niv2Pos.X + Niv2Pos.Width - 30, Niv2Pos.Y + Niv2Pos.Height - 30, 30, 30), Color.White);
                if (setting.RealisationNivMonde[2][2])
                    spriteBatch.Draw(niveauReussi2, new Rectangle(Niv3Pos.X + Niv3Pos.Width - 30, Niv3Pos.Y + Niv3Pos.Height - 30, 30, 30), Color.White);
                if (setting.RealisationNivMonde[2][3])
                    spriteBatch.Draw(niveauReussi2, new Rectangle(Niv4Pos.X + Niv4Pos.Width - 30, Niv4Pos.Y + Niv4Pos.Height - 30, 30, 30), Color.White);
                if (setting.RealisationNivMonde[2][4])
                    spriteBatch.Draw(niveauReussi2, new Rectangle(Niv5Pos.X + Niv5Pos.Width - 30, Niv5Pos.Y + Niv5Pos.Height - 30, 30, 30), Color.White);
                if (setting.RealisationNivMonde[2][5])
                    spriteBatch.Draw(niveauReussi2, new Rectangle(Niv6Pos.X + Niv6Pos.Width - 30, Niv6Pos.Y + Niv6Pos.Height - 30, 30, 30), Color.White);
                if (setting.RealisationNivMonde[2][6])
                    spriteBatch.Draw(niveauReussi2, new Rectangle(Niv7Pos.X + Niv7Pos.Width - 30, Niv7Pos.Y + Niv7Pos.Height - 30, 30, 30), Color.White);
                if (setting.RealisationNivMonde[2][7])
                    spriteBatch.Draw(niveauReussi2, new Rectangle(Niv8Pos.X + Niv8Pos.Width - 30, Niv8Pos.Y + Niv8Pos.Height - 30, 30, 30), Color.White);
                if (setting.RealisationNivMonde[2][8])
                    spriteBatch.Draw(niveauReussi2, new Rectangle(Niv9Pos.X + Niv9Pos.Width - 30, Niv9Pos.Y + Niv9Pos.Height - 30, 30, 30), Color.White);
                if (setting.RealisationNivMonde[2][9])
                    spriteBatch.Draw(niveauReussi2, new Rectangle(Niv10Pos.X + Niv10Pos.Width - 30, Niv10Pos.Y + Niv10Pos.Height - 30, 30, 30), Color.White);
                #endregion

                Color cl = new Color();
                if (setting.DisponibiliteNivMonde[2][0])
                    cl = Color.White;
                else cl = Color.Black;
                if (Niv1Survol)
                {
                    spriteBatch.Draw(Niv2A, Niv1Pos, cl);
                }
                else { spriteBatch.Draw(Niv2, Niv1Pos, cl); }

                if (setting.DisponibiliteNivMonde[2][1])
                    cl = Color.White;
                else cl = Color.Black;
                if (Niv2Survol)
                {
                    spriteBatch.Draw(Niv2A, Niv2Pos, cl);
                }
                else { spriteBatch.Draw(Niv2, Niv2Pos, cl); }

                if (setting.DisponibiliteNivMonde[2][2])
                    cl = Color.White;
                else cl = Color.Black;
                if (Niv3Survol)
                {
                    spriteBatch.Draw(Niv2A, Niv3Pos, cl);
                }
                else { spriteBatch.Draw(Niv2, Niv3Pos, cl); }

                if (setting.DisponibiliteNivMonde[2][3])
                    cl = Color.White;
                else cl = Color.Black;
                if (Niv4Survol)
                {
                    spriteBatch.Draw(Niv2A, Niv4Pos, cl);
                }
                else { spriteBatch.Draw(Niv2, Niv4Pos, cl); }

                if (setting.DisponibiliteNivMonde[2][4])
                    cl = Color.White;
                else cl = Color.Black;
                if (Niv5Survol)
                {
                    spriteBatch.Draw(Niv2A, Niv5Pos, cl);
                }
                else { spriteBatch.Draw(Niv2, Niv5Pos, cl); }

                if (setting.DisponibiliteNivMonde[2][5])
                    cl = Color.White;
                else cl = Color.Black;
                if (Niv6Survol)
                {
                    spriteBatch.Draw(Niv2A, Niv6Pos, cl);
                }
                else { spriteBatch.Draw(Niv2, Niv6Pos, cl); }

                if (setting.DisponibiliteNivMonde[2][6])
                    cl = Color.White;
                else cl = Color.Black;
                if (Niv7Survol)
                {
                    spriteBatch.Draw(Niv2A, Niv7Pos, cl);
                }
                else { spriteBatch.Draw(Niv2, Niv7Pos, cl); }

                if (setting.DisponibiliteNivMonde[2][7])
                    cl = Color.White;
                else cl = Color.Black;
                if (Niv8Survol)
                {
                    spriteBatch.Draw(Niv2A, Niv8Pos, cl);
                }
                else { spriteBatch.Draw(Niv2, Niv8Pos, cl); }

                if (setting.DisponibiliteNivMonde[2][8])
                    cl = Color.White;
                else cl = Color.Black;
                if (Niv9Survol)
                {
                    spriteBatch.Draw(Niv2A, Niv9Pos, cl);
                }
                else { spriteBatch.Draw(Niv2, Niv9Pos, cl); }

                if (setting.DisponibiliteNivMonde[2][9])
                    cl = Color.White;
                else cl = Color.Black;
                if (Niv10Survol)
                {
                    spriteBatch.Draw(Niv2A, Niv10Pos, cl);
                }
                else { spriteBatch.Draw(Niv2, Niv10Pos, cl); }
            }

            spriteBatch.DrawString(showcardFont, "1", new Vector2(Niv1Pos.X + (Niv1Pos.Width / 2) - "1".Length * 10, Niv1Pos.Y + (Niv1Pos.Height / 2) - "1".Length * 20), Color.White);
            spriteBatch.DrawString(showcardFont, "2", new Vector2(Niv2Pos.X + (Niv2Pos.Width / 2) - "1".Length * 10, Niv2Pos.Y + (Niv1Pos.Height / 2) - "1".Length * 20), Color.White);
            spriteBatch.DrawString(showcardFont, "3", new Vector2(Niv3Pos.X + (Niv3Pos.Width / 2) - "1".Length * 10, Niv3Pos.Y + (Niv1Pos.Height / 2) - "1".Length * 20), Color.White);
            spriteBatch.DrawString(showcardFont, "4", new Vector2(Niv4Pos.X + (Niv4Pos.Width / 2) - "1".Length * 10, Niv4Pos.Y + (Niv1Pos.Height / 2) - "1".Length * 20), Color.White);
            spriteBatch.DrawString(showcardFont, "5", new Vector2(Niv5Pos.X + (Niv5Pos.Width / 2) - "1".Length * 10, Niv5Pos.Y + (Niv1Pos.Height / 2) - "1".Length * 20), Color.White);
            if (setting.currentWorld != 0)
            {
                spriteBatch.DrawString(showcardFont, "6", new Vector2(Niv6Pos.X + (Niv6Pos.Width / 2) - "1".Length * 10, Niv6Pos.Y + (Niv1Pos.Height / 2) - "1".Length * 20), Color.White);
                spriteBatch.DrawString(showcardFont, "7", new Vector2(Niv7Pos.X + (Niv7Pos.Width / 2) - "1".Length * 10, Niv7Pos.Y + (Niv1Pos.Height / 2) - "1".Length * 20), Color.White);
                spriteBatch.DrawString(showcardFont, "8", new Vector2(Niv8Pos.X + (Niv8Pos.Width / 2) - "1".Length * 10, Niv8Pos.Y + (Niv1Pos.Height / 2) - "1".Length * 20), Color.White);
                spriteBatch.DrawString(showcardFont, "9", new Vector2(Niv9Pos.X + (Niv9Pos.Width / 2) - "1".Length * 10, Niv9Pos.Y + (Niv1Pos.Height / 2) - "1".Length * 20), Color.White);
                spriteBatch.DrawString(showcardFont, "10", new Vector2(Niv10Pos.X + (Niv10Pos.Width / 2) - "1".Length * 10, Niv10Pos.Y + (Niv1Pos.Height / 2) - "1".Length * 20), Color.White);
            }
            if (bouttonCliquer)
                spriteBatch.Draw(sceptre, new Rectangle(0, 0, 50, 50), Color.White);
            spriteBatch.Draw(sceptre, sourisCol, Color.White);
            spriteBatch.End();
        }
    }
}
