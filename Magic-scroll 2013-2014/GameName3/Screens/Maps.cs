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
using Magic___Scroll.Elements_Interactif;
using Magic___Scroll.Sortilege;

namespace Magic___Scroll.Screens
{
    public class Maps : Screen
    {
        Game1 game;
        KeyboardState keyboard;
        MouseState souris;
        miniMap miniMap;
        bool keybUsed;
        Perso _perso;

        public Maps(Game1 game, ScreenManager screenManager, miniMap miniMap, Perso _perso)
            : base(screenManager)
        {
            this.game = game;
            this.miniMap = miniMap;
            this._perso = _perso;
            screenManager = new ScreenManager(game.Content);
        }
        public override void Initialize()
        {
            keybUsed = false;
            base.Initialize();
        }
        public override void LoadContent(ContentManager content)
        {

        }

        public override void Update(GameTime gameTime)
        {
            miniMap.Update(gameTime, _perso.coordAbsolute);
            keyboard = Keyboard.GetState();
            souris = Mouse.GetState();

            if (keyboard.IsKeyDown(Keys.M))
            {
                keybUsed = true;
            }
            if (keybUsed && keyboard.IsKeyUp(Keys.M))
            {
                screenManagerstock.Pop(1);
                keybUsed = false;
            }
        }

        public override void Draw(Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch)
        {
            screenManagerstock.drawBeforeScreen(spriteBatch);
            //spriteBatch.Begin();
            miniMap.Draw(spriteBatch);

            //spriteBatch.End();
        }
    }
}
