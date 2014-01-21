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
using Windows.UI.ViewManagement;

namespace Magic___Scroll.Screens
{
    public class SnappedIsNotAllowed : Screen
    {
        Game1 game;
        int screenHeight;
        int screenWidth;
        SpriteFont showCardFont;
        Texture2D fond;

        public SnappedIsNotAllowed(Game1 game, ScreenManager screenManager)
            : base(screenManager)
        {
            this.game = game;
            screenManager = new ScreenManager(game.Content);
        }
        public override void Initialize()
        {
            screenHeight = game.Window.ClientBounds.Height;
            screenWidth = game.Window.ClientBounds.Width;
        }
        public override void LoadContent(ContentManager content)
        {
            showCardFont = content.Load<SpriteFont>("50ShowCard");
            fond = content.Load<Texture2D>("ElementsMenu/Menu Portrait");
        }

        public override void Update(GameTime gameTime)
        {
            if (ApplicationView.Value != ApplicationViewState.Snapped)
            {
                screenManagerstock.Pop(1);
            }
        }

        public override void Draw(Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(fond, new Rectangle(0, 0, screenWidth, screenHeight), Color.White);
            spriteBatch.DrawString(showCardFont, "Vue en", new Vector2(0,(screenHeight/2) - 175), Color.Blue);
            spriteBatch.DrawString(showCardFont, "mode", new Vector2(0, (screenHeight / 2) - 115), Color.Blue);
            spriteBatch.DrawString(showCardFont, "Snapped", new Vector2(0, (screenHeight / 2) - 55), Color.Blue);
            spriteBatch.DrawString(showCardFont, "non pris", new Vector2(0, (screenHeight / 2) + 5), Color.Blue);
            spriteBatch.DrawString(showCardFont, "en charge", new Vector2(0, (screenHeight / 2) + 65), Color.Blue);
            spriteBatch.End();
        }
    }
}

