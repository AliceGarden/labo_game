using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Audio;

namespace Magic___Scroll.Elements_Interactif
{
    public class ElementInteractifGeneral
    {
        public bool ElementsIsActived { get; set; }
        public bool ElementsIsAltered { get; set; }
        public bool ElementsIsBloquant { get; set; }        
        public bool ElementsIsBase { get; set; }
        public bool gravityReady { get; set; }
        public bool EtatFinale { get; set; }
        public bool bottomCollisionIsTrue;
        public int x { get; set; }
        public int y { get; set; }
        public Rectangle rect { get; set; }
        public Rectangle col { get; set; }
        public Rectangle headCol { get; set; }
        public Rectangle bottomCol { get; set; }
		public Rectangle miniMapCoord { get; set; }
        public Vector2 coordPositionAbsolu { get; set; }
        public int screenHeight;
        public int screenWidth;
        public bool deleteElement = false;
        public bool parchmentToPop = false;
        protected int speed;
        private bool seDeplace;
        private int deplacementEnCours;
        private bool seDeplaceVersGauche;
        SoundEffect VentPousse; 

        public ElementInteractifGeneral(Vector2 coordPositionAbsolu)
        {
            this.coordPositionAbsolu = coordPositionAbsolu;
            speed = 4;
            x = new int();
            y = new int();
            screenWidth = new int();
            screenHeight = new int();
            ElementsIsActived = new bool();
            rect = new Rectangle(x, y, screenWidth, screenHeight);
            col = new Rectangle(x, y, screenWidth, screenHeight);
            bottomCol = new Rectangle(x, y + screenHeight - 10, screenWidth, 20);
            gravityReady = true;
            bottomCollisionIsTrue = true;
            seDeplace = false;
            seDeplaceVersGauche = false;
        }
        public virtual void LoadContent(ContentManager Content)
        {
            VentPousse = Content.Load<SoundEffect>("foretW");
        }

        public virtual void Update(GameTime gameTime)
        {
            if (gravityReady)
            {
                if (!bottomCollisionIsTrue)
                    y += (speed + 4);
            }
            if (seDeplace)
            {
                if (seDeplaceVersGauche)
                {
                    if ((-deplacementEnCours) < screenWidth)
                    {
                        deplacementEnCours -= 100;
                        x -= 100;
                    }
                    else seDeplace = false;
                }

                if (!seDeplaceVersGauche)
                {
                    if (deplacementEnCours < screenWidth)
                    {
                        deplacementEnCours += 100;
                        x += 100;
                    }
                    else seDeplace = false;
                }
            }
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            
        }

        public bool bottomCollision(List<Decor> _liste_decor_bottomCol)
        {
            bool collision = false;
            foreach (Decor d in _liste_decor_bottomCol)
            {
                if (bottomCol.Intersects(d.bottomcol))
                    collision = true;
            }
            return collision;
        }

        public virtual void actionFeu()
        {

        }
        public virtual void actionEau()
        {

        }
        public virtual void actionFeu(Perso p)
        {

        }
        public virtual void actionEau(Perso p)
        {

        }
        public virtual void actionTerre()
        {

        }
        public virtual void actionAir()
        {

        }
        public virtual void actionAir(Perso p)
        {

        }
        public virtual void actionAir(Perso p,List<Decor> liste_decor)
        {

        }
        protected void activerEtatSecondaire()
        {
            if (!ElementsIsActived)
            {
                ElementsIsActived = true;
            }
        }
        protected void desactiverEtatSecondaire()
        {
            if (ElementsIsActived)
            {
                ElementsIsActived = false;
            }
        }
        protected void supprimerElement()
        {
            ElementsIsActived = false;
            deleteElement = true;
        }
        protected void deplacementElement(Perso p)
        {
            deplacementEnCours = 0;
            seDeplace = true;
            if (p.rect.X < x)
            {
                seDeplaceVersGauche = false;
            }
            else seDeplaceVersGauche = true;
        }
        protected void parchmentPop()
        {
            parchmentToPop = true;
            supprimerElement();
        }
    }
}
