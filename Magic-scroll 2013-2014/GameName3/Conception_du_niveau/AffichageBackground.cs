using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Magic___Scroll.Conception_du_niveau;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Magic___Scroll.Conception_du_niveau
{
    class AffichageBackground
    {
        Background1Fond background1fond;
        Background1Plan background1plan;
        Background2Fond background2fond;
        Background2Plan background2plan;
        Background3Fond background3fond;
        Setting setting;
        Texture2D nuage1, nuage2, nuage3;
        
        public Rectangle nuage1Rect, nuage2Rect, nuage3Rect;

        public AffichageBackground(int tailleEcranHauteur, int tailleEcranLargeur, int _ValeurSol)
        {
            setting = Setting.getInstance();
            background1fond = new Background1Fond(tailleEcranHauteur, tailleEcranLargeur, setting.currentWorld,_ValeurSol);
            background1plan = new Background1Plan(tailleEcranHauteur, tailleEcranLargeur, setting.currentWorld,_ValeurSol);
            background2fond = new Background2Fond(tailleEcranHauteur, tailleEcranLargeur, setting.currentWorld,_ValeurSol);
            background2plan = new Background2Plan(tailleEcranHauteur);
            background3fond = new Background3Fond(tailleEcranHauteur);

        }

        public void Initialize(Perso personnage,Game game)
        {
            background2plan.ay -= (personnage.Y - (game.Window.ClientBounds.Height / 2));
            background1plan.y -= (personnage.Y - (game.Window.ClientBounds.Height/2));
            background1fond.y -= (personnage.Y - (game.Window.ClientBounds.Height/2));
            background2fond.__y -= (personnage.Y - (game.Window.ClientBounds.Height/2));
            background3fond.by -= (personnage.Y - (game.Window.ClientBounds.Height/2));
            nuage1Rect.Y -= (personnage.Y - (game.Window.ClientBounds.Height/2));
            nuage2Rect.Y -= (personnage.Y - (game.Window.ClientBounds.Height/2));
            nuage3Rect.Y -= (personnage.Y - (game.Window.ClientBounds.Height/2));

            background2plan.ax -= (personnage.X - (game.Window.ClientBounds.Width/2));
            background1plan.x -= (personnage.X - (game.Window.ClientBounds.Width/2));
            background1fond.x -= (personnage.X - (game.Window.ClientBounds.Width/2));
            background2fond.__x -= (personnage.X - (game.Window.ClientBounds.Width/2));
            background3fond.bx -= (personnage.X - (game.Window.ClientBounds.Width/2));
            nuage1Rect.X -= (personnage.X - (game.Window.ClientBounds.Width / 2));
            nuage2Rect.X -= (personnage.X - (game.Window.ClientBounds.Width / 2));
            nuage3Rect.X -= (personnage.X - (game.Window.ClientBounds.Width / 2));
        }

        public void LoadContent(ContentManager Content)
        {
            nuage1 = Content.Load<Texture2D>("Background/Nuage1");
            nuage2 = Content.Load<Texture2D>("Background/Nuage2");
            nuage3 = Content.Load<Texture2D>("Background/Nuage3");

            


            background1fond.LoadContent(Content);
            background1plan.LoadContent(Content);
            background2fond.LoadContent(Content);
            //background2plan.LoadContent(Content);
            //background3fond.LoadContent(Content);

            nuage1Rect = new Rectangle(0, 50, nuage1.Width/2, nuage1.Height/2);
            nuage2Rect = new Rectangle(0, 65, nuage2.Width / 2, nuage2.Height / 2);
            nuage2Rect = new Rectangle(0, 80, nuage3.Width / 2, nuage3.Height / 2);
        }
        public void vaADroite(int speed)
        {
            //background2plan.ax -= (speed + 2); //Herbe derrière
            background1plan.x -= (speed + 2); //Herbe devant
            background1fond.x -= (speed); //Arbre Milieu
            background2fond.__x -= (speed+1); //Arbre Devant
            background1plan.rectp1.X -= (speed+2);
            background2fond.rectf2.X -= (speed + 1);
            background1fond.rectf1.X -= (speed);
            nuage1Rect.X -= speed;
            nuage2Rect.X -= speed;
            nuage3Rect.X -= speed;
            //background3fond.bx -= (speed); //Arbre de fond
        }
        public void vaAGauche(int speed)
        {
            //background2plan.ax += (speed + 2); //Herbe derrière
            background1plan.x += (speed + 2); //Herbe devant
            background1fond.x += (speed ); //Arbre Milieu
            background2fond.__x += (speed + 1); //Arbre Devant
            background1plan.rectp1.X += (speed + 2);
            background2fond.rectf2.X += (speed + 1);
            background1fond.rectf1.X += (speed);
            nuage1Rect.X += speed;
            nuage2Rect.X += speed;
            nuage3Rect.X += speed;
            //background3fond.bx += (speed); //Arbre de fond
        }
        public void vaEnHaut(int speed)
        {
            background1plan.y -= (speed/2 ); //Herbe devant
            background1fond.y -= (speed /2); //Arbre Milieu
            background2fond.__y -= (speed /2); //Arbre Devant 
            nuage1Rect.Y -= speed;
            nuage2Rect.Y -= speed;
            nuage3Rect.Y -= speed;
        }
        public void vaEnBas(int speed)
        {            
            background1plan.y += (speed /2); //Herbe devant
            background1fond.y += (speed /2); //Arbre Milieu
            background2fond.__y += (speed /2); //Arbre Devant
            nuage1Rect.Y += speed;
            nuage2Rect.Y += speed;
            nuage3Rect.Y += speed;
        }

        public void Update(GameTime gameTime)
        {
            background1plan.Update(gameTime);
            background2fond.Update(gameTime);
            background1fond.Update(gameTime);

            nuage1Rect.X += 3;
            nuage2Rect.X += 2;
            nuage3Rect.X += 1;

            if (nuage1Rect.X >= 1920)
                nuage1Rect.X = -400;
            if (nuage2Rect.X >= 1920)
                nuage2Rect.X = -400;
            if (nuage3Rect.X >= 1920)
                nuage3Rect.X = -400;
        }

        public void Draw(SpriteBatch _spriteBatch)
        {
            _spriteBatch.Begin();
            _spriteBatch.Draw(nuage1, nuage1Rect, Color.White);
            _spriteBatch.Draw(nuage2, nuage2Rect, Color.White);
            _spriteBatch.Draw(nuage3, nuage3Rect, Color.White);
            background3fond.Draw(_spriteBatch);
            background1fond.Draw(_spriteBatch);
            background2fond.Draw(_spriteBatch);
            background2plan.Draw(_spriteBatch);
            background1plan.Draw(_spriteBatch);
            _spriteBatch.End();
        }
    }
}
