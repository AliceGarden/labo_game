using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;

namespace Magic___Scroll.ScreenManagerFolder
{
    public abstract class Screen
    {
        public ScreenManager screenManagerstock;
        public Screen(ScreenManager screenManager)
        {
            screenManagerstock = screenManager;
        }
        public virtual void Initialize()
        {

        }
        public virtual void Update(GameTime gameTime)
        {

        }
        public virtual void Draw(SpriteBatch spriteBatch /*, GameTime gameTime*/)
        {

        }

        public virtual void LoadContent(ContentManager content)
        {

        }
    }
}