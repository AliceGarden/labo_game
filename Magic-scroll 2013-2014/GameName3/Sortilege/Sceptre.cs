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
    class Sceptre
    {
        Texture2D t_sprite;
        Texture2D t_spriteE, t_spriteF, t_spriteT, t_spriteV;
        public Animation animSceptreE, animSceptreF, animSceptreT, animSceptreV;
        
        Rectangle rect {get; set;}
        public Rectangle coll;
        Color couleurDelElementCorrespondant;

        public Sceptre()
        {
            rect = new Rectangle(Mouse.GetState().X, Mouse.GetState().Y, 50, 50);
            coll = new Rectangle(Mouse.GetState().X, Mouse.GetState().Y, 10, 10);
            animSceptreE = new Animation(false, "RouePouvoir-Sceptre/Sprite Sceptre (E)", rect, 6, 1, 1, 8);
            animSceptreF = new Animation(false, "RouePouvoir-Sceptre/Sprite Sceptre (F)", rect, 6, 1, 1, 8);
            animSceptreT = new Animation(false, "RouePouvoir-Sceptre/Sprite Sceptre (T)", rect, 6, 1, 1, 8);
            animSceptreV = new Animation(false, "RouePouvoir-Sceptre/Sprite Sceptre (V)", rect, 6, 1, 1, 8);
        }

        public void LoadContent(ContentManager Content)
        {
            t_sprite = Content.Load<Texture2D>("RouePouvoir-Sceptre/Sceptre");
            t_spriteE = Content.Load<Texture2D>("RouePouvoir-Sceptre/Sceptre(eau)");
            t_spriteF = Content.Load<Texture2D>("RouePouvoir-Sceptre/Sceptre(feu)");
            t_spriteT = Content.Load<Texture2D>("RouePouvoir-Sceptre/Sceptre(terre)");
            t_spriteV = Content.Load<Texture2D>("RouePouvoir-Sceptre/Sceptre(vent)");
            animSceptreE.LoadContent(Content);
            animSceptreF.LoadContent(Content);
            animSceptreT.LoadContent(Content);
            animSceptreV.LoadContent(Content);
        }

        public void Update(GameTime gameTime)
        {
            rect = new Rectangle(Mouse.GetState().X,Mouse.GetState().Y, 50, 50);
            coll = new Rectangle(Mouse.GetState().X, Mouse.GetState().Y, 10, 10);
            if(animSceptreE.AnimActived)
                animSceptreE.Update(gameTime, rect);
            if (animSceptreF.AnimActived) 
                animSceptreF.Update(gameTime, rect);
            if (animSceptreT.AnimActived) 
                animSceptreT.Update(gameTime, rect);
            if (animSceptreV.AnimActived) 
                animSceptreV.Update(gameTime, rect);
        }

        public void Update(GameTime gameTime, Point parcheminPos)
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (couleurDelElementCorrespondant == Color.Red && !animSceptreF.AnimActived)
            {
                spriteBatch.Draw(t_spriteF, rect, Color.White);
            }
            else if (couleurDelElementCorrespondant == Color.Blue && !animSceptreE.AnimActived)
            {
                spriteBatch.Draw(t_spriteE, rect, Color.White);

            }
            else if (couleurDelElementCorrespondant == Color.Green && !animSceptreT.AnimActived)
            {
                spriteBatch.Draw(t_spriteT, rect, Color.White);

            }
            else if (couleurDelElementCorrespondant == Color.Yellow && !animSceptreV.AnimActived)
            {
                spriteBatch.Draw(t_spriteV, rect, Color.White);
            }
            else if (animSceptreE.AnimActived)
            {
                animSceptreE.Draw(spriteBatch);
            }
            else if (animSceptreF.AnimActived)
            {
                animSceptreF.Draw(spriteBatch);
            }
            else if (animSceptreT.AnimActived)
            {
                animSceptreT.Draw(spriteBatch);
            }
            else if (animSceptreV.AnimActived)
            {
                animSceptreV.Draw(spriteBatch);
            }
            else spriteBatch.Draw(t_sprite, rect, Color.White);
        }

        public void changerSceptre(Color color)
        {
            couleurDelElementCorrespondant = color;
        }
    }
}
