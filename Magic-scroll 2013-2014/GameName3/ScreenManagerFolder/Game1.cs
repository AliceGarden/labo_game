using System;
using System.Collections.Generic;
using System.Linq;
using Magic___Scroll.ScreenManagerFolder;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Windows.Storage;

namespace Magic___Scroll
{
    /// <summary>
    /// Type principal pour votre jeu
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        public GraphicsDeviceManager graphics { get; set; }
        SpriteBatch spriteBatch;
        ScreenManager screenManager;
        SpriteFont test;
        float elapsedTime;
        int frameCounter;
        int FPS;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            //  graphics.PreferredBackBufferHeight;
            //  graphics.PreferredBackBufferWidth;
            //graphics.IsFullScreen = true;
            //graphics.GraphicsDevice.Viewport.Height
        }

        /// <summary>
        /// Permet au jeu d’effectuer l’initialisation nécessaire pour l’exécution.
        /// Il peut faire appel aux services et charger tout contenu
        /// non graphique. Calling base.Initialize énumère les composants
        /// et les initialise.
        /// </summary>
        protected override void Initialize()
        {
            elapsedTime = 0;
            frameCounter = 0;
            // TODO: Ajouter votre logique d’initialisation ici
            base.Initialize();
        }

        /// <summary>
        /// LoadContent est appelé une fois par partie. Emplacement de chargement
        /// de tout votre contenu.
        /// </summary>
        protected override void LoadContent()
        {
            // Créer un SpriteBatch, qui peut être utilisé pour dessiner des textures.
            test = Content.Load<SpriteFont>("ArialFont");
            spriteBatch = new SpriteBatch(GraphicsDevice);
            screenManager = new ScreenManager(Content);
            screenManager.Push(new Screens.LoadingScreen(this, screenManager));
            /*screenManager.Push(new Magic___Scroll.Jeu(this, screenManager));*/

            // TODO: utilisez this.Content pour charger votre contenu de jeu ici
        }

        /// <summary>
        /// UnloadContent est appelé une fois par partie. Emplacement de déchargement
        /// de tout votre contenu.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Déchargez le contenu non ContentManager ici
        }

        /// <summary>
        /// Permet au jeu d’exécuter la logique de mise à jour du monde,
        /// de vérifier les collisions, de gérer les entrées et de lire l’audio.
        /// </summary>
        /// <param name="gameTime">Fournit un aperçu des valeurs de temps.</param>
        protected override void Update(GameTime gameTime)
        {
            // Permet au jeu de se fermer
            /*if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();*/
            elapsedTime += (float)gameTime.ElapsedGameTime.TotalSeconds;
            frameCounter++;
            if (elapsedTime > 1)
            {
                FPS = frameCounter;
                frameCounter = 0;
                elapsedTime = 0;
            }
            // TODO: Ajoutez votre logique de mise à jour ici
            screenManager.Update(gameTime);
            base.Update(gameTime);
        }

        /// <summary>
        /// Appelé quand le jeu doit se dessiner.
        /// </summary>
        /// <param name="gameTime">Fournit un aperçu des valeurs de temps.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Ajoutez votre code de dessin ici
            screenManager.Draw(spriteBatch);
            spriteBatch.Begin();
            //spriteBatch.DrawString(test, "FPS: " + FPS.ToString(), new Vector2(0, 0), Color.Yellow);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
