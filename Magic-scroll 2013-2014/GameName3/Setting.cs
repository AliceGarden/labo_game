using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magic___Scroll
{
    class Setting
    {
        // L’instance du singleton. Cette instance doit être privée et statique.
        private static Setting instance = null; 
        // Pour éviter, lors de l’utilisation de multiple thread, que plusieurs singleton soit instanciés.
        private static readonly object myLock = new object();

        // La ressource ? partager.  
        private int _mondeEnCours;
        private int _niveauEnCours;
        private List<List<bool>> _RealisationNivMonde;
        private List<List<bool>> _DisponibilteNivMonde;
        private string _Nom;
        private int _Cheveux;
        private int _Yeux;
        private int _Peau;
        private int _Sexe;
        private bool _SoundActive;
        private Random _random;
        // Des accesseurs pour cette ressources. 

        public int currentWorld { get { return _mondeEnCours; } set { _mondeEnCours = value; } }
        public int currentLevel { get { return _niveauEnCours; } set { _niveauEnCours = value; } }

        public List<List<bool>> RealisationNivMonde { get { return _RealisationNivMonde; } set { _RealisationNivMonde = value; } }
        public List<List<bool>> DisponibiliteNivMonde { get { return _DisponibilteNivMonde; } set { _DisponibilteNivMonde = value; } }

        public string Nom { get { return _Nom; } set { _Nom = value; } }
        public int Cheveux { get { return _Cheveux; } set { _Cheveux = value; } }
        public int Yeux { get { return _Yeux; } set { _Yeux = value; } }
        public int Peau { get { return _Peau; } set { _Peau = value; } }
        public int Sexe { get { return _Sexe; } set { _Sexe = value; } }
        public bool SonActive { get { return _SoundActive; } set { _SoundActive = value; } }
        public Random Random { get { return _random; } set { _random = value; } }

        // Le constructeur d’un singleton est TOUJOURS privée. 
        private Setting() { _random = new Random(); }

        // La méthode qui va nous permettre de récupérer l’unique instance de notre singleton.
        // La méthode doit être statique pour être appelé depuis le nom de la classe maClasse.getInstance();
        public static Setting getInstance() 
        { 
            //lock permet de s’assurer qu’un thread n’entre pas dans une section critique du code pendant qu’un autre thread s’y trouve.  
            //Si un autre thread tente d’entrer dans un code verrouillé, il attendra, bloquera, jusqu’à ce que l’objet soit libéré.
            lock (myLock) 
            { 
                // Si on demande une instance qui n’existe pas, alors on crée notre RessourceManager.
                if (instance == null) instance = new Setting();
                // Dans tous les cas on retourne l’unique instance de notre RessourceManager.
                return instance; 
            } 
        }
    }
}
