using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Magic___Scroll.Elements_Interactif
{
    class Souris
    {
       

         Texture2D t_Sprite;
         Rectangle col { get; set; }
         Rectangle rect { get; set; }
         public Souris()
         {

         }
        public void LoadContent(ContentManager Content)
        {

            t_Sprite = Content.Load<Texture2D>("Ronce");
        }

        public void Update(GameTime gameTime)
        {       
            

                rect = new Rectangle(Mouse.GetState().X, Mouse.GetState().Y, 50, 50);
                col = new Rectangle(Mouse.GetState().X, Mouse.GetState().Y, 50, 50);
            

            // TODO: Add your update logic here


        }

        public void Draw(SpriteBatch spriteBatch)
        {
 

            spriteBatch.Begin();
            spriteBatch.Draw(t_Sprite, rect, Color.White);
            spriteBatch.End();


        }
    }
}