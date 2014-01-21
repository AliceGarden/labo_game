using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Magic___Scroll.Screens;

namespace Magic___Scroll.ScreenManagerFolder
{
    public class ScreenManager
    {
        List<Screen> screenStack = new List<Screen>();
        ContentManager content;
        GameTime gameTime;
        public ScreenManager(ContentManager _content)
        {
            this.content = _content;
        }

        public void Push(Screen newScreen)
        {
            screenStack.Add(newScreen);
            screenStack.Last().Initialize();
            screenStack.Last().LoadContent(this.content);
            Update(gameTime);
        }
        public void Pop()
        {
            screenStack.Remove(screenStack.Last());
        }
        public void relaunch(Screen newScreen)
        {
            screenStack.Remove(screenStack.Last());
            screenStack.Add(newScreen);
            screenStack.Last().Initialize();
            screenStack.Last().LoadContent(this.content);
            Update(gameTime);
        }
        public void Pop(int n)
        {
            for (int i = 0; i < n; i++)
                Pop();
        }

        public void Update(GameTime gameTime)
        {
            this.gameTime = gameTime;
            screenStack.Last().Update(gameTime);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            screenStack.Last().Draw(spriteBatch);
        }

        public void drawBeforeScreen(SpriteBatch spriteBatch)
        {
            screenStack[screenStack.Count - 2].Draw(spriteBatch);
        }

        public void mainMenu()
        {
            int index = screenStack.Count - 1;
            bool verified = false;
            while (index > 0 || !verified)
            {
                if (!(screenStack[index] is Magic___Scroll.Screens.Menu))
                    screenStack.Remove(screenStack.Last());
                else 
                    verified = true;
                index--;
            }
        }
    }
}