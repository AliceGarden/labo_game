using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Magic___Scroll.ScreenManagerFolder;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Windows.Storage;

namespace Magic___Scroll.Screens
{
    public class Menu : Screen
    {
        Game1 game;
        KeyboardState keyboard;
        Texture2D background, Play, Succes, Options, sceptre;
        Rectangle playPos, succesPos, optionPos;
        MouseState souris;
        Rectangle sourisCol;

        ApplicationDataContainer localSettings = ApplicationData.Current.LocalSettings;

        SpriteFont ArialFont;
        SpriteFont showcardFont;

        Setting setting;
        int screenHeight;
        int screenWidth;
        bool bouttonCliquer;
        bool launchJeu, launchSucces, launchOptions;

        public Menu(Game1 game, ScreenManager screenManager) : base(screenManager)
        {
            setting = Setting.getInstance();
            this.game = game;
            screenManager = new ScreenManager(game.Content);
        }
        public override void Initialize()
        {
            setting.currentWorld = 1;
            setting.currentLevel = 0;
            
            screenHeight = game.Window.ClientBounds.Height;
            screenWidth = game.Window.ClientBounds.Width;
            sourisCol = new Rectangle();
            playPos = new Rectangle();
            succesPos = new Rectangle();
            optionPos = new Rectangle();
        }
        public override void LoadContent(Microsoft.Xna.Framework.Content.ContentManager content)
        {
            background = content.Load<Texture2D>("ElementsMenu/Menu Paysage");
            Play = content.Load<Texture2D>("ElementsMenu/menuBouton");
            Options = content.Load<Texture2D>("ElementsMenu/menuBouton");
            Succes = content.Load<Texture2D>("ElementsMenu/menuBouton");
            sceptre = content.Load<Texture2D>("RouePouvoir-Sceptre/Sceptre");
            ArialFont = content.Load<SpriteFont>(@"ArialFont");
            showcardFont = content.Load<SpriteFont>(@"ShowCard");
        }

        public override void Update(GameTime gameTime)
        {
            keyboard = Keyboard.GetState();
            
            bouttonCliquer = false;
            souris = Mouse.GetState();
            sourisCol = new Rectangle(souris.X, souris.Y, 50, 50);
            optionPos = new Rectangle((screenWidth / 2) - (Options.Width / 2), (screenHeight / 2) + (Play.Height / 2) + 50, Options.Width, Options.Height);
            succesPos = new Rectangle((screenWidth / 2) - (Succes.Width / 2), (screenHeight / 2) + (Play.Height / 2) + Options.Height + 100, Succes.Width, Succes.Height);
            playPos = new Rectangle((screenWidth / 2) - (Play.Width / 2), (screenHeight / 2) - (Play.Height / 2), Play.Width, Play.Height);
            
            if (keyboard.IsKeyDown(Keys.Space))
            {
                base.screenManagerstock.Push(new Jeu(game, base.screenManagerstock));
            }
            if (keyboard.IsKeyDown(Keys.Escape))
            {
                game.Exit();
            }
            if ((int)localSettings.Containers["Perso"].Values["Sexe"] == 0)
            {
                launchOptions = true;
            }
            if (souris.LeftButton == ButtonState.Pressed)
            {
                if (souris.X >= playPos.X && souris.X <= playPos.X + playPos.Width && souris.Y >= playPos.Y && souris.Y <= playPos.Y + playPos.Height)
                {
                    launchJeu = true;
                }
                else { launchJeu = false; }
                if (souris.X >= optionPos.X && souris.X <= optionPos.X + optionPos.Width && souris.Y >= optionPos.Y && souris.Y <= optionPos.Y + optionPos.Height)
                {
                    launchOptions = true;
                }
                else { launchOptions = false; }
                if (souris.X >= succesPos.X && souris.X <= succesPos.X + succesPos.Width && souris.Y >= succesPos.Y && souris.Y <= succesPos.Y + succesPos.Height)
                {
                    launchSucces = true;
                }
                else { launchSucces = false; }
            }
            if (launchJeu && souris.LeftButton == ButtonState.Released)
            {
                launchJeu = false;
                base.screenManagerstock.Push(new ChoixMonde(game, base.screenManagerstock,2));
            }
            if (launchOptions && souris.LeftButton == ButtonState.Released)
            {
                launchOptions = false;
                base.screenManagerstock.Push(new OptionsMenu(game, base.screenManagerstock));
            }
        }

        public override void Draw(Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(background, new Rectangle(0, 0, screenWidth, screenHeight), Color.White);
            if (launchJeu)
            {
                spriteBatch.Draw(Play, playPos, Color.Blue);
                spriteBatch.DrawString(showcardFont, "Play", new Vector2(playPos.X + ((playPos.Width - ("Play".Length * 16)) / 2), playPos.Y + (10)), Color.White);
            }
            else
            {
                spriteBatch.Draw(Play, playPos, Color.White);
                spriteBatch.DrawString(showcardFont, "Play", new Vector2(playPos.X + ((playPos.Width - ("Play".Length * 16)) / 2), playPos.Y + (10)), Color.Blue);
            }
            if (launchOptions)
            {
                spriteBatch.Draw(Options, optionPos, Color.Blue);
                spriteBatch.DrawString(showcardFont, "Options", new Vector2(optionPos.X + ((optionPos.Width - ("Options".Length * 16)) / 2), optionPos.Y + (10)), Color.White);
            }
            else
            {
                spriteBatch.Draw(Options, optionPos, Color.White);
                spriteBatch.DrawString(showcardFont, "Options", new Vector2(optionPos.X + ((optionPos.Width - ("Options".Length * 16)) / 2), optionPos.Y + (10)), Color.Blue);
            }
            if (launchSucces)
            {
                spriteBatch.Draw(Succes, succesPos, Color.Blue);
                spriteBatch.DrawString(showcardFont, "Bonus", new Vector2(succesPos.X + ((succesPos.Width - ("Bonus".Length * 16)) / 2), succesPos.Y + (10)), Color.White);
            }
            else
            {
                spriteBatch.Draw(Succes, succesPos, Color.White);
                spriteBatch.DrawString(showcardFont, "Bonus", new Vector2(succesPos.X + ((succesPos.Width - ("Bonus".Length * 16)) / 2), succesPos.Y + (10)), Color.Blue);
            }
            if (bouttonCliquer)
                spriteBatch.Draw(sceptre, new Rectangle(0, 0, 50, 50), Color.White);

            spriteBatch.DrawString(ArialFont, "© Copyright 2013 Magic Scrolls Team", new Vector2((game.GraphicsDevice.Viewport.Width) - (("© Copyright 2013 Magic Scrolls Team".Length * 10)), game.GraphicsDevice.Viewport.Height - 30), Color.Yellow);

            spriteBatch.Draw(sceptre, sourisCol, Color.White);
            spriteBatch.End();
        }
    }
}
