using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Magic___Scroll.Sortilege
{
    class ResetButton
    {
        Texture2D resetButton, resetButtonA; 
        public int x { get; set; }
        public int y { get; set; }
        bool resetSurvol;
        bool sourisActiveToMenu;
        bool clicAilleur;
        public Rectangle rect { get; set; }

        public ResetButton(int _screenWidth)         // constructeur
        {
            rect = new Rectangle(_screenWidth - 200, 15, 80, 80);
            resetSurvol = false;
            x = 0;
            y = 0;
        }

        public void LoadContent(ContentManager Content) // pendant le chargement :
        {
            resetButton = Content.Load<Texture2D>("ElementsMenu/Reset");
            resetButtonA = Content.Load<Texture2D>("ElementsMenu/ResetA");
        }

        public void Draw(SpriteBatch spriteBatch)    // on dessine notre fond ( avant le perso pour pas l'ecraser )
        {
            if (resetSurvol)
                spriteBatch.Draw(resetButtonA, rect, Color.White);
            else
                spriteBatch.Draw(resetButton, rect, Color.White);
        }
        public bool resetIsSurvol(Rectangle souris)
        {
            MouseState ms = Mouse.GetState();
            bool resetIsActive = false;
            if (rect.Intersects(souris))
            {
                if (!clicAilleur && ms.LeftButton == ButtonState.Pressed)
                    sourisActiveToMenu = true;
                if (sourisActiveToMenu && ms.LeftButton == ButtonState.Released)
                {
                    resetIsActive = true;
                }
                resetSurvol = true;
            }
            else
            {
                resetSurvol = false;
                if (sourisActiveToMenu && ms.LeftButton == ButtonState.Released)
                    sourisActiveToMenu = false;
                if (ms.LeftButton == ButtonState.Pressed)
                    clicAilleur = true;
            }
            if (ms.LeftButton == ButtonState.Released)
                clicAilleur = false;
            return resetIsActive;
        }
    }
}
