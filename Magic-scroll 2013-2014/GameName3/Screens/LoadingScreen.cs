using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Windows.Storage;
using Magic___Scroll.ScreenManagerFolder;
using Magic___Scroll.Screens;

namespace Magic___Scroll.Screens
{
    public class LoadingScreen : Screen
    {
        Game1 game;
        Setting setting;
        ApplicationDataContainer localSettings;
        StorageFolder localFolder;
        bool launchChargement, chargementFini;
        Texture2D background;
        SpriteFont fontText;

        public LoadingScreen(Game1 game, ScreenManager screenManager)
            : base(screenManager)
        {
            setting = Setting.getInstance();
            this.game = game;
            screenManager = new ScreenManager(game.Content);
            localSettings = ApplicationData.Current.LocalSettings;
            localFolder = ApplicationData.Current.LocalFolder;
        }
        public override void Initialize()
        {
            launchChargement = false;
            chargementFini = false;
        }
        public override void LoadContent(ContentManager content)
        {
            background = content.Load<Texture2D>("ElementsMenu/Menu Paysage");
            fontText = content.Load<SpriteFont>("50ShowCard");
        }

        public override void Update(GameTime gameTime)
        {
            if (launchChargement && !chargementFini)
            {
                #region Verification de la sauvegarde si elle n'existe pas on la recréer
                if (!localSettings.Containers.ContainsKey("ProgressionNiveau"))
                    localSettings.CreateContainer("ProgressionNiveau", ApplicationDataCreateDisposition.Always);
                if (!localSettings.Containers["ProgressionNiveau"].Containers.ContainsKey("0"))
                    localSettings.Containers["ProgressionNiveau"].CreateContainer("0", ApplicationDataCreateDisposition.Always);
                for (int levelSave = 1; levelSave < 6; levelSave++)
                {
                    if (!localSettings.Containers["ProgressionNiveau"].Containers["0"].Containers.ContainsKey(levelSave.ToString()))
                    {
                        localSettings.Containers["ProgressionNiveau"].Containers["0"].CreateContainer(levelSave.ToString(), ApplicationDataCreateDisposition.Always);
                        localSettings.Containers["ProgressionNiveau"].Containers["0"].Containers[levelSave.ToString()].Values["Finished"] = false;
                        localSettings.Containers["ProgressionNiveau"].Containers["0"].Containers[levelSave.ToString()].Values["Available"] = true;
                    }
                    if (localSettings.Containers["ProgressionNiveau"].Containers["0"].Containers[levelSave.ToString()].Values["Finished"] == null)
                        localSettings.Containers["ProgressionNiveau"].Containers["0"].Containers[levelSave.ToString()].Values["Finished"] = false;
                    if (localSettings.Containers["ProgressionNiveau"].Containers["0"].Containers[levelSave.ToString()].Values["Available"] == null)
                        localSettings.Containers["ProgressionNiveau"].Containers["0"].Containers[levelSave.ToString()].Values["Available"] = true;
                }
                localSettings.Containers["ProgressionNiveau"].Containers["0"].Containers["1"].Values["Available"] = true;
                for (int worldSave = 1; worldSave < 3; worldSave++)
                {
                    if (!localSettings.Containers["ProgressionNiveau"].Containers.ContainsKey(worldSave.ToString()))
                        localSettings.Containers["ProgressionNiveau"].CreateContainer(worldSave.ToString(), ApplicationDataCreateDisposition.Always);
                    for (int levelSave = 1; levelSave < 11; levelSave++)
                    {
                        if (!localSettings.Containers["ProgressionNiveau"].Containers[worldSave.ToString()].Containers.ContainsKey(levelSave.ToString()))
                        {
                            localSettings.Containers["ProgressionNiveau"].Containers[worldSave.ToString()].CreateContainer(levelSave.ToString(), ApplicationDataCreateDisposition.Always);
                            localSettings.Containers["ProgressionNiveau"].Containers[worldSave.ToString()].Containers[levelSave.ToString()].Values["Finished"] = false;
                            localSettings.Containers["ProgressionNiveau"].Containers[worldSave.ToString()].Containers[levelSave.ToString()].Values["Available"] = false;
                        }
                        if (localSettings.Containers["ProgressionNiveau"].Containers[worldSave.ToString()].Containers[levelSave.ToString()].Values["Finished"] == null)
                            localSettings.Containers["ProgressionNiveau"].Containers[worldSave.ToString()].Containers[levelSave.ToString()].Values["Finished"] = false;
                        if (localSettings.Containers["ProgressionNiveau"].Containers[worldSave.ToString()].Containers[levelSave.ToString()].Values["Available"] == null)
                            localSettings.Containers["ProgressionNiveau"].Containers[worldSave.ToString()].Containers[levelSave.ToString()].Values["Available"] = false;
                    }
                }
                localSettings.Containers["ProgressionNiveau"].Containers["1"].Containers["1"].Values["Available"] = true;

                if (!localSettings.Containers.ContainsKey("Perso"))
                    localSettings.CreateContainer("Perso", ApplicationDataCreateDisposition.Always);               
                if (localSettings.Containers["Perso"].Values["Cheveux"] == null)
                    localSettings.Containers["Perso"].Values["Cheveux"] = 1;
                if (localSettings.Containers["Perso"].Values["Yeux"] == null)
                    localSettings.Containers["Perso"].Values["Yeux"] = 1;
                if (localSettings.Containers["Perso"].Values["Peau"] == null)
                    localSettings.Containers["Perso"].Values["Peau"] = 1;
                if (localSettings.Containers["Perso"].Values["Sexe"] == null)
                    localSettings.Containers["Perso"].Values["Sexe"] = 0;
                if (localSettings.Containers["Perso"].Values["Nom"] == null)
                    localSettings.Containers["Perso"].Values["Nom"] = "ALICE";
                if (localSettings.Values["SonActive"] == null)
                    localSettings.Values["SonActive"] = true;
                #endregion

                #region Chargement de la sauvegarde
                setting.RealisationNivMonde = new List<List<bool>>();
                setting.DisponibiliteNivMonde = new List<List<bool>>();
                setting.RealisationNivMonde.Add(new List<bool>());
                setting.DisponibiliteNivMonde.Add(new List<bool>());
                for (int levelSave = 1; levelSave < 6; levelSave++)
                {
                    setting.RealisationNivMonde[0].Add((bool)localSettings.Containers["ProgressionNiveau"].Containers["0"].Containers[levelSave.ToString()].Values["Finished"]);
                    setting.DisponibiliteNivMonde[0].Add((bool)localSettings.Containers["ProgressionNiveau"].Containers["0"].Containers[levelSave.ToString()].Values["Available"]);
                }
                for (int worldSave = 1; worldSave < 3; worldSave++)
                {
                    setting.RealisationNivMonde.Add(new List<bool>());
                    setting.DisponibiliteNivMonde.Add(new List<bool>());
                    for (int levelSave = 1; levelSave < 11; levelSave++)
                    {
                        setting.RealisationNivMonde[worldSave].Add((bool)localSettings.Containers["ProgressionNiveau"].Containers[worldSave.ToString()].Containers[levelSave.ToString()].Values["Finished"]);
                        setting.DisponibiliteNivMonde[worldSave].Add((bool)localSettings.Containers["ProgressionNiveau"].Containers[worldSave.ToString()].Containers[levelSave.ToString()].Values["Available"]);
                    }
                }

                setting.Nom = (string)localSettings.Containers["Perso"].Values["Nom"];
                setting.Cheveux = (int)localSettings.Containers["Perso"].Values["Cheveux"];
                setting.Yeux = (int)localSettings.Containers["Perso"].Values["Yeux"];
                setting.Peau = (int)localSettings.Containers["Perso"].Values["Peau"];
                setting.Sexe = (int)localSettings.Containers["Perso"].Values["Sexe"];

                setting.SonActive = (bool)localSettings.Values["SonActive"];
                #endregion

                #region Cheat Finir tout le niveau
                //setting.RealisationNivMonde = new List<List<bool>>();
                //setting.DisponibiliteNivMonde = new List<List<bool>>();
                //setting.RealisationNivMonde.Add(new List<bool>());
                //setting.DisponibiliteNivMonde.Add(new List<bool>());
                //for (int levelSave = 1; levelSave < 6; levelSave++)
                //{
                //    setting.RealisationNivMonde[0].Add(true);
                //    setting.DisponibiliteNivMonde[0].Add(true);
                //}
                //for (int worldSave = 1; worldSave < 3; worldSave++)
                //{
                //    setting.RealisationNivMonde.Add(new List<bool>());
                //    setting.DisponibiliteNivMonde.Add(new List<bool>());
                //    for (int levelSave = 1; levelSave < 11; levelSave++)
                //    {
                //        setting.RealisationNivMonde[worldSave].Add(true);
                //        setting.DisponibiliteNivMonde[worldSave].Add(true);
                //    }
                //}
                #endregion

                chargementFini = true;
            }
            else
            {
                launchChargement = true;
                if(chargementFini)
                    base.screenManagerstock.Push(new Menu(game, base.screenManagerstock));
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(background, new Rectangle(0,0,game.GraphicsDevice.Viewport.Width, game.GraphicsDevice.Viewport.Height), Color.White * 0.8f);
            spriteBatch.DrawString(fontText, "Chargement", new Vector2((game.GraphicsDevice.Viewport.Width / 2) - ("Chargement".Length * 50), (game.GraphicsDevice.Viewport.Height / 2)), Color.Blue);
            spriteBatch.End();
        }
    }
}
