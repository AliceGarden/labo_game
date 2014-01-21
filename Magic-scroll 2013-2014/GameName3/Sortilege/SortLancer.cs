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
    class SortLancer
    {

        Animation Earth, Fire, Water, Wind;
        Point SortP;
        Vector2 translation;
        double percentDeplacementEffectuer;
        TimeSpan lastUpdate;
        TimeSpan tempsInitial;
        int timeInterval;
        TimeSpan totalTime;
        bool estlancer;

        public SortLancer()
        {
            Earth = new Animation(false, "Parchemin/Sprite terre", new Rectangle(SortP.X, SortP.Y, 50, 50), 20, 1, 1, 12);
            Fire = new Animation(false, "Parchemin/Sprite feu", new Rectangle(SortP.X, SortP.Y, 50, 50), 20, 1, 1, 10);
            Water = new Animation(false, "Parchemin/Sprite Eau", new Rectangle(SortP.X, SortP.Y, 50, 50), 15, 1, 1, 6);
            Wind = new Animation(false, "Parchemin/Sprite Vent", new Rectangle(SortP.X, SortP.Y, 50, 50), 15, 1, 1, 10);
            lastUpdate = new TimeSpan();
            timeInterval = 0;
            totalTime = new TimeSpan();
            estlancer = false;
        }

        public void Initialize(int spelllaunch)
        {
            percentDeplacementEffectuer = 0;
            estlancer = false;
            if (spelllaunch == 1) //Terre
            {
                SortP = new Point(80, 205);
                Earth.AnimActived = true;
                translation = new Vector2(0, 120 - SortP.Y);
                timeInterval = (1000 / 12);
                totalTime = new TimeSpan(0,0,timeInterval * 20);
            }
            if (spelllaunch == 2) //Feu
            {
                SortP = new Point(230, 80);
                Fire.AnimActived = true;
                translation = new Vector2(120 - SortP.X, 0);
                timeInterval = (1000 / 10);
                totalTime = new TimeSpan(0,0,timeInterval * 20);
            }
            if (spelllaunch == 3) //Eau
            {
                SortP = new Point(80, 20);
                Water.AnimActived = true;
                translation = new Vector2(0, 120 - SortP.Y);
                timeInterval = (1000 / 6);
                totalTime = new TimeSpan(0,0,timeInterval * 15);
            }
            if (spelllaunch == 4) //Air
            {
                SortP = new Point(72, 115);
                Wind.AnimActived = true;
                translation = new Vector2(120 - SortP.X, 0);
                timeInterval = (1000 / 10);
                totalTime = new TimeSpan(0,0,timeInterval * 20);
            }
            //translation = new Vector2(176 - SortP.X, 176 - SortP.Y);
        }

        public void LoadContent(ContentManager Content)
        {
            Earth.LoadContent(Content);
            Fire.LoadContent(Content);
            Water.LoadContent(Content);
            Wind.LoadContent(Content);
        }

        public void Update(GameTime gameTime, Point ParcheminPos)
        {
            if (!estlancer && (Earth.AnimActived || Fire.AnimActived || Water.AnimActived || Wind.AnimActived))
            {
                tempsInitial = gameTime.TotalGameTime;
                estlancer = true;
            }

            if (estlancer && gameTime.TotalGameTime.Subtract(lastUpdate).Milliseconds >= timeInterval)
            {
                percentDeplacementEffectuer = (gameTime.TotalGameTime.Subtract(tempsInitial).TotalMilliseconds / totalTime.TotalMilliseconds) * 1000;
                lastUpdate = gameTime.TotalGameTime;
            }
            if (Earth.AnimActived)
                Earth.Update(gameTime, new Rectangle(ParcheminPos.X + SortP.X + (int)(translation.X * percentDeplacementEffectuer), ParcheminPos.Y + SortP.Y + (int)(translation.Y * percentDeplacementEffectuer), 150, 150));
            if (Fire.AnimActived)
                Fire.Update(gameTime, new Rectangle(ParcheminPos.X + SortP.X + (int)(translation.X * percentDeplacementEffectuer), ParcheminPos.Y + SortP.Y + (int)(translation.Y * percentDeplacementEffectuer), 150, 150));
            if (Water.AnimActived)
                Water.Update(gameTime, new Rectangle(ParcheminPos.X + SortP.X + (int)(translation.X * percentDeplacementEffectuer), ParcheminPos.Y + SortP.Y + (int)(translation.Y * percentDeplacementEffectuer), 150, 150));
            if (Wind.AnimActived)
                Wind.Update(gameTime, new Rectangle(ParcheminPos.X + SortP.X + (int)(translation.X * percentDeplacementEffectuer), ParcheminPos.Y + SortP.Y + (int)(translation.Y * percentDeplacementEffectuer), 150, 150));
        }

        public void Draw(SpriteBatch spritebatch)
        {
            if (Earth.AnimActived)
                Earth.Draw(spritebatch);
            if (Fire.AnimActived)
                Fire.Draw(spritebatch);
            if (Water.AnimActived)
                Water.Draw(spritebatch);
            if (Wind.AnimActived)
                Wind.Draw(spritebatch);
        }
    }
}
