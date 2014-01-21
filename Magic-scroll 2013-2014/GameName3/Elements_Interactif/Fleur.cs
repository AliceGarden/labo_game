using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Magic___Scroll.Conception_du_niveau;
using Magic___Scroll.Sortilege;

namespace Magic___Scroll.Elements_Interactif
{
    class Fleur : ElementInteractifGeneral
    {
        Texture2D ma_texture;
        Animation anim_fleur;
        Setting setting;

        public Fleur(int _screenWitdh, int _screenHeight, bool _isActive, Vector2 coordPositionAbsolu, int _x = 25, int _y = 25)
            : base(coordPositionAbsolu)
        {
            setting = Setting.getInstance();
            base.x = _x;
            base.y = _y;
            base.screenWidth = _screenWitdh;
            base.screenHeight = _screenHeight;
            //base.ElementsIsActived = _isActive;
            //base.gravityReady = false;
            base.ElementsIsAltered = false;
            base.ElementsIsActived = false;
            base.ElementsIsBloquant = false;
            base.rect = new Rectangle(x, y, screenWidth/4, screenHeight);
            base.col = new Rectangle(x, y, screenWidth/4, screenHeight);
            base.bottomCol = new Rectangle(x, y + screenHeight - 10, screenWidth, 14);
            anim_fleur = new Animation(true, "ElementsInteractifs/Fleur", base.rect, 9, 4, setting.Random.Next(1,5), 3);
        }

        public override void LoadContent(ContentManager Content)
        {
            anim_fleur.LoadContent(Content);
            ma_texture = Content.Load<Texture2D>("ElementsInteractifs/Fleur");
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            base.rect = new Rectangle(x + (screenWidth / 4), y + 14, (screenWidth / 2), screenHeight);
            base.col = new Rectangle(x + (screenWidth / 4), y, (screenWidth / 2), screenHeight);
            base.headCol = new Rectangle(x + (screenWidth / 4), y - ((screenHeight * 2) + (screenHeight / 4)) + 1, (screenWidth / 2), (screenHeight / 4) - 2);
            base.bottomCol = new Rectangle(x + (screenWidth / 4), y + screenHeight - 10, (screenWidth / 2), 14);
            anim_fleur.AnimActived = true;
            anim_fleur.Update(gameTime, base.rect);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            anim_fleur.Draw(spriteBatch);
            spriteBatch.End();
        }

        public override void actionFeu()
        {
            parchmentPop();
        }
        public override void actionEau()
        {
            parchmentPop();
        }
        public override void actionTerre()
        {
            parchmentPop();
        }
        public override void actionAir(Perso p)
        {
            parchmentPop();
        }
    }
}
