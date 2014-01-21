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
    class PauseButton
    {
        Texture2D pauseButton, pauseButtonA; 
        public int x { get; set; }
        public int y { get; set; }
        /*private int screenHeight;
        private int screenWidth;*/
        public bool pauseSurvol;
        private bool clicAilleur;
        private bool sourisActiveToMenu;
        public Rectangle rect { get; set; }

        public PauseButton(/*int _screenHeight,*/ int _screenWidth)         // constructeur
        {
            pauseSurvol = false;
            x = 0;
            y = 0;
            rect = new Rectangle(_screenWidth - 100, 15, 80, 80);
            /*screenHeight = _screenHeight;
            screenWidth = _screenWidth;*/
        }

        public void LoadContent(ContentManager Content) // pendant le chargement :
        {
            pauseButton = Content.Load<Texture2D>("ElementsMenu/Pause");
            pauseButtonA = Content.Load<Texture2D>("ElementsMenu/PauseA");
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (pauseSurvol)
                spriteBatch.Draw(pauseButtonA, rect, Color.White);
            else
                spriteBatch.Draw(pauseButton, rect, Color.White);
        }

        public bool pauseIsSurvol(Rectangle souris)
        {
            MouseState ms = Mouse.GetState();
            bool pauseIsActive = false;
            if (rect.Intersects(souris))
            {
                if (!clicAilleur && ms.LeftButton == ButtonState.Pressed)
                    sourisActiveToMenu = true;
                if (sourisActiveToMenu && ms.LeftButton == ButtonState.Released)
                {
                    pauseIsActive = true;
                }
                pauseSurvol = true;
            }
            else
            {
                pauseSurvol = false;
                if (sourisActiveToMenu && ms.LeftButton == ButtonState.Released)
                    sourisActiveToMenu = false;
                if (ms.LeftButton == ButtonState.Pressed)
                    clicAilleur = true;
            }
            if (ms.LeftButton == ButtonState.Released)
                clicAilleur = false;
            return pauseIsActive;
        }
    }
}
