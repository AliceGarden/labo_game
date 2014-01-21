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
    class OptionsMenu : Screen
    {
        Game1 game;
        KeyboardState keyboard;
        ApplicationDataContainer localSettings = ApplicationData.Current.LocalSettings;
        
        MouseState souris;
        Rectangle sourisCol;
        SpriteFont showcardFont;
        Texture2D Background, BackgroundFond, sceptre;
        
        Setting setting;
        int screenHeight;
        int screenWidth;
        
        bool bouttonCliquer;
        bool Activation_ChangementSexe = false;
        
        bool kbescape;

        public OptionsMenu(Game1 game, ScreenManager screenManager)
            : base(screenManager)
        {
            setting = Setting.getInstance();
            this.game = game;
            screenManager = new ScreenManager(game.Content);
        }
        public override void Initialize()
        {
            screenHeight = game.Window.ClientBounds.Height;
            screenWidth = game.Window.ClientBounds.Width;
            sourisCol = new Rectangle();
        }
        public override void LoadContent(ContentManager content)
        {
            showcardFont = content.Load<SpriteFont>("ShowCard");
            Background = content.Load<Texture2D>("ElementsMenu/backgroundOption");
            BackgroundFond = content.Load<Texture2D>("ElementsMenu/Menu Paysage");

            sceptre = content.Load<Texture2D>("RouePouvoir-Sceptre/Sceptre");
        }
        public override void Update(GameTime gameTime)
        {
            keyboard = Keyboard.GetState();
            souris = Mouse.GetState();
            bouttonCliquer = false;

            sourisCol = new Rectangle(souris.X, souris.Y, 50, 50);

            if (keyboard.IsKeyDown(Keys.Escape))
            {
                kbescape = true;
            }
            if (kbescape && keyboard.IsKeyUp(Keys.Escape))
            {
                screenManagerstock.Pop(1);
            }

            if (souris.LeftButton == ButtonState.Pressed)
            {
                if (souris.X >= ((screenWidth / 2) - (Background.Width / 2) + 55) && souris.X <= ((screenWidth / 2) - (Background.Width / 2) + 55 + 60) && souris.Y >= ((screenHeight / 2) - (Background.Height / 3) + 85) && souris.Y <= ((screenHeight / 2) - (Background.Height / 3) + 85 + 60))
                {
                    setting.Cheveux = 0;

                }
                if (souris.X >= ((screenWidth / 2) - (Background.Width / 2) + 155) && souris.X <= ((screenWidth / 2) - (Background.Width / 2) + 155 + 60) && souris.Y >= ((screenHeight / 2) - (Background.Height / 3) + 85) && souris.Y <= ((screenHeight / 2) - (Background.Height / 3) + 85 + 60))
                {
                    setting.Cheveux = 1;
                }
                if (souris.X >= ((screenWidth / 2) - (Background.Width / 2) + 255) && souris.X <= ((screenWidth / 2) - (Background.Width / 2) + 255 + 60) && souris.Y >= ((screenHeight / 2) - (Background.Height / 3) + 85) && souris.Y <= ((screenHeight / 2) - (Background.Height / 3) + 85 + 60))
                {
                    setting.Cheveux = 2;
                }


                if (souris.X >= ((screenWidth / 2) - (Background.Width / 2) + 55) && souris.X <= ((screenWidth / 2) - (Background.Width / 2) + 55 + 60) && souris.Y >= ((screenHeight / 2) - (Background.Height / 3) + 185) && souris.Y <= ((screenHeight / 2) - (Background.Height / 3) + 185 + 60))
                {
                    setting.Yeux = 0;
                }
                if (souris.X >= ((screenWidth / 2) - (Background.Width / 2) + 155) && souris.X <= ((screenWidth / 2) - (Background.Width / 2) + 155 + 60) && souris.Y >= ((screenHeight / 2) - (Background.Height / 3) + 185) && souris.Y <= ((screenHeight / 2) - (Background.Height / 3) + 185 + 60))
                {
                    setting.Yeux = 1;
                }
                if (souris.X >= ((screenWidth / 2) - (Background.Width / 2) + 255) && souris.X <= ((screenWidth / 2) - (Background.Width / 2) + 255 + 60) && souris.Y >= ((screenHeight / 2) - (Background.Height / 3) + 185) && souris.Y <= ((screenHeight / 2) - (Background.Height / 3) + 185 + 60))
                {
                    setting.Yeux = 2;
                }

                if (souris.X >= ((screenWidth / 2) - (Background.Width / 2) + 55) && souris.X <= ((screenWidth / 2) - (Background.Width / 2) + 55 + 60) && souris.Y >= ((screenHeight / 2) - (Background.Height / 3) + 285) && souris.Y <= ((screenHeight / 2) - (Background.Height / 3) + 285 + 60))
                {
                    setting.Peau = 0;
                }
                if (souris.X >= ((screenWidth / 2) - (Background.Width / 2) + 155) && souris.X <= ((screenWidth / 2) - (Background.Width / 2) + 155 + 60) && souris.Y >= ((screenHeight / 2) - (Background.Height / 3) + 285) && souris.Y <= ((screenHeight / 2) - (Background.Height / 3) + 285 + 60))
                {
                    setting.Peau = 1;
                }
                if (souris.X >= ((screenWidth / 2) - (Background.Width / 2) + 255) && souris.X <= ((screenWidth / 2) - (Background.Width / 2) + 255 + 60) && souris.Y >= ((screenHeight / 2) - (Background.Height / 3) + 285) && souris.Y <= ((screenHeight / 2) - (Background.Height / 3) + 285 + 60))
                {
                    setting.Peau = 2;
                }
                if (souris.X >= ((screenWidth / 2) + (Background.Width / 4)) - 50 && souris.X <= ((screenWidth / 2) + (Background.Width / 4) + 50) && souris.Y >= ((screenHeight / 2) - (Background.Height / 3) + 285) && souris.Y <= ((screenHeight / 2) - (Background.Height / 3) + 285 + 50))
                {
                    Activation_ChangementSexe = true;
                }

            }
                if (souris.LeftButton == ButtonState.Released && Activation_ChangementSexe)
                {
                    switch (setting.Sexe)
                    {
                        case 1:
                            setting.Sexe = 2;
                            break;
                        case 2:
                            setting.Sexe = 1;
                            break;
                        default:
                            setting.Sexe = 1;
                            break;
                    }
                    Activation_ChangementSexe = false;
                }

            
                localSettings.Containers["Perso"].Values["Cheveux"] = setting.Cheveux;
                localSettings.Containers["Perso"].Values["Yeux"] = setting.Yeux;
                localSettings.Containers["Perso"].Values["Peau"] = setting.Peau;
                localSettings.Containers["Perso"].Values["Sexe"] = setting.Sexe; 

            
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            Texture2D dummyTexture = new Texture2D(game.GraphicsDevice, 1, 1);
            dummyTexture.SetData(new[] { Color.White });
            spriteBatch.Begin();
            spriteBatch.Draw(BackgroundFond, new Rectangle(0, 0, screenWidth, screenHeight), Color.White);          
            spriteBatch.Draw(Background, new Rectangle((screenWidth / 2) - (Background.Width / 2), (screenHeight / 2) - (Background.Height / 2), Background.Width, Background.Height), Color.White);
            spriteBatch.DrawString(showcardFont, setting.Nom, new Vector2((screenWidth / 2) - (Background.Width / 3) + 15, (screenHeight / 2) - (Background.Height / 3)), Color.White);
            spriteBatch.DrawString(showcardFont, "OPTION", new Vector2((game.Window.ClientBounds.Width / 2) - ("OPTION".Length / 2) * 20, (screenHeight / 2) - (Background.Height / 2) + 15), Color.White);
            spriteBatch.DrawString(showcardFont, "Cheveux : " , new Vector2((screenWidth / 2) - (Background.Width / 2) + 25, (screenHeight / 2) - (Background.Height / 3) + 50), Color.White);
            if (setting.Cheveux == 0)
            {
                spriteBatch.Draw(dummyTexture, new Rectangle((screenWidth / 2) - (Background.Width / 2) + 55, (screenHeight / 2) - (Background.Height / 3) + 85, 60, 60), Color.Red);
            }
            else { spriteBatch.Draw(dummyTexture, new Rectangle((screenWidth / 2) - (Background.Width / 2) + 55, (screenHeight / 2) - (Background.Height / 3) + 85, 60, 60), Color.White); }
            if (setting.Cheveux == 1)
            {
                spriteBatch.Draw(dummyTexture, new Rectangle((screenWidth / 2) - (Background.Width / 2) + 155, (screenHeight / 2) - (Background.Height / 3) + 85, 60, 60), Color.Red);
            }
            else { spriteBatch.Draw(dummyTexture, new Rectangle((screenWidth / 2) - (Background.Width / 2) + 155, (screenHeight / 2) - (Background.Height / 3) + 85, 60, 60), Color.White); }
            if (setting.Cheveux == 2)
            {
                spriteBatch.Draw(dummyTexture, new Rectangle((screenWidth / 2) - (Background.Width / 2) + 255, (screenHeight / 2) - (Background.Height / 3) + 85, 60, 60), Color.Red);
            }
            else { spriteBatch.Draw(dummyTexture, new Rectangle((screenWidth / 2) - (Background.Width / 2) + 255, (screenHeight / 2) - (Background.Height / 3) + 85, 60, 60), Color.White); }

            spriteBatch.Draw(dummyTexture, new Rectangle((screenWidth / 2) - (Background.Width / 2) + 60, (screenHeight / 2) - (Background.Height / 3) + 90, 50, 50), Color.Orange);
            spriteBatch.Draw(dummyTexture, new Rectangle((screenWidth / 2) - (Background.Width / 2) + 160, (screenHeight / 2) - (Background.Height / 3) + 90, 50, 50), Color.Black);
            spriteBatch.Draw(dummyTexture, new Rectangle((screenWidth / 2) - (Background.Width / 2) + 260, (screenHeight / 2) - (Background.Height / 3) + 90, 50, 50), Color.Yellow);

            spriteBatch.DrawString(showcardFont, "Yeux : " , new Vector2((screenWidth / 2) - (Background.Width / 2) + 25, (screenHeight / 2) - (Background.Height / 3) + 150), Color.White);

            if(setting.Yeux == 0)
            {
                spriteBatch.Draw(dummyTexture, new Rectangle((screenWidth / 2) - (Background.Width / 2) + 55, (screenHeight / 2) - (Background.Height / 3) + 185, 60, 60), Color.Red);
            }
            else{spriteBatch.Draw(dummyTexture, new Rectangle((screenWidth / 2) - (Background.Width / 2) + 55, (screenHeight / 2) - (Background.Height / 3) + 185, 60, 60), Color.White);}
            if (setting.Yeux == 1)
            {
                spriteBatch.Draw(dummyTexture, new Rectangle((screenWidth / 2) - (Background.Width / 2) + 155, (screenHeight / 2) - (Background.Height / 3) + 185, 60, 60), Color.Red);
            }
            else { spriteBatch.Draw(dummyTexture, new Rectangle((screenWidth / 2) - (Background.Width / 2) + 155, (screenHeight / 2) - (Background.Height / 3) + 185, 60, 60), Color.White); }
            if (setting.Yeux == 2)
            {
                spriteBatch.Draw(dummyTexture, new Rectangle((screenWidth / 2) - (Background.Width / 2) + 255, (screenHeight / 2) - (Background.Height / 3) + 185, 60, 60), Color.Red);
            }
            else { spriteBatch.Draw(dummyTexture, new Rectangle((screenWidth / 2) - (Background.Width / 2) + 255, (screenHeight / 2) - (Background.Height / 3) + 185, 60, 60), Color.White); }

            spriteBatch.Draw(dummyTexture, new Rectangle((screenWidth / 2) - (Background.Width / 2) + 60, (screenHeight / 2) - (Background.Height / 3) + 190, 50, 50), Color.Blue);
            spriteBatch.Draw(dummyTexture, new Rectangle((screenWidth / 2) - (Background.Width / 2) + 160, (screenHeight / 2) - (Background.Height / 3) + 190, 50, 50), Color.Chocolate);
            spriteBatch.Draw(dummyTexture, new Rectangle((screenWidth / 2) - (Background.Width / 2) + 260, (screenHeight / 2) - (Background.Height / 3) + 190, 50, 50), Color.Green);

            spriteBatch.DrawString(showcardFont, "Peau : " , new Vector2((screenWidth / 2) - (Background.Width / 2) + 25, (screenHeight / 2) - (Background.Height / 3) + 250), Color.White);

            if (setting.Peau == 0)
            {
                spriteBatch.Draw(dummyTexture, new Rectangle((screenWidth / 2) - (Background.Width / 2) + 55, (screenHeight / 2) - (Background.Height / 3) + 285, 60, 60), Color.Red);
            }
            else { spriteBatch.Draw(dummyTexture, new Rectangle((screenWidth / 2) - (Background.Width / 2) + 55, (screenHeight / 2) - (Background.Height / 3) + 285, 60, 60), Color.White); }
            if (setting.Peau == 1)
            {
                spriteBatch.Draw(dummyTexture, new Rectangle((screenWidth / 2) - (Background.Width / 2) + 155, (screenHeight / 2) - (Background.Height / 3) + 285, 60, 60), Color.Red);
            }
            else { spriteBatch.Draw(dummyTexture, new Rectangle((screenWidth / 2) - (Background.Width / 2) + 155, (screenHeight / 2) - (Background.Height / 3) + 285, 60, 60), Color.White); }
            if (setting.Peau == 2)
            {
                spriteBatch.Draw(dummyTexture, new Rectangle((screenWidth / 2) - (Background.Width / 2) + 255, (screenHeight / 2) - (Background.Height / 3) + 285, 60, 60), Color.Red);
            }
            else { spriteBatch.Draw(dummyTexture, new Rectangle((screenWidth / 2) - (Background.Width / 2) + 255, (screenHeight / 2) - (Background.Height / 3) + 285, 60, 60), Color.White); }

            spriteBatch.Draw(dummyTexture, new Rectangle((screenWidth / 2) - (Background.Width / 2) + 60, (screenHeight / 2) - (Background.Height / 3) + 290, 50, 50), Color.White);
            spriteBatch.Draw(dummyTexture, new Rectangle((screenWidth / 2) - (Background.Width / 2) + 60, (screenHeight / 2) - (Background.Height / 3) + 290, 50, 50), Color.FromNonPremultiplied(255, 220, 200, 56));
            spriteBatch.Draw(dummyTexture, new Rectangle((screenWidth / 2) - (Background.Width / 2) + 160, (screenHeight / 2) - (Background.Height / 3) + 290, 50, 50), Color.White);
            spriteBatch.Draw(dummyTexture, new Rectangle((screenWidth / 2) - (Background.Width / 2) + 160, (screenHeight / 2) - (Background.Height / 3) + 290, 50, 50), Color.FromNonPremultiplied(238, 177, 121, 125));
            spriteBatch.Draw(dummyTexture, new Rectangle((screenWidth / 2) - (Background.Width / 2) + 260, (screenHeight / 2) - (Background.Height / 3) + 290, 50, 50), Color.White);
            spriteBatch.Draw(dummyTexture, new Rectangle((screenWidth / 2) - (Background.Width / 2) + 260, (screenHeight / 2) - (Background.Height / 3) + 290, 50, 50), Color.FromNonPremultiplied(96,51, 11, 227));       

            spriteBatch.Draw(dummyTexture, new Rectangle((screenWidth / 2) + (Background.Width / 4) - 50, (screenHeight / 2) - (Background.Height / 3) + 290, 100, 50), Color.White);
            spriteBatch.DrawString(showcardFont, "Sexe : " , new Vector2((screenWidth / 2) + (Background.Width / 4) - 50, (screenHeight / 2) - (Background.Height / 3) + 290), Color.Red);

            if (bouttonCliquer)
                spriteBatch.Draw(sceptre, new Rectangle(0, 0, 50, 50), Color.White);
            spriteBatch.Draw(sceptre, sourisCol, Color.White);

            
            spriteBatch.End();
        }
    }
}
