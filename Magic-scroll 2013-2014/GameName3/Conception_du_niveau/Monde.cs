using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Magic___Scroll.Elements_Interactif;
using Magic___Scroll.Sortilege;
using Microsoft.Xna.Framework;

namespace Magic___Scroll.Conception_du_niveau
{
    class Monde
    {
        public List<Niveau> ListeDesNiveauxDunMonde = new List<Niveau>();

        public int niveauMax;
        public int numeroDeMonde;

        public int maxX;
        public int maxY;
        public int minX;
        public int minY;

        int valeurXperson = 0;

        public int ValeurSol{get;set;}

        public Monde(int _numeroDeMonde)
        {
            numeroDeMonde = _numeroDeMonde;
            maxX = -100;
            maxY = -100;
            minX = 1000;
            minY = 1000;

            switch (numeroDeMonde)
            {
                case 0:  //Paramétrage du Monde 0 Prologue
                    niveauMax = 5; //Variable indiquant le nombre de niveau
                    for (int i = 1; i <= niveauMax; i++) //Ajout des niveaux dans la liste du monde correspondant
                    {
                        ListeDesNiveauxDunMonde.Add(new Niveau(i, 0));
                    }
                    break;
                case 1:  //Paramétrage du Monde 1
                    niveauMax = 10;
                    for (int i = 1; i <= niveauMax; i++)
                    {
                        ListeDesNiveauxDunMonde.Add(new Niveau(i, 1));
                    }
                    break;
                case 2:  //Paramétrage du Monde 2
                    niveauMax = 2;
                    for (int i = 1; i <= niveauMax; i++)
                    {
                        ListeDesNiveauxDunMonde.Add(new Niveau(i, 2));
                    }
                    break;
                case 3:  //Paramétrage du Monde 3
                    niveauMax = 0;
                    for (int i = 1; i <= niveauMax; i++)
                    {
                        ListeDesNiveauxDunMonde.Add(new Niveau(i, 3));
                    }
                    break;
                case 4:  //Paramétrage du Monde 4
                    niveauMax = 0;
                    for (int i = 1; i <= niveauMax; i++)
                    {
                        ListeDesNiveauxDunMonde.Add(new Niveau(i, 4));
                    }
                    break;
                case 5:  //Paramétrage du Monde 5
                    niveauMax = 0;
                    for (int i = 1; i <= niveauMax; i++)
                    {
                        ListeDesNiveauxDunMonde.Add(new Niveau(i, 5));
                    }
                    break;
                default:
                    break;
            }
        }
        public void chargerElementsInteractif(int _screenHeight, int _screenWidth, Monde _mondeEnCours, int niveauEnCours, List<ElementInteractifGeneral> _liste_ElementInteractif, List<Decor> _liste_decor, List<Ennemis> _liste_ennemis, List<Parchment> _liste_parchment,List<Mort> _liste_Mort,Perso _personnage)
        {
            int ligne = 0;
            int colonne = 0;
            StringBuilder stringToRead = new StringBuilder(); //Récup du niveau
            for (int i = 1; i < _mondeEnCours.ListeDesNiveauxDunMonde[niveauEnCours - 1].detailNiveau.Count; i++)
            {
                stringToRead.AppendLine(_mondeEnCours.ListeDesNiveauxDunMonde[niveauEnCours - 1].detailNiveau[i]);
            }
            
            using (StringReader reader = new StringReader(stringToRead.ToString())) //Conversion du niveau de ligne en liste
            {
                string readText = reader.ReadToEnd();
                for (int i = 0; i < readText.Length; i++)
                {
                    if (readText[i].GetHashCode() >=  'A'.GetHashCode() && readText[i].GetHashCode() <=  'Y'.GetHashCode())
                    {
                        _liste_decor.Add(new Decor(readText[i], _screenHeight, _screenWidth, new Vector2(colonne, ligne), colonne * _screenWidth, ligne * _screenHeight));
                    }
                    if (readText[i].GetHashCode() >= '1'.GetHashCode() && readText[i].GetHashCode() <= '5'.GetHashCode())
                    {
                        _liste_ennemis.Add(new Ennemis(readText[i], _screenHeight, _screenWidth, new Vector2(colonne, ligne), colonne * _screenWidth, ligne * _screenHeight));
                    }
                    if (readText[i].GetHashCode() >= '6'.GetHashCode() && readText[i].GetHashCode() <= '9'.GetHashCode())
                    {
                        _liste_parchment.Add(new Parchment(readText[i].GetHashCode(), colonne * _screenWidth, ligne * _screenHeight, _screenHeight, _screenWidth, new Vector2(colonne, ligne)));
                    }
                    if (readText[i].GetHashCode() == 'a'.GetHashCode())
                        _liste_ElementInteractif.Add(new Bambou(_screenWidth, _screenHeight, false, false, new Vector2(colonne, ligne), colonne * _screenWidth, ligne * _screenHeight));
                    
                    if (readText[i].GetHashCode() == 'b'.GetHashCode())
                        _liste_ElementInteractif.Add(new Ronce(_screenWidth, _screenHeight, false, false, new Vector2(colonne, ligne), colonne * _screenWidth, ligne * _screenHeight));
                    
                    if (readText[i].GetHashCode() == 'c'.GetHashCode())
                        _liste_ElementInteractif.Add(new FeuCamp(_screenWidth, _screenHeight, false, new Vector2(colonne, ligne), colonne * _screenWidth, ligne * _screenHeight));
                    
                    if (readText[i].GetHashCode() == 'd'.GetHashCode())
                        _liste_ElementInteractif.Add(new BlocFriable(_screenWidth, _screenHeight, false, new Vector2(colonne, ligne), colonne * _screenWidth, ligne * _screenHeight));

                    if (readText[i].GetHashCode() == 'e'.GetHashCode())
                        _liste_ElementInteractif.Add(new Fleur(_screenWidth, _screenHeight,false ,new Vector2(colonne, ligne), colonne * _screenWidth, ligne * _screenHeight));

                    if (readText[i].GetHashCode() == 'f'.GetHashCode())
                        _liste_ElementInteractif.Add(new NuagePlateforme(_screenWidth, _screenHeight, false, new Vector2(colonne, ligne), colonne * _screenWidth, ligne * _screenHeight));                    

                    if (readText[i].GetHashCode() == 'h'.GetHashCode())
                        _liste_ElementInteractif.Add(new Familier(_screenWidth, _screenHeight, new Vector2(colonne, ligne), colonne * _screenWidth, ligne * _screenHeight));
                    
                    if (readText[i].GetHashCode() == '@'.GetHashCode())
                    {
                        _personnage.X = _screenWidth * colonne;
                        _personnage.Y = _screenHeight * ligne;
                        _personnage.coordAbsolute.X = _screenWidth * colonne;
                        _personnage.coordAbsolute.Y = _screenHeight * ligne;
                        valeurXperson = colonne;
                    }
                    if (readText[i].GetHashCode() != '0'.GetHashCode() && readText[i].GetHashCode() != '='.GetHashCode() && readText[i].GetHashCode() != '_'.GetHashCode() && readText[i].GetHashCode() != '\r'.GetHashCode() && readText[i].GetHashCode() != '\n'.GetHashCode())
                    {
                        if (maxY < ligne + 1)
                            maxY = ligne + 1;
                        if (maxX < colonne)
                            maxX = colonne;
                        if (minY > ligne + 1)
                            minY = ligne + 1;
                        if (minX > colonne)
                            minX = colonne;
                    }
                    
                    if (readText[i].GetHashCode() == '\n'.GetHashCode())
                    {
                        ligne++;
                        colonne = 0;
                    }
                    else
                    {
                        colonne++;
                    }
                }
                _liste_Mort.Add(new Mort(_screenWidth, _screenHeight, valeurXperson * _screenWidth, ligne * _screenHeight));
                ValeurSol = ligne;
            }
        }
    }
}
