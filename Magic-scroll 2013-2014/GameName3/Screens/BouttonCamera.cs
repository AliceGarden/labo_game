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
    class BouttonCamera
    {
        Texture2D Button, ButtonA;
        public int x { get; set; }
        public int y { get; set; }
        public bool cameraSurvol;
        private bool sourisActiveToMenu;
        public Rectangle rect { get; set; }

        public BouttonCamera(/*int _screenHeight,*/ int _screenWidth)         // constructeur
        {
            cameraSurvol = false;
            x = 0;
            y = 0;
            rect = new Rectangle(_screenWidth - 300, 15, 80, 80);
            /*screenHeight = _screenHeight;
            screenWidth = _screenWidth;*/
        }

        public void LoadContent(ContentManager Content) // pendant le chargement :
        {
            Button = Content.Load<Texture2D>("ElementsMenu/Bougecam");
            ButtonA = Content.Load<Texture2D>("ElementsMenu/BougecamA");
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (cameraSurvol)
                spriteBatch.Draw(ButtonA, rect, Color.White);
            else
                spriteBatch.Draw(Button, rect, Color.White);
        }

        public bool cameraIsSurvol(Rectangle souris)
        {
            MouseState ms = Mouse.GetState();
            bool cameraIsActive = false;   
            if (rect.Intersects(souris))
            {
                if (ms.LeftButton == ButtonState.Pressed)
                    sourisActiveToMenu = true;
                if (sourisActiveToMenu && ms.LeftButton == ButtonState.Released)
                {
                    cameraIsActive = true;
                    sourisActiveToMenu = false;
                }
                cameraSurvol = true;
            }
            else {cameraSurvol = false;}    
            return cameraIsActive;
        }
    }
}