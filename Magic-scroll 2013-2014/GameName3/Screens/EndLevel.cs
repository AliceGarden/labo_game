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
using Windows.Storage;

namespace Magic___Scroll.Screens
{
    public class EndLevel : Screen
    {
        Game1 game;
        KeyboardState keyboard;
        Texture2D niveauSuivant, rejouer, menuPrincipal, sceptre, backgroundDark, menuBackground;
        Texture2D niveauSuivantA, rejouerA, menuPrincipalA;
        Rectangle niveauSuivantPos, rejouerPos, menuPrincipalPos, backgroundDarkPos, menuBackgroundPos;
        MouseState souris;
        Rectangle sourisCol;
        Setting setting;
        int screenHeight;
        int screenWidth;
        bool bouttonCliquer;
        bool niveauSuivantBol, rejouerBol, menuPrincipalBol;
        bool niveauSuivantSurvol, rejouerSurvol, menuPrincipalSurvol;
        int _niveauMax;

        public EndLevel(Game1 game, ScreenManager screenManager, int niveauMax) : base(screenManager)
        {
            setting = Setting.getInstance();
            this.game = game;
            screenManager = new ScreenManager(game.Content);
            _niveauMax = niveauMax;
        }
        public override void Initialize()
        {            
            screenHeight = game.Window.ClientBounds.Height;
            screenWidth = game.Window.ClientBounds.Width;
            sourisCol = new Rectangle();
            niveauSuivantPos = new Rectangle();
            rejouerPos = new Rectangle();
            menuPrincipalPos = new Rectangle();
            backgroundDarkPos = new Rectangle();
            menuBackgroundPos = new Rectangle();

            ApplicationDataContainer localSettings = ApplicationData.Current.LocalSettings;
            localSettings.Containers["ProgressionNiveau"].Containers[setting.currentWorld.ToString()].Containers[setting.currentLevel.ToString()].Values["Finished"] = true;
            setting.RealisationNivMonde[setting.currentWorld][setting.currentLevel-1] = true;
            if (setting.RealisationNivMonde[setting.currentWorld].Count == setting.currentLevel && !((setting.currentWorld + 1) == setting.RealisationNivMonde.Count))
            {
                localSettings.Containers["ProgressionNiveau"].Containers[(setting.currentWorld+1).ToString()].Containers["0"].Values["Available"] = true;
                setting.DisponibiliteNivMonde[setting.currentWorld][setting.currentLevel] = true;
            }
            else
            {
                localSettings.Containers["ProgressionNiveau"].Containers[setting.currentWorld.ToString()].Containers[(setting.currentLevel + 1).ToString()].Values["Available"] = true;
                setting.DisponibiliteNivMonde[setting.currentWorld][setting.currentLevel] = true;
            }
        }
        public override void LoadContent(ContentManager content)
        {
            niveauSuivant = content.Load<Texture2D>("ElementsMenu/Niveau Suivant");
            menuPrincipal = content.Load<Texture2D>("ElementsMenu/Quitter");
            rejouer = content.Load<Texture2D>("ElementsMenu/Reset");

            niveauSuivantA = content.Load<Texture2D>("ElementsMenu/Niveau SuivantA");
            menuPrincipalA = content.Load<Texture2D>("ElementsMenu/QuitterA");
            rejouerA = content.Load<Texture2D>("ElementsMenu/ResetA");

            sceptre = content.Load<Texture2D>("RouePouvoir-Sceptre/Sceptre");
            backgroundDark = content.Load<Texture2D>("ElementsMenu/Noir");
            menuBackground = content.Load<Texture2D>("ElementsMenu/MenuFin2");
        }

        public override void Update(GameTime gameTime)
        {
            keyboard = Keyboard.GetState();
            souris = Mouse.GetState();
            bouttonCliquer = false;

            #region Mise à jour coordonnées
            backgroundDarkPos = new Rectangle(0, 0, screenWidth, screenHeight);
            menuBackgroundPos = new Rectangle((screenWidth - menuBackground.Width) / 2, (screenHeight - menuBackground.Height) / 2, menuBackground.Width, menuBackground.Height);
            sourisCol = new Rectangle(souris.X, souris.Y, 50, 50);
            
            rejouerPos = new Rectangle((screenWidth - menuPrincipal.Width) / 2 - rejouer.Width - 5, (screenHeight / 2), niveauSuivant.Width, niveauSuivant.Height);
            menuPrincipalPos = new Rectangle((screenWidth - menuPrincipal.Width) / 2, (screenHeight / 2), niveauSuivant.Width, niveauSuivant.Height);
            niveauSuivantPos = new Rectangle((screenWidth + menuPrincipal.Width) / 2 + 5, (screenHeight / 2), niveauSuivant.Width, niveauSuivant.Height);
            #endregion

            //if (keyboard.IsKeyDown(Keys.Space))
            //{
            //    base.screenManagerstock.Push(new Jeu(game, base.screenManagerstock));
            //}
            if (keyboard.IsKeyDown(Keys.Escape))
            {
                screenManagerstock.Pop(2);
            }

            #region Souris Enfoncé (Vérification de la position de la souris
            if (souris.X >= niveauSuivantPos.X && souris.X <= niveauSuivantPos.X + niveauSuivantPos.Width && souris.Y >= niveauSuivantPos.Y && souris.Y <= niveauSuivantPos.Y + niveauSuivantPos.Height)
            {
                niveauSuivantSurvol = true;
            }
            else { niveauSuivantSurvol = false; }
            if (souris.X >= menuPrincipalPos.X && souris.X <= menuPrincipalPos.X + menuPrincipalPos.Width && souris.Y >= menuPrincipalPos.Y && souris.Y <= menuPrincipalPos.Y + menuPrincipalPos.Height)
            {
                menuPrincipalSurvol = true;
            }
            else { menuPrincipalSurvol = false; }
            if (souris.X >= rejouerPos.X && souris.X <= rejouerPos.X + rejouerPos.Width && souris.Y >= rejouerPos.Y && souris.Y <= rejouerPos.Y + rejouerPos.Height)
            {
                rejouerSurvol = true;
            }
            else { rejouerSurvol = false; }

            if (souris.LeftButton == ButtonState.Pressed)
            {
                if (niveauSuivantSurvol)
                {
                    niveauSuivantBol = true;
                }
                else { niveauSuivantBol = false; }
                if (menuPrincipalSurvol)
                {
                    menuPrincipalBol = true;
                }
                else { menuPrincipalBol = false; }
                if (rejouerSurvol)
                {
                    rejouerBol = true;
                }
                else { rejouerBol = false; }
            }
            #endregion

            if (niveauSuivantBol && souris.LeftButton == ButtonState.Released)
            {
                niveauSuivantBol = false;
                if (setting.currentLevel == _niveauMax)
                {
                    setting.currentWorld++;
                    setting.currentLevel = 1;
                    base.screenManagerstock.mainMenu();
                }
                else
                {
                    setting.currentLevel++;
                    base.screenManagerstock.Pop(1);
                    base.screenManagerstock.relaunch(new Jeu(game, base.screenManagerstock));
                }
            }
            if (menuPrincipalBol && souris.LeftButton == ButtonState.Released)
            {
                base.screenManagerstock.mainMenu();
            }
            if (rejouerBol && souris.LeftButton == ButtonState.Released)
            {
                base.screenManagerstock.Pop(1);
                base.screenManagerstock.relaunch(new Jeu(game, base.screenManagerstock));
            }
        }

        public override void Draw(Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch)
        {
            screenManagerstock.drawBeforeScreen(spriteBatch);
            spriteBatch.Begin();
            spriteBatch.Draw(backgroundDark, backgroundDarkPos, Color.White * 0.5f);
            spriteBatch.Draw(menuBackground, menuBackgroundPos, Color.White);

            #region Affichage des boutons
            if (niveauSuivantSurvol)
            {
                spriteBatch.Draw(niveauSuivantA, niveauSuivantPos, Color.White);
            }
            else
            {
                spriteBatch.Draw(niveauSuivant, niveauSuivantPos, Color.White);
            }
            if (menuPrincipalSurvol)
            {
                spriteBatch.Draw(menuPrincipalA, menuPrincipalPos, Color.White);
            }
            else
            {
                spriteBatch.Draw(menuPrincipal, menuPrincipalPos, Color.White);
            }
            if (rejouerSurvol)
            {
                spriteBatch.Draw(rejouerA, rejouerPos, Color.White);
            }
            else
            {
                spriteBatch.Draw(rejouer, rejouerPos, Color.White);
            }
            #endregion

            if (bouttonCliquer)
                spriteBatch.Draw(sceptre, new Rectangle(0, 0, 50, 50), Color.White);
            spriteBatch.Draw(sceptre, sourisCol, Color.White);
            spriteBatch.End();
        }
    }
}
