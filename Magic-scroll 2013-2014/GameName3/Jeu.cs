using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Windows.UI.Xaml.Media;
using Magic___Scroll.Conception_du_niveau;
using Magic___Scroll.Elements_Interactif;
using Magic___Scroll.Sortilege;
using Magic___Scroll.ScreenManagerFolder;
using Magic___Scroll.Screens;
using Windows.UI.ViewManagement;


namespace Magic___Scroll
{
    class Jeu : Screen
    {
        Game1 game;

        List<Decor> liste_decor;
        List<ElementInteractifGeneral> liste_ElementInteractif;
        List<Ennemis> liste_ennemis;
        List<Parchment> liste_parchment;
        AddParchment addNewParchment;
        List<Mort> liste_mort;
        AffichageBackground background;
        Perso personnage;
        Sceptre sourisG;
        SortLancer spellLaunch;
        ResetButton resetBoutton;
        PauseButton pauseButton;
        BouttonCamera bouttonCamera;
        SpriteFont arialFont;
        SpriteFont ShowCardFont;

        SoundEffect Ventmusic; 

        int speed = 5;
        Setting setting;
        Script script;
        int indexActive;
        int variableDesc = 1;
        bool collision = false;
        bool collisionBambou = false;
        bool sourisActive;
        bool pauseActivé;
        bool mapActive;

        bool caméraActive = false;
        bool cameraUp = false;
        bool cameraRight = false;
        bool cameraDown = false;
        bool cameraLeft = false;
        int valeurXperso = 0;
        int valeurYperso = 0;
        int valeurXcamera = 0;
        int valeurYcamera = 0;

        int _variable = 0;
        int distanceAjout = 0;

        bool afficheSelecteurDebut = false;
        bool choixSelecteurFait = false;
        bool affichInfo;        
        float affihInfoTS;

        Monde mondeEnCours;
        Parchemin parchemin;
        miniMap miniMap;

        float elapsedTime;
        int frameCounter;
        int FPS;
        Son MusicBg;

        int screenWitdhQuad = Microsoft.Xna.Framework.MetroGameWindow.Instance.ClientBounds.Width / 10;
        int screenHeightQuad = Microsoft.Xna.Framework.MetroGameWindow.Instance.ClientBounds.Height / 10;

        public Jeu(Game1 game, ScreenManager screenManager)
            : base(screenManager)
        {
            setting = Setting.getInstance();
            this.game = game;
            screenManager = new ScreenManager(game.Content);
        }

        public override void Initialize()
        {
            affichInfo = true;
            sourisG = new Sceptre();
            sourisActive = false;
            spellLaunch = new SortLancer();
            personnage = new Perso();
            mondeEnCours = new Monde(setting.currentWorld); //Chargement du "monde en cours"
            
            parchemin = new Parchemin(mondeEnCours, setting.currentLevel, game.Window.ClientBounds.Width, game.Window.ClientBounds.Height);
            resetBoutton = new ResetButton(game.Window.ClientBounds.Width);
            pauseButton = new PauseButton(/*game.Window.ClientBounds.Height,*/ game.Window.ClientBounds.Width);
            bouttonCamera = new BouttonCamera(/*game.Window.ClientBounds.Height,*/ game.Window.ClientBounds.Width);

            liste_ElementInteractif = new List<ElementInteractifGeneral>();
            liste_decor = new List<Decor>();
            liste_ennemis = new List<Ennemis>();
            liste_parchment = new List<Parchment>();
            addNewParchment = new AddParchment();
            liste_mort = new List<Mort>();

            MusicBg = new Son();

            script = new Script();

            mondeEnCours.chargerElementsInteractif(screenHeightQuad, screenWitdhQuad, mondeEnCours, setting.currentLevel, liste_ElementInteractif, liste_decor, liste_ennemis, liste_parchment, liste_mort, personnage);
            background = new AffichageBackground(game.Window.ClientBounds.Height, game.Window.ClientBounds.Width, mondeEnCours.ValeurSol);
            miniMap = new miniMap(game, mondeEnCours.maxX, mondeEnCours.maxY, mondeEnCours.minX, mondeEnCours.minY, liste_decor, liste_ElementInteractif, liste_ennemis, liste_parchment, personnage.coordAbsolute);

            miniMap.Initialize();
            
            foreach (Decor c in liste_decor)
                c.x -= (personnage.X - (game.Window.ClientBounds.Width / 2));
            foreach (ElementInteractifGeneral c in liste_ElementInteractif)
                c.x -= (personnage.X - (game.Window.ClientBounds.Width / 2));
            foreach (Parchment p in liste_parchment)
                p.X -= (personnage.X - (game.Window.ClientBounds.Width / 2));
            foreach (Mort m in liste_mort)
                m.x -= (personnage.X - (game.Window.ClientBounds.Width / 2));
            foreach (Ennemis e in liste_ennemis)
            {
                e.x -= (personnage.X - (game.Window.ClientBounds.Width / 2));
                e.initX -= (personnage.X - (game.Window.ClientBounds.Width / 2));
            }
            foreach (Decor c in liste_decor)
                c.y -= (personnage.Y - (game.Window.ClientBounds.Height / 2));
            foreach (ElementInteractifGeneral c in liste_ElementInteractif)
                c.y -= (personnage.Y - (game.Window.ClientBounds.Height / 2));
            foreach (Parchment p in liste_parchment)
                p.Y -= (personnage.Y - (game.Window.ClientBounds.Height / 2));
            foreach (Mort m in liste_mort)
                m.y -= (personnage.Y - (game.Window.ClientBounds.Height / 2));
            foreach (Ennemis e in liste_ennemis)
            {
                e.y -= (personnage.Y - (game.Window.ClientBounds.Height / 2));
                e.initY -= (personnage.Y - (game.Window.ClientBounds.Height / 2));
            }
            background.Initialize(personnage, game);
            personnage.X -= (personnage.X - (game.Window.ClientBounds.Width / 2));
            personnage.Y -= (personnage.Y - (game.Window.ClientBounds.Height / 2));
            indexActive = -1;

            elapsedTime = 0;
            frameCounter = 0;
            affihInfoTS = 0;

            script.Initialize();
            //personnage.Y += screenHeightQuad/2;
            base.Initialize();
        }
        public override void LoadContent(ContentManager content)
        {
            arialFont = content.Load<SpriteFont>("ArialFont");
            ShowCardFont = content.Load<SpriteFont>("50ShowCard");
            background.LoadContent(content);
            personnage.LoadContent(content);
            parchemin.LoadContent(content);
            sourisG.LoadContent(content);
            spellLaunch.LoadContent(content);
            resetBoutton.LoadContent(content);
            pauseButton.LoadContent(content);
            bouttonCamera.LoadContent(content);
            foreach (var t in liste_decor)
                t.LoadContent(content);
            foreach (var t in liste_ElementInteractif)
                t.LoadContent(content);
            foreach (var e in liste_ennemis)
                e.LoadContent(content);
            foreach (Parchment p in liste_parchment)
                p.LoadContent(content);
            foreach (var m in liste_mort)
                m.LoadContent(content);
            addNewParchment.LoadContent(content);
            miniMap.LoadContent(content);
            MusicBg.Initialize(content, "foretW", true);
            if (!setting.SonActive)
                MusicBg.Pause();
            if (script.ScriptExisting)
                script.LoadContent(content);

            Ventmusic = content.Load<SoundEffect>("vent son");
        }

        public override void Update(GameTime gameTime)
        {
            #region FPS
            elapsedTime += (float)gameTime.ElapsedGameTime.TotalSeconds;
            frameCounter++;
            if (elapsedTime > 1)
            {
                FPS = frameCounter;
                frameCounter = 0;
                elapsedTime = 0;
            }
            #endregion
            #region Update de tout les surplus
            if (ApplicationView.Value == ApplicationViewState.Snapped)
            {
                if (setting.SonActive) MusicBg.Pause();
                screenManagerstock.Push(new SnappedIsNotAllowed(game, screenManagerstock));
            }

            affihInfoTS += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (affihInfoTS >= 3)
                affichInfo = false;

            background.Update(gameTime);
            personnage.Update(gameTime, game.GraphicsDevice);
            sourisG.Update(gameTime);
            if (setting.SonActive) MusicBg.Reprendre();

            if (script.ScriptExisting)
            {
                script.Update(gameTime);
                if (setting.currentWorld == 0 && setting.currentLevel == 1 && !affichInfo)
                    script.script1();
                if (setting.currentWorld == 0 && setting.currentLevel == 2 && !affichInfo)
                    script.script2();
            }
            #endregion

            #region Update de tout les paramètres du jeu
            foreach (Decor t in liste_decor) //Mise à jour du décor
                t.Update(gameTime);
            foreach (ElementInteractifGeneral t in liste_ElementInteractif) //Mise à jour des elements Interactifs
            {
                t.Update(gameTime);                   
                if ((t is BlocFriable || t is BlocCendre ) && !t.ElementsIsActived && !t.EtatFinale && t.col.Intersects(personnage.bottomCol) /*&& (personnage.col.X + personnage.bottomCol.Width) >= (t.col.X + (t.col.Width / 2))*/)
                {
                    t.ElementsIsAltered = true;  
                }
                if (t.bottomCollision(liste_decor))
                    t.bottomCollisionIsTrue = true;
                else t.bottomCollisionIsTrue = false;
            }
            deplacementNuageFonction();
            int index = 0;
            int indexASuppr = -1;
            foreach (Parchment p in liste_parchment)
            {
                p.Update(gameTime);
                if (p.modifNbParchemin(personnage.col))
                    switch (p.type)
                    {
                        case 1:
                            mondeEnCours.ListeDesNiveauxDunMonde[setting.currentLevel - 1].nbParcheminE++;
                            indexASuppr = index;
                            break;
                        case 2:
                            mondeEnCours.ListeDesNiveauxDunMonde[setting.currentLevel - 1].nbParcheminF++;
                            indexASuppr = index;
                            break;
                        case 3:
                            mondeEnCours.ListeDesNiveauxDunMonde[setting.currentLevel - 1].nbParcheminT++;
                            indexASuppr = index;
                            break;
                        case 4:
                            mondeEnCours.ListeDesNiveauxDunMonde[setting.currentLevel - 1].nbParcheminA++;
                            indexASuppr = index;
                            break;
                    }
                index++;
            }
            if (indexASuppr != -1)
                liste_parchment.RemoveAt(indexASuppr);

            foreach (Ennemis e in liste_ennemis) //Mise à jour des ennemis
            {
                e.Update(gameTime);
                if (e.bottomCollision(liste_decor, liste_ElementInteractif))
                    e.bottomCollisionIsTrue = true;
                else e.bottomCollisionIsTrue = false;
            }

            collisionBambou = checkBambou();

            collANDpouvoir();

            spellLaunch.Update(gameTime, new Point(parchemin.x, parchemin.y));

            sourisRoueDesPouvoirs();

            Victoire();

            GestionEcranAffichage();

            FeuOuPas();

            foreach (Parchment p in liste_parchment)
                p.Update(gameTime);
            foreach (Mort m in liste_mort)
                m.Update(gameTime);


            if (!checkCollisions(gameTime))
            {

                if (!bottomCollision()) //gravité du personnage
                {
                    if (Headcollision(gameTime))
                    {
                        //personnage.rect.Y += 1;
                        //personnage.coordAbsolute.Y += 1;
                        variableDesc = speed;
                    }
                    else
                    {
                        if (!checkBambou())
                        {
                            if (_variable > 5)
                            {
                                variableDesc += 1;
                                _variable = 0;
                            }
                            //personnage.rect.Y += variableDesc;
                            //personnage.coordAbsolute.Y += variableDesc;
                            _variable++;
                        }
                   }
                }
            }
            #endregion
            
            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            game.GraphicsDevice.Clear(Color.CornflowerBlue);

            background.Draw(spriteBatch);

            foreach (var t in liste_decor)
                t.Draw(spriteBatch);
            foreach (ElementInteractifGeneral t in liste_ElementInteractif)
                t.Draw(spriteBatch);
            foreach (var e in liste_ennemis)
                e.Draw(spriteBatch);
            foreach (Parchment p in liste_parchment)
                p.Draw(spriteBatch);
            foreach (var m in liste_mort)
                m.Draw(spriteBatch);

            personnage.Draw(spriteBatch);

            if (script.ScriptExisting)
            {
                script.Draw(spriteBatch);
            }

            spriteBatch.Begin();
            spellLaunch.Draw(spriteBatch);
            resetBoutton.Draw(spriteBatch);
            pauseButton.Draw(spriteBatch);
            bouttonCamera.Draw(spriteBatch);
            if (afficheSelecteurDebut)
                parchemin.Draw(spriteBatch);
            parchemin.DrawCompteur(spriteBatch);
            sourisG.Draw(spriteBatch);

            //spriteBatch.DrawString(arialFont, "FPS: " + FPS.ToString(), new Vector2(0, 30), Color.Yellow);
            if (affichInfo)
                spriteBatch.DrawString(ShowCardFont, "Monde " + setting.currentWorld.ToString() + " Niveau " + setting.currentLevel.ToString(), new Vector2((game.Window.ClientBounds.Width / 2) - (("Monde " + setting.currentWorld.ToString() + " Niveau " + setting.currentLevel.ToString()).Length / 2) * 40, (game.Window.ClientBounds.Height / 4)), Color.White);

            spriteBatch.End();
            base.Draw(spriteBatch);
        }

        #region fonction annexes

        #region collision //Gestion des collisions diverses

        public bool bottomCollision() //Collission avec le sol
        {
            bool collision = false;

            foreach (Decor d in liste_decor)
            {
                if (personnage.bottomCol.Intersects(d.bottomcol))
                    collision = true;
                else
                {
                    foreach (ElementInteractifGeneral b in liste_ElementInteractif)
                    {
                        if (b is BlocFriable || b is BlocCendre)
                        {
                            if (personnage.bottomCol.Intersects(b.bottomCol) && (b.EtatFinale || b.ElementsIsActived))
                                collision = true;
                        }
                        else
                        {
                            if (b is NuagePlateforme)
                            {
                                if (personnage.bottomCol.Intersects(b.col))
                                    collision = true;

                            }
                            else
                            {
                                if (b is PillierGaz)
                                {
                                    if(personnage.bottomCol.Intersects(((PillierGaz)b).HautPacerelle))
                                        collision = true;
                                }
                            }
                        }
                    }
                }
            }
            return collision;
        }

        public bool Headcollision(GameTime gameTime)
        {
            bool HeadCollision = false;

            foreach (ElementInteractifGeneral b in liste_ElementInteractif)
            {
                if (b is Bambou)
                {
                    if (personnage.bottomCol.Intersects(b.headCol))
                    {
                        HeadCollision = true;
                    }
                }
            }
            foreach (Decor d in liste_decor)
            {
                if (personnage.bottomCol.Intersects(d.headCol))
                {
                    HeadCollision = true;
                }
            }
            return HeadCollision;
        }

        public bool checkCollisions(GameTime gameTime) //Gestion clavier
        {
            KeyboardState kb = Keyboard.GetState();         // Récupération de la touche qui est appuyé

            #region Sélectionner Pouvoir à utiliser
            if (kb.IsKeyDown(Keys.V))
            {
                sourisG.changerSceptre(Color.Green);
                parchemin.sortActive = 1;
            }
            if (kb.IsKeyDown(Keys.G))
            {
                sourisG.changerSceptre(Color.Red);
                parchemin.sortActive = 2;
            }
            if (kb.IsKeyDown(Keys.F))
            {
                sourisG.changerSceptre(Color.Yellow);
                parchemin.sortActive = 4;
            }
            if (kb.IsKeyDown(Keys.T))
            {
                sourisG.changerSceptre(Color.Blue);
                parchemin.sortActive = 3;
            }
            #endregion

            #region BoutonPause

            if (kb.IsKeyDown(Keys.Escape))
            {
                pauseActivé = true;
            }
            if (kb.IsKeyUp(Keys.Escape) && pauseActivé)
            {
                pauseActivé = false;
                if (setting.SonActive) MusicBg.Pause();
                screenManagerstock.Push(new PauseMenu(game, base.screenManagerstock, mondeEnCours.niveauMax));
            }
            if (kb.IsKeyDown(Keys.M))
                mapActive = true;
            if (kb.IsKeyUp(Keys.M) && mapActive)
            {
                mapActive = false;
                screenManagerstock.Push(new Maps(game, screenManagerstock, miniMap, personnage));
            }
            #endregion

            #region gestion déplacement Perso
            if (!caméraActive)
            {
                if ((kb.IsKeyDown(Keys.Up) || kb.IsKeyDown(Keys.Z)) && collisionBambou)
                {
                    personnage.rect.Y -= speed;
                    //personnage.coordAbsolute.Y -= speed;
                    personnage.isHaut = true;
                }
                else
                    personnage.isHaut = false;

                if ((kb.IsKeyDown(Keys.Left) || kb.IsKeyDown(Keys.Q)) && (collisionBambou || bottomCollision())) // Si on va à gauche
                    personnage.isGauche = true;
                else personnage.isGauche = false;

                if ((kb.IsKeyDown(Keys.Right) || kb.IsKeyDown(Keys.D)) && (collisionBambou || bottomCollision())) // Si on va à droite
                    personnage.isDroite = true;
                else personnage.isDroite = false;


                if (personnage.isGauche || personnage.isDroite) // Si le perso se déplace à gauche ou à droite
                {
                    if (personnage.isGauche) // on déplace le perso vers l'élèment à tester pour tester une potentielle collission
                        personnage.col.X = personnage.col.X - speed;
                    if (personnage.isDroite)
                        personnage.col.X = personnage.col.X + speed;

                    collision = false;
                    foreach (ElementInteractifGeneral e in liste_ElementInteractif)
                    {
                        if (e.ElementsIsBloquant && personnage.col.Intersects(e.col)) //si l'élément est bloquant et que le perso le touche
                        {
                            collision = true;
                        }
                    }

                    if (personnage.isGauche) //On remet le perso à son "ancienne" position on fois le test terminés
                        personnage.col.X = personnage.col.X + speed;
                    if (personnage.isDroite)
                        personnage.col.X = personnage.col.X - speed;
                }
                //foreach (Decor d in liste_decor)
                //    if (personnage.bottomCol.Intersects(d.bottomcol))
                //        personnage.Y -= 8;
            }
            else
            {
                if ((kb.IsKeyDown(Keys.Up) || kb.IsKeyDown(Keys.Z)))
                {
                    cameraUp = true;
                }
                else
                    cameraUp = false;
                
                if ((kb.IsKeyDown(Keys.Left) || kb.IsKeyDown(Keys.Q)))
                {
                    cameraLeft = true;
                }
                else
                    cameraLeft = false;

                if (kb.IsKeyDown(Keys.Right) || kb.IsKeyDown(Keys.D))
                {
                    cameraRight = true;
                }
                else
                    cameraRight = false;

                if ((kb.IsKeyDown(Keys.Down) || kb.IsKeyDown(Keys.S)) && VerificationEcranMort())
                {
                    cameraDown = true;
                }
                else
                    cameraDown = false;
            }
            #endregion

            foreach (Mort m in liste_mort)
            {
                if (personnage.rect.Intersects(m.rect))
                {
                    if (setting.SonActive) MusicBg.Stop();
                    screenManagerstock.relaunch(new Jeu(game, base.screenManagerstock));
                }
            }
            return collision;
        }

        public bool checkBambou() //Permet de monter sur un bambou ou sur pillier gaz
        {
            bool collisionBambou = false;

            foreach (ElementInteractifGeneral b in liste_ElementInteractif)
            {
                if (b is Bambou && personnage.bottomCol.Intersects(b.col) && b.ElementsIsActived)
                {
                    //for (int zdz = liste_decor.Count - 1; zdz >= 0; zdz--)
                    //if (personnage.bottomCol.Intersects(liste_decor[zdz].bottomcol))
                    foreach (Decor d in liste_decor)
                    {
                        if (personnage.col.Intersects(d.col))
                        {
                            collisionBambou = false;
                        }
                        else
                        {
                            collisionBambou = true;
                        }
                        collisionBambou = true;
                    }
                }
                if (b is PillierGaz && personnage.bottomCol.Intersects(b.col) && !b.ElementsIsActived)
                {
                    //for (int zdz = liste_decor.Count - 1; zdz >= 0; zdz--)
                    //if (personnage.bottomCol.Intersects(liste_decor[zdz].bottomcol))
                    foreach (Decor d in liste_decor)
                    {
                        if (personnage.col.Intersects(d.col))
                        {
                            collisionBambou = false;
                        }
                        else
                        {
                            collisionBambou = true;
                        }
                        collisionBambou = true;
                    }
                }
            }
            return collisionBambou;
        }
        #endregion

        public void sourisRoueDesPouvoirs()
        {
            MouseState Ms = Mouse.GetState();

            if (Ms.LeftButton == ButtonState.Pressed)
            {
                if ((Ms.X >= parchemin.x) && (Ms.X <= (parchemin.x + 352)) && (Ms.Y >= parchemin.y) && (Ms.Y <= (parchemin.y + 352)))
                {
                    double coordonneesXSourisSelecteur = (Ms.X - parchemin.x) - 171;
                    double coordonneesYSourisSelecteur = -((Ms.Y - parchemin.y) - 171);
                    double distanceALOrigine = Math.Sqrt(((Math.Pow(coordonneesXSourisSelecteur, 2)) + (Math.Pow(coordonneesYSourisSelecteur, 2))));
                    double angleSourisSelecteurcos = (Math.Acos(coordonneesXSourisSelecteur / distanceALOrigine)) * (180.0 / Math.PI);
                    double angleSourisSelecteursin = (Math.Asin(coordonneesYSourisSelecteur / distanceALOrigine)) * (180.0 / Math.PI);
                    if (distanceALOrigine < 151)
                    {
                        if (angleSourisSelecteurcos < 35) //feu
                        {
                            if (mondeEnCours.ListeDesNiveauxDunMonde[setting.currentLevel - 1].nbParcheminF > 0)
                            {
                                sourisG.changerSceptre(Color.Red);
                                parchemin.sortActive = 2;
                            }
                        }
                        if (angleSourisSelecteurcos > 45 && angleSourisSelecteurcos < 135 && angleSourisSelecteursin > 0) //eau
                        {
                            if (mondeEnCours.ListeDesNiveauxDunMonde[setting.currentLevel - 1].nbParcheminE > 0)
                            {
                                sourisG.changerSceptre(Color.Blue);
                                parchemin.sortActive = 3;
                            }
                        }
                        if (angleSourisSelecteurcos > 45 && angleSourisSelecteurcos < 135 && angleSourisSelecteursin < 0) //terre
                        {
                            if (mondeEnCours.ListeDesNiveauxDunMonde[setting.currentLevel - 1].nbParcheminT > 0)
                            {
                                sourisG.changerSceptre(Color.Green);
                                parchemin.sortActive = 1;
                            }
                        }
                        if (angleSourisSelecteurcos > 135) //air
                        {
                            if (mondeEnCours.ListeDesNiveauxDunMonde[setting.currentLevel - 1].nbParcheminA > 0)
                            {
                                sourisG.changerSceptre(Color.Yellow);
                                parchemin.sortActive = 4;
                            }
                        }
                    }
                    if ((coordonneesXSourisSelecteur < 20 && coordonneesXSourisSelecteur > -20) && (coordonneesYSourisSelecteur < 20 && coordonneesYSourisSelecteur > -20))
                    {
                        sourisG.changerSceptre(Color.White);
                        parchemin.sortActive = 0;
                    }
                }
            }
        }  //Gestion de la souris

        public void collANDpouvoir() //Gestion de la roue des pouvoirs et de la caméra
        {
            int index = 0;

            int elementsASuppr = 0;
            bool delElements = false;

            if (resetBoutton.resetIsSurvol(sourisG.coll))
            {
                if (setting.SonActive) MusicBg.Stop();
                screenManagerstock.relaunch(new Jeu(game, base.screenManagerstock));
            }
            if (pauseButton.pauseIsSurvol(sourisG.coll))
            {
                if (setting.SonActive) MusicBg.Pause();
                screenManagerstock.Push(new PauseMenu(game, base.screenManagerstock, mondeEnCours.niveauMax));
            }
            if (bouttonCamera.cameraIsSurvol(sourisG.coll))
            {
                if (caméraActive)
                {
                    caméraActive = false;
                    valeurXcamera = personnage.rect.X;
                    valeurYcamera = personnage.rect.Y;
                    valeurYcamera -= valeurYperso;
                    valeurXcamera -= valeurXperso;
                    int i = valeurXcamera;
                    while (i > 0)
                    {
                        background.vaADroite(speed);
                        personnage.rect.X -= speed;
                        foreach (Decor c in liste_decor)
                            c.x -= speed;
                        foreach (ElementInteractifGeneral c in liste_ElementInteractif)
                            c.x -= speed;
                        foreach (Parchment p in liste_parchment)
                            p.X -= speed;
                        //foreach (Mort m in liste_mort)
                        //    m.x -= speed;
                        foreach (Ennemis e in liste_ennemis)
                        {
                            e.x -= speed;
                            e.initX -= speed;
                        }
                        i -= speed;
                    }
                    while (i < 0)
                    {
                        background.vaAGauche(speed);
                        personnage.rect.X += speed;
                        foreach (Decor c in liste_decor)
                            c.x += speed;
                        foreach (ElementInteractifGeneral c in liste_ElementInteractif)
                            c.x += speed;
                        foreach (Parchment p in liste_parchment)
                            p.X += speed;
                        foreach (Ennemis e in liste_ennemis)
                        {
                            e.x += speed;
                            e.initX += speed;
                        }
                        i += speed;
                    }
                    i = valeurYcamera;
                    while (i > 0)
                    {
                            foreach (Mort m in liste_mort)
                                m.y -= speed;
                            background.vaEnHaut(speed);
                            personnage.rect.Y -= speed;
                            foreach (Decor c in liste_decor)
                                c.y -= speed;
                            foreach (ElementInteractifGeneral c in liste_ElementInteractif)
                                c.y -= speed;
                            foreach (Parchment p in liste_parchment)
                                p.Y -= speed;
                            foreach (Ennemis e in liste_ennemis)
                            {
                                e.y -= speed;
                                e.initY -= speed;
                            }
                            i -= speed;
                    }
                    while (i < 0)
                    {
                        foreach (Mort m in liste_mort)
                            m.y += speed;
                        personnage.rect.Y += speed;
                        background.vaEnBas(speed);
                        foreach (Decor c in liste_decor)
                            c.y += speed;
                        foreach (ElementInteractifGeneral c in liste_ElementInteractif)
                            c.y += speed;
                        foreach (Parchment p in liste_parchment)
                            p.Y += speed;
                        foreach (Ennemis e in liste_ennemis)
                        {
                            e.y += speed;
                            e.initY += speed;
                        }
                        i += speed;
                    }
                }
                else
                {
                    caméraActive = true;
                    valeurXperso = personnage.rect.X;
                    valeurYperso = personnage.rect.Y;
                }
            }


            foreach (ElementInteractifGeneral b in liste_ElementInteractif)
            {
                if ((Math.Sqrt(((Math.Pow(sourisG.coll.X - (game.Window.ClientBounds.Width / 2), 2)) + (Math.Pow(sourisG.coll.Y - (game.Window.ClientBounds.Height / 2), 2)))) <= ((game.Window.ClientBounds.Height - 352) / 2))
                    || (sourisG.coll.X > 200 && sourisG.coll.X < (game.Window.ClientBounds.Width - 200) && sourisG.coll.Y > 382  && sourisG.coll.Y < (game.Window.ClientBounds.Height - 200)))
                {
                    if ((sourisG.coll.Intersects(b.col)) && !afficheSelecteurDebut && !choixSelecteurFait && Mouse.GetState().LeftButton == ButtonState.Pressed) // Condition pour afficher selecteur
                    {
                        sourisActive = true;
                        indexActive = index;
                    }
                    if (sourisActive && indexActive == index && !afficheSelecteurDebut && !choixSelecteurFait && (!(sourisG.coll.Intersects(b.col)) || Mouse.GetState().LeftButton == ButtonState.Released))
                    {
                        parchemin.Update(new Point(b.rect.X + (b.rect.Width / 2), b.rect.Y + (b.rect.Height / 2)));
                        afficheSelecteurDebut = true;
                        sourisActive = false;
                    }

                    if (afficheSelecteurDebut && !choixSelecteurFait && /*(sourisG.coll.Intersects(b.col)) && */Mouse.GetState().LeftButton == ButtonState.Pressed) // Condition pour désafficher selecteur
                    {
                        sourisActive = true;
                        choixSelecteurFait = true;
                    }

                    if (sourisActive && indexActive == index && choixSelecteurFait && afficheSelecteurDebut && (/*!(sourisG.coll.Intersects(b.col)) ||*/ Mouse.GetState().LeftButton == ButtonState.Released))
                    {
                        afficheSelecteurDebut = false;
                        choixSelecteurFait = false;
                        sourisActive = false;
                        if (parchemin.sortActive == 1) //Parchemin Terre
                        {
                            if (mondeEnCours.ListeDesNiveauxDunMonde[setting.currentLevel - 1].nbParcheminT > 0)
                            {
                                sourisG.animSceptreT.AnimActived = true;
                                b.actionTerre();
                                mondeEnCours.ListeDesNiveauxDunMonde[setting.currentLevel - 1].nbParcheminT--;
                            }
                        }
                        if (parchemin.sortActive == 2) //Parchemin Feu
                        {
                            if (mondeEnCours.ListeDesNiveauxDunMonde[setting.currentLevel - 1].nbParcheminF > 0)
                            {
                                sourisG.animSceptreF.AnimActived = true;
                                if (b is NuagePlateforme)
                                {

                                    ((NuagePlateforme)b).actionFeu(personnage);
                                }
                                else
                                    b.actionFeu();
                                mondeEnCours.ListeDesNiveauxDunMonde[setting.currentLevel - 1].nbParcheminF--;
                            }
                        }
                        if (parchemin.sortActive == 3) //Parchemin Eau
                        {
                            if (mondeEnCours.ListeDesNiveauxDunMonde[setting.currentLevel - 1].nbParcheminE > 0)
                            {
                                sourisG.animSceptreE.AnimActived = true;
                                if (b is NuagePlateforme)
                                {

                                    ((NuagePlateforme)b).actionEau(personnage);
                                }
                                else
                                    b.actionEau();
                                mondeEnCours.ListeDesNiveauxDunMonde[setting.currentLevel - 1].nbParcheminE--;
                            }
                        }
                        if (parchemin.sortActive == 4) //Parchemin Air
                        {
                            if (mondeEnCours.ListeDesNiveauxDunMonde[setting.currentLevel - 1].nbParcheminA > 0)
                            {
                                sourisG.animSceptreV.AnimActived = true;
                                if (b is NuagePlateforme)
                                {

                                    ((NuagePlateforme)b).actionAir(personnage, liste_decor);
                                }
                                else
                                    b.actionAir(personnage);
                                Ventmusic.Play();
                                mondeEnCours.ListeDesNiveauxDunMonde[setting.currentLevel - 1].nbParcheminA--;
                            }
                        }
                        spellLaunch.Initialize(parchemin.sortActive);
                        sourisG.changerSceptre(Color.White);

                        if (b.parchmentToPop)
                        {
                            if (parchemin.sortActive == 1) // On fait poper un parchemin de feu
                            {
                                liste_parchment.Add(new Parchment('7'.GetHashCode(), b.x, b.y, screenHeightQuad, screenWitdhQuad, b.coordPositionAbsolu));
                                liste_parchment[liste_parchment.Count - 1].LoadTexture(addNewParchment.Feu);
                            }
                            if (parchemin.sortActive == 2) // On fait poper un parchemin de air
                            {
                                liste_parchment.Add(new Parchment('9'.GetHashCode(), b.x, b.y, screenHeightQuad, screenWitdhQuad, b.coordPositionAbsolu));
                                liste_parchment[liste_parchment.Count - 1].LoadTexture(addNewParchment.Air);
                            }
                            if (parchemin.sortActive == 3) // On fait poper un parchemin de terre
                            {
                                liste_parchment.Add(new Parchment('8'.GetHashCode(), b.x, b.y, screenHeightQuad, screenWitdhQuad, b.coordPositionAbsolu));
                                liste_parchment[liste_parchment.Count - 1].LoadTexture(addNewParchment.Terre);
                            }
                            if (parchemin.sortActive == 4) // On fait poper un parchemin de eau
                            {
                                liste_parchment.Add(new Parchment('6'.GetHashCode(), b.x, b.y, screenHeightQuad, screenWitdhQuad, b.coordPositionAbsolu));
                                liste_parchment[liste_parchment.Count - 1].LoadTexture(addNewParchment.Eau);
                            }
                            
                        }

                        parchemin.sortActive = 0;
                    }
                }
                if (b.deleteElement)
                {
                    delElements = true;
                    elementsASuppr = index;
                }
                index++;
            }

            if (delElements)
            {
                collision = false;
                liste_ElementInteractif.RemoveAt(elementsASuppr);
                delElements = false;
            }
        }

        public void Victoire()
        {
            foreach (ElementInteractifGeneral b in liste_ElementInteractif)
            {
                if (b is Familier)
                {
                    if (personnage.col.Intersects(b.col))
                    {
                        if (setting.SonActive) MusicBg.Stop();
                        screenManagerstock.Push(new EndLevel(game, base.screenManagerstock, mondeEnCours.niveauMax));
                    }
                }
            }
        }  //Condition de victoire

        public void FeuOuPas()
        {
            foreach(ElementInteractifGeneral c in liste_ElementInteractif)
            {
                if(c is FeuCamp && c.ElementsIsActived)
                {
                    foreach(ElementInteractifGeneral b in liste_ElementInteractif)
                    {
                        if(b.col.Intersects(c.col))
                        {
                            b.actionFeu();
                        }
                    }
                }
            }
        }

        public void deplacementNuageFonction()
        {
            foreach (ElementInteractifGeneral b in liste_ElementInteractif)
            {
                if (b is NuagePlateforme)
                {
                    if (b.ElementsIsActived && personnage.bottomCol.Intersects(b.col))
                    {
                        if (!((NuagePlateforme)b).toucheDecor)
                        {
                            if (((NuagePlateforme)b).isDroite)
                            {
                                distanceAjout = ((NuagePlateforme)b).DX + 3;
                                foreach (Decor c in liste_decor)
                                    c.x -= distanceAjout;
                                foreach (ElementInteractifGeneral c in liste_ElementInteractif)
                                {
                                    if (c is NuagePlateforme)
                                        c.x = c.x;
                                    c.x -= distanceAjout;
                                }
                                foreach (Parchment p in liste_parchment)
                                    p.X -= distanceAjout;
                                foreach (Ennemis e in liste_ennemis)
                                {
                                    e.x -= distanceAjout;
                                    e.initX -= distanceAjout;
                                }
                            }
                            else
                            {
                                distanceAjout = ((NuagePlateforme)b).DX;
                                foreach (Decor c in liste_decor)
                                    c.x += distanceAjout;
                                foreach (ElementInteractifGeneral c in liste_ElementInteractif)
                                {
                                    if (c is NuagePlateforme)
                                        c.x = c.x;
                                    c.x += distanceAjout;
                                }
                                foreach (Parchment p in liste_parchment)
                                    p.X += distanceAjout;
                                foreach (Ennemis e in liste_ennemis)
                                {
                                    e.x += distanceAjout;
                                    e.initX += distanceAjout;
                                }
                            }
                        }
                    }
                }
            }
        }

        public void GestionEcranAffichage()  //Gestion du déplacement de l'écran en fonction du joueur
        {
            if (personnage.rect.X >= ((game.GraphicsDevice.Viewport.Width * 1) / 2) - personnage.rect.Width && !caméraActive)       // si on est tout à droite de la fenetre alors on bloque le mouvement
            {
                //personnage.rect.X = ((game.GraphicsDevice.Viewport.Width * 1) / 2) - personnage.rect.Width;
                if (personnage.isDroite &&  !collision)
                {
                    background.vaADroite(speed);
                    foreach (Decor c in liste_decor)
                        c.x -= speed;
                    foreach (ElementInteractifGeneral c in liste_ElementInteractif)
                        c.x -= speed;
                    foreach (Parchment p in liste_parchment)
                        p.X -= speed;
                    //foreach (Mort m in liste_mort)
                    //    m.x -= speed;
                    foreach (Ennemis e in liste_ennemis)
                    {
                        e.x -= speed;
                        e.initX -= speed;
                    }
                }
                
            }
                if (caméraActive && cameraRight)
                {
                    background.vaADroite(speed);
                    personnage.rect.X -= speed;
                    foreach (Decor c in liste_decor)
                        c.x -= speed;
                    foreach (ElementInteractifGeneral c in liste_ElementInteractif)
                        c.x -= speed;
                    foreach (Parchment p in liste_parchment)
                        p.X -= speed;
                    //foreach (Mort m in liste_mort)
                    //    m.x -= speed;
                    foreach (Ennemis e in liste_ennemis)
                    {
                        e.x -= speed;
                        e.initX -= speed;
                    }
                }
            //}

                if (personnage.rect.X <= game.GraphicsDevice.Viewport.Width / 2 && !caméraActive) // si on est tout à gauche de la fenetre 
                {
                    //personnage.rect.X = game.GraphicsDevice.Viewport.Width / 2;
                    if (personnage.isGauche  && !collision)
                    {
                        background.vaAGauche(speed);
                        foreach (Decor c in liste_decor)
                            c.x += speed;
                        foreach (ElementInteractifGeneral c in liste_ElementInteractif)
                            c.x += speed;
                        foreach (Parchment p in liste_parchment)
                            p.X += speed;
                        //foreach (Mort m in liste_mort)
                        //    m.x += speed;
                        foreach (Ennemis e in liste_ennemis)
                        {
                            e.x += speed;
                            e.initX += speed;
                        }
                    }
                }
                if (cameraLeft && caméraActive)
                {
                    background.vaAGauche(speed);
                    personnage.rect.X += speed;
                    foreach (Decor c in liste_decor)
                        c.x += speed;
                    foreach (ElementInteractifGeneral c in liste_ElementInteractif)
                        c.x += speed;
                    foreach (Parchment p in liste_parchment)
                        p.X += speed;
                    //foreach (Mort m in liste_mort)
                    //    m.x += speed;
                    foreach (Ennemis e in liste_ennemis)
                    {
                        e.x += speed;
                        e.initX += speed;
                    }
                }

            //}
            foreach (Mort m in liste_mort)
            {
                if (personnage.rect.Y >= game.GraphicsDevice.Viewport.Height / 2 && !caméraActive) // Si en bas
                {

                    //personnage.rect.Y = (game.GraphicsDevice.Viewport.Height / 2); //- personnage.rect.Height;
                    
                    if (!bottomCollision())
                    {
                        if (VerificationEcranMort())
                        {
                            m.y -= variableDesc;
                            background.vaEnHaut(variableDesc);
                            foreach (Decor c in liste_decor)
                                c.y -= variableDesc;
                            foreach (ElementInteractifGeneral c in liste_ElementInteractif)
                                c.y -= variableDesc;
                            foreach (Parchment p in liste_parchment)
                                p.Y -= variableDesc;
                            foreach (Ennemis e in liste_ennemis)
                            {
                                e.y -= variableDesc;
                                e.initY -= variableDesc;
                            }
                        }
                    }
                }

                if (!bottomCollision() && !VerificationEcranMort())
                    personnage.rect.Y += variableDesc;

                if (caméraActive && cameraDown)
                {
                    m.y -= speed;
                    background.vaEnHaut(speed);
                    personnage.rect.Y -= speed;
                    foreach (Decor c in liste_decor)
                        c.y -= speed;
                    foreach (ElementInteractifGeneral c in liste_ElementInteractif)
                        c.y -= speed;
                    foreach (Parchment p in liste_parchment)
                        p.Y -= speed;
                    foreach (Ennemis e in liste_ennemis)
                    {
                        e.y -= speed;
                        e.initY -= speed;
                    }
                }

                if (personnage.rect.Y <= game.GraphicsDevice.Viewport.Height / 2 && !caméraActive && VerificationEcranMort()) //Si en haut
                {
                    //personnage.rect.Y = game.GraphicsDevice.Viewport.Height / 2;
                    if (!bottomCollision())
                    {
                        background.vaEnBas(speed);
                        m.y += speed;
                        if (!collisionBambou)
                            personnage.rect.Y += speed;
                        foreach (Decor c in liste_decor)
                            c.y += speed;
                        foreach (ElementInteractifGeneral c in liste_ElementInteractif)
                            c.y += speed;
                        foreach (Parchment p in liste_parchment)
                            p.Y += speed;
                        foreach (Ennemis e in liste_ennemis)
                        {
                            e.y += speed;
                            e.initY += speed;
                        }
                    }

                }
                if (caméraActive && cameraUp)
                {
                    background.vaEnBas(speed);
                    m.y += speed;
                    personnage.rect.Y += speed;
                    foreach (Decor c in liste_decor)
                        c.y += speed;
                    foreach (ElementInteractifGeneral c in liste_ElementInteractif)
                        c.y += speed;
                    foreach (Parchment p in liste_parchment)
                        p.Y += speed;
                    foreach (Ennemis e in liste_ennemis)
                    {
                        e.y += speed;
                        e.initY += speed;
                    }
                }
            }
        }

        public bool VerificationEcranMort()
        {
            foreach (Mort m in liste_mort)
            {
                if (m.downRect.Y <= game.GraphicsDevice.Viewport.Height)
                    return false;
                else
                    return true;

            }
            return true;
        }

        #endregion
    }

     
}