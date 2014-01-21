using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Magic___Scroll
{
    class Animation
    {
        Texture2D textureAnimation;
        string textureAnimationNom;
        int nombreDeTextX, nombreDeTextY;
        int imgDepartY;
        int imagePerSec;
        public bool AnimActived { get; set; }
        TimeSpan lastUpdate;
        Rectangle tailleImageBase, Affichage;
        int indexOfText;

        public Animation(bool actived, string textureAnimationNom, Rectangle Affichage/*(int originX, int originY, int tailleX, int tailleY)*/, int nombreDeTextX, int nombreDeTextY, int imgDepartY = 1, int imageParSec = 4)
        {
            this.textureAnimationNom = textureAnimationNom;
            this.nombreDeTextX = nombreDeTextX;
            this.nombreDeTextY = nombreDeTextY;
            this.imgDepartY = imgDepartY;
            AnimActived = actived;
            this.Affichage = Affichage;
            this.imagePerSec = imageParSec;
            indexOfText = 0;
        }
        public void ReInitialize()
        {
            tailleImageBase.X = 0;
            indexOfText = 0;
        }
        public void LoadContent(ContentManager content)
        {
            textureAnimation = content.Load<Texture2D>(textureAnimationNom);
            tailleImageBase = new Rectangle(0, (textureAnimation.Height / nombreDeTextY) * (imgDepartY - 1), textureAnimation.Width / nombreDeTextX, textureAnimation.Height / nombreDeTextY);
        }
        public void Update(GameTime gameTime, Rectangle Affich)
        {
            this.Affichage = Affich;
            if (AnimActived)
            {
                if (gameTime.TotalGameTime.Subtract(lastUpdate).Milliseconds >= (1000/imagePerSec))
                {
                    if (indexOfText < nombreDeTextX-1)
                    {
                        tailleImageBase.X += tailleImageBase.Width;
                        indexOfText++;
                    }
                    else
                    {
                        AnimActived = false;
                        tailleImageBase.X = 0;
                        indexOfText = 0;
                    }
                    lastUpdate = gameTime.TotalGameTime;
                }
            }
        }
        public void Draw(SpriteBatch spritebatch)
        {
            spritebatch.Draw(textureAnimation, Affichage, tailleImageBase, Color.White);
        }
        public void DrawLastImage(SpriteBatch spritebatch)
        {
            spritebatch.Draw(textureAnimation, Affichage, new Rectangle(tailleImageBase.Width*(nombreDeTextX-1), tailleImageBase.Y, tailleImageBase.Width, tailleImageBase.Height), Color.White);
        }
    }
}
