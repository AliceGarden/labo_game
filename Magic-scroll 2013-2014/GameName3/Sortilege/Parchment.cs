using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Magic___Scroll.Sortilege
{
    public class Parchment
    {
        public int type;
        public Rectangle rect;
        Texture2D texture;
        int screenHeightQuad;
        int screenWidthQuad;
        public int X;
        public int Y;
        bool descend;
        int indexDeplacement;
        TimeSpan tempsDeRelance;
        public Vector2 coordPositionAbsolu;

        public Parchment(int typeOfParchement, int X, int Y, int screenHeightQuad, int screenWidthQuad, Vector2 coordPositionAbsolu)
        {
            this.type = 0;
            if (typeOfParchement.GetHashCode() == '6'.GetHashCode())
                this.type = 1;
            if (typeOfParchement.GetHashCode() == '7'.GetHashCode())
                this.type = 2;
            if (typeOfParchement.GetHashCode() == '8'.GetHashCode())
                this.type = 3;
            if (typeOfParchement.GetHashCode() == '9'.GetHashCode())
                this.type = 4;
            this.X = X;
            this.Y = Y;
            rect = new Rectangle(X + (screenHeightQuad / 3), Y, (2 * screenHeightQuad) / 3, (2 * screenHeightQuad) / 3);
            this.screenHeightQuad = screenHeightQuad;
            this.screenWidthQuad = screenWidthQuad;
            this.coordPositionAbsolu = coordPositionAbsolu;
            tempsDeRelance = new TimeSpan();
            indexDeplacement = new Random(type * X * Y).Next(-8, 8);
        }

        public void LoadContent(ContentManager content)
        {
            if (type == 1)
                texture = content.Load<Texture2D>("Parchemin/Eau");
            if (type == 2)
                texture = content.Load<Texture2D>("Parchemin/Feu");
            if (type == 3)
                texture = content.Load<Texture2D>("Parchemin/Terre");
            if (type == 4)
                texture = content.Load<Texture2D>("Parchemin/Air");
        }

        public void Update(GameTime gameTime)
        {
            if (gameTime.TotalGameTime.Subtract(tempsDeRelance).Milliseconds >= 100)
            {
                if (indexDeplacement >= 8)
                    descend = false;
                if (indexDeplacement <= -8)
                    descend = true;
                if (descend)
                    indexDeplacement++;
                else indexDeplacement--;
                tempsDeRelance = gameTime.TotalGameTime;
            }
            rect.X = X;
            rect.Y = Y + indexDeplacement;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            //spriteBatch.End();
            spriteBatch.Begin();
            spriteBatch.Draw(texture, rect, Color.White);
            spriteBatch.End();
        }

        public bool modifNbParchemin(Rectangle persoCol)
        {
            bool i = false;
            if (rect.Intersects(persoCol))
            {
                i = true;
            }
            return i;
        }

        public void LoadTexture(Texture2D texture)
        {
            this.texture = texture;
        }
    }

    public class AddParchment
    {
        public Texture2D Air, Feu, Eau, Terre;

        public AddParchment()
        {
        }

        public void LoadContent(ContentManager content)
        {
            Air = content.Load<Texture2D>("Parchemin/Air");
            Feu = content.Load<Texture2D>("Parchemin/Feu");
            Eau = content.Load<Texture2D>("Parchemin/Eau");
            Terre = content.Load<Texture2D>("Parchemin/Terre");
        }
    }
}
