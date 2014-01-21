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
using Windows.UI.ViewManagement;

namespace Magic___Scroll.Screens
{
    public class PauseMenu : Screen
    {
        Game1 game;
        ApplicationDataContainer localSettings;
        StorageFolder localFolder;
        KeyboardState keyboard;
        Texture2D SonButtonOff, backInGame, menuPrincipal, niveauSuivant, sceptre, backgroundDark;
        Texture2D SonButtonOn, backInGameA, menuPrincipalA, niveauSuivantA;
        Rectangle SonButtonPos, backInGamePos, menuPrincipalPos, niveauSuivantPos, backgroundDarkPos;
        MouseState souris;
        Rectangle sourisCol;
        Setting setting;
        int screenHeight;
        int screenWidth;
        bool bouttonCliquer;
        bool SonButtonBol, niveauSuivantBol, menuPrincipalBol, backInGameBol;
        bool SonButtonSurvol, niveauSuivantSurvol, menuPrincipalSurvol, backInGameSurvol;
        int _niveauMax;
        bool kbescape;

        public PauseMenu(Game1 game, ScreenManager screenManager, int niveauMax) : base(screenManager)
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
            localSettings = ApplicationData.Current.LocalSettings;
            localFolder = ApplicationData.Current.LocalFolder;
            sourisCol = new Rectangle();
            backInGamePos = new Rectangle();
            menuPrincipalPos = new Rectangle();
            niveauSuivantPos = new Rectangle();
            backgroundDarkPos = new Rectangle();
            SonButtonPos = new Rectangle();
            SonButtonSurvol = setting.SonActive;
        }
        public override void LoadContent(ContentManager content)
        {
            backInGame = content.Load<Texture2D>("ElementsMenu/Reprendre");
            niveauSuivant = content.Load<Texture2D>("ElementsMenu/Niveau suivant");
            menuPrincipal = content.Load<Texture2D>("ElementsMenu/Quitter");
            SonButtonOff = content.Load<Texture2D>("ElementsMenu/SonOff");

            backInGameA = content.Load<Texture2D>("ElementsMenu/ReprendreA");
            niveauSuivantA = content.Load<Texture2D>("ElementsMenu/Niveau suivantA");
            menuPrincipalA = content.Load<Texture2D>("ElementsMenu/QuitterA");
            SonButtonOn = content.Load<Texture2D>("ElementsMenu/SonOn");
            
            sceptre = content.Load<Texture2D>("RouePouvoir-Sceptre/Sceptre");
            backgroundDark = content.Load<Texture2D>("ElementsMenu/Noir");
        }

        public override void Update(GameTime gameTime)
        {
            if (ApplicationView.Value == ApplicationViewState.Snapped)
            {
                screenManagerstock.Push(new SnappedIsNotAllowed(game, screenManagerstock));
            }

            keyboard = Keyboard.GetState();
            souris = Mouse.GetState();
            bouttonCliquer = false;

            #region Mise à jour coordonnées
            sourisCol = new Rectangle(souris.X, souris.Y, 50, 50);
            SonButtonPos = new Rectangle(20, 20, SonButtonOff.Width, SonButtonOff.Height);
            niveauSuivantPos = new Rectangle((screenWidth / 2) - (niveauSuivant.Width / 2), (screenHeight / 2) + (backInGame.Height / 2) + 50, niveauSuivant.Width, niveauSuivant.Height);
            menuPrincipalPos = new Rectangle((screenWidth / 2) - (menuPrincipal.Width / 2), (screenHeight / 2) + (backInGame.Height / 2) + niveauSuivant.Height + 100, menuPrincipal.Width, menuPrincipal.Height);
            backInGamePos = new Rectangle((screenWidth / 2) - (backInGame.Width / 2), (screenHeight / 2) - (backInGame.Height / 2), backInGame.Width, backInGame.Height);
            backgroundDarkPos = new Rectangle(0, 0, screenWidth, screenHeight);
            #endregion

            //if (keyboard.IsKeyDown(Keys.Space))
            //{
            //    base.screenManagerstock.Push(new Jeu(game, base.screenManagerstock));
            //}
            if (keyboard.IsKeyDown(Keys.Escape))
            {
                kbescape = true;
            }
            if (kbescape && keyboard.IsKeyUp(Keys.Escape))
            {
                screenManagerstock.Pop(1);
            }

            #region Souris Enfoncé (Vérification de la posiition de la souris
            if (souris.X >= backInGamePos.X && souris.X <= backInGamePos.X + backInGamePos.Width && souris.Y >= backInGamePos.Y && souris.Y <= backInGamePos.Y + backInGamePos.Height)
            {
                backInGameSurvol = true;
            }
            else { backInGameSurvol = false; }
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
            if (souris.X >= SonButtonPos.X && souris.X <= SonButtonPos.X + SonButtonPos.Width && souris.Y >= SonButtonPos.Y && souris.Y <= SonButtonPos.Y + SonButtonPos.Height)
            {
                SonButtonSurvol = true;
            }
            else { SonButtonSurvol = false; }

            if (souris.LeftButton == ButtonState.Pressed)
            {
                if (backInGameSurvol)
                    backInGameBol = true;
                else
                    backInGameBol = false;

                if (niveauSuivantSurvol)
                    niveauSuivantBol = true;
                else
                    niveauSuivantBol = false;

                if (menuPrincipalSurvol)
                    menuPrincipalBol = true;
                else
                    menuPrincipalBol = false;

                if (SonButtonSurvol)
                    SonButtonBol = true;
                else
                    SonButtonBol = false;
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
            if (backInGameBol && souris.LeftButton == ButtonState.Released)
            {
                base.screenManagerstock.Pop(1);
            }
            if (menuPrincipalBol && souris.LeftButton == ButtonState.Released)
            {
                base.screenManagerstock.mainMenu();
            }
            if (SonButtonBol && souris.LeftButton == ButtonState.Released)
            {
                setting.SonActive = !setting.SonActive;
                localSettings.Values["SonActive"] = setting.SonActive;
                SonButtonBol = false;
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            screenManagerstock.drawBeforeScreen(spriteBatch);
            spriteBatch.Begin();
            spriteBatch.Draw(backgroundDark, backgroundDarkPos, Color.White * 0.5f);

            #region Affichage des boutons            
            if (backInGameSurvol)
                spriteBatch.Draw(backInGameA, backInGamePos, Color.White);
            else
                spriteBatch.Draw(backInGame, backInGamePos, Color.White);
            
            if (niveauSuivantSurvol)
                spriteBatch.Draw(niveauSuivantA, niveauSuivantPos, Color.White);
            else
                spriteBatch.Draw(niveauSuivant, niveauSuivantPos, Color.White);
            
            if (menuPrincipalSurvol)
                spriteBatch.Draw(menuPrincipalA, menuPrincipalPos, Color.White);
            else
                spriteBatch.Draw(menuPrincipal, menuPrincipalPos, Color.White);

            if (setting.SonActive)
                spriteBatch.Draw(SonButtonOn, SonButtonPos, Color.White);
            else
                spriteBatch.Draw(SonButtonOff, SonButtonPos, Color.White);
            #endregion

            if (bouttonCliquer)
                spriteBatch.Draw(sceptre, new Rectangle(0, 0, 50, 50), Color.White);
            spriteBatch.Draw(sceptre, sourisCol, Color.White);
            spriteBatch.End();
        }
    }
}
