using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magic___Scroll.Conception_du_niveau
{
    class Niveau
    {
        public int numeroDeMonde { get; set; }
        public int numeroDeNiveau { get; set; }
        public int nbParcheminT { get; set; }
        public int nbParcheminF { get; set; }
        public int nbParcheminE { get; set; }
        public int nbParcheminA { get; set; }
        public List<string> detailNiveau;

        public Niveau(int _numeroDeNiveau, int _numeroDeMonde) //Pour l'ajout d'un monde ajouter un case dans le switch
        {
            numeroDeMonde = _numeroDeMonde;
            numeroDeNiveau = _numeroDeNiveau;
            switch (numeroDeMonde)
            {
                case 0:
                    detailNiveau = RécupNiveauMonde0();
                    break;
                case 1:
                    detailNiveau = RécupNiveauMonde1();
                    break;
                case 2:
                    detailNiveau = RécupNiveauMonde2();
                    break;
            }
        }

        private List<string> RécupNiveauMonde0()  //Monde 0
        {
            List<string> niveauMonde0 = new List<string>();
            switch (numeroDeNiveau) //Ce switch sert à mettre un nouveau niveau dans le monde /!\ vérifier variable niveauMax dans Monde.cs pour tout ajout
            {
                case 1:
                    #region Monde 0 Niveau 1
                    niveauMonde0.Add("00000000000000000000000000_");
                    niveauMonde0.Add("00000000000000000000000000_");
                    niveauMonde0.Add("00000000000000000000000000_");
                    niveauMonde0.Add("00000000000000000000000000_");
                    niveauMonde0.Add("00000000000000000000000000_");
                    niveauMonde0.Add("0000000000ACBCE00000000000_");
                    niveauMonde0.Add("00000000000000000000000000_");
                    niveauMonde0.Add("0000000000a000000000000000_");
                    niveauMonde0.Add("000000ADCBCE0000000h000000_");
                    niveauMonde0.Add("00@000000000000ACBDDE00000_");
                    niveauMonde0.Add("000000a0000000000000000000_");
                    niveauMonde0.Add("0ABBCDCE000000000000000000_");
                    niveauMonde0.Add("00000000000000000000000000_");
                    niveauMonde0.Add("00000000000000000000000000_");
                    niveauMonde0.Add("00000000000000000000000000_");
                    niveauMonde0.Add("00000000000000000000000000_");
                    niveauMonde0.Add("00000000000000000000000000_");
                    niveauMonde0.Add("0=000000000000000000000000_");
                    nbParcheminA = 3;
                    nbParcheminE = 3;
                    nbParcheminF = 3;
                    nbParcheminT = 3;
                    #endregion
                    break;
                case 2:
                    #region Monde 0 Niveau 2
                    niveauMonde0.Add("000000000000000000000000000000_");
                    niveauMonde0.Add("000000000000000000000000000000_");
                    niveauMonde0.Add("000000000000000000000000000000_");
                    niveauMonde0.Add("000000000000000000000000000000_");
                    niveauMonde0.Add("000000000000000000000000000000_");
                    niveauMonde0.Add("000000000000000000000000000000_");
                    niveauMonde0.Add("000000000000000000000000000000_");
                    niveauMonde0.Add("00000000000000000000000h000000_");
                    niveauMonde0.Add("0000000000000000ABCBDCBDCE0000_");
                    niveauMonde0.Add("0000@0000000000000000000000000_");
                    niveauMonde0.Add("00000000b0b000b00a000000000000_");
                    niveauMonde0.Add("00ADBDCCDBCBBCDCDCDE0000000000_");
                    niveauMonde0.Add("000000000000000000000000000000_");
                    niveauMonde0.Add("000000000000000000000000000000_");
                    niveauMonde0.Add("0000=0000000000000000000000000_");
                    niveauMonde0.Add("000000000000000000000000000000_");
                    niveauMonde0.Add("000000000000000000000000000000_");
                    niveauMonde0.Add("000000000000000000000000000000_");
                    niveauMonde0.Add("000000000000000000000000000000_");
                    niveauMonde0.Add("000000000000000000000000000000_");
                    nbParcheminA = 3;
                    nbParcheminE = 3;
                    nbParcheminF = 3;
                    nbParcheminT = 3;
                    #endregion
                    break;
                case 3:
                    #region Monde 0 Niveau 2 //a changer
                    niveauMonde0.Add("000000000000000000000000000000000000000000000000000000000000000000000_");
                    niveauMonde0.Add("000000000000000000000000000000000000000000000000000000000000000000000_");
                    niveauMonde0.Add("000000000000000000000000000000000000000000000000000000000000000000000_");
                    niveauMonde0.Add("000000000000000000000000000000000000000000000000000000000000000000000_");
                    niveauMonde0.Add("000000000000000000000000000000000000000000000000000000000000000000000_");
                    niveauMonde0.Add("000000000000000000000000000000000000000000000000000000000000000000000_");
                    niveauMonde0.Add("000000000000000000000000000000000000000000000000000000000000000000000_");
                    niveauMonde0.Add("0000000000000000000000000000000000000000000000000h0000000000000000000_");
                    niveauMonde0.Add("0000000000000000000ABBCBDDCDDCCDBCCDCBCCCDCCCBCCBDCE00000000000000000_");
                    niveauMonde0.Add("0000@0000000000000000000000000000000000000000000000000000000000000000_");
                    niveauMonde0.Add("00000000b0b000b00000a000000000000000000000000000000000000000000000000_");
                    niveauMonde0.Add("00ADBDCCDBCBBCDCBBCDCCDE000000000000000000000000000000000000000000000_");
                    niveauMonde0.Add("000000000000000000000000000000000000000000000000000000000000000000000_");
                    niveauMonde0.Add("0000=0000000000000000000000000000000000000000000000000000000000000000_");
                    niveauMonde0.Add("000000000000000000000000000000000000000000000000000000000000000000000_");
                    niveauMonde0.Add("000000000000000000000000000000000000000000000000000000000000000000000_");
                    niveauMonde0.Add("000000000000000000000000000000000000000000000000000000000000000000000_");
                    niveauMonde0.Add("000000000000000000000000000000000000000000000000000000000000000000000_");
                    niveauMonde0.Add("000000000000000000000000000000000000000000000000000000000000000000000_");
                    niveauMonde0.Add("000000000000000000000000000000000000000000000000000000000000000000000_");
                    nbParcheminA = 3;
                    nbParcheminE = 3;
                    nbParcheminF = 3;
                    nbParcheminT = 3;
                    #endregion
                    break;
                case 4:
                    #region Monde 0 Niveau 2 //a changer
                    niveauMonde0.Add("000000000000000000000000000000000000000000000000000000000000000000000_");
                    niveauMonde0.Add("000000000000000000000000000000000000000000000000000000000000000000000_");
                    niveauMonde0.Add("000000000000000000000000000000000000000000000000000000000000000000000_");
                    niveauMonde0.Add("000000000000000000000000000000000000000000000000000000000000000000000_");
                    niveauMonde0.Add("000000000000000000000000000000000000000000000000000000000000000000000_");
                    niveauMonde0.Add("000000000000000000000000000000000000000000000000000000000000000000000_");
                    niveauMonde0.Add("000000000000000000000000000000000000000000000000000000000000000000000_");
                    niveauMonde0.Add("0000000000000000000000000000000000000000000000000h0000000000000000000_");
                    niveauMonde0.Add("0000000000000000000ABBCBDDCDDCCDBCCDCBCCCDCCCBCCBDCE00000000000000000_");
                    niveauMonde0.Add("0000@0000000000000000000000000000000000000000000000000000000000000000_");
                    niveauMonde0.Add("00000000b0b000b00000a000000000000000000000000000000000000000000000000_");
                    niveauMonde0.Add("00ADBDCCDBCBBCDCBBCDCCDE000000000000000000000000000000000000000000000_");
                    niveauMonde0.Add("000000000000000000000000000000000000000000000000000000000000000000000_");
                    niveauMonde0.Add("000000000000000000000000000000000000000000000000000000000000000000000_");
                    niveauMonde0.Add("0000=0000000000000000000000000000000000000000000000000000000000000000_");
                    niveauMonde0.Add("000000000000000000000000000000000000000000000000000000000000000000000_");
                    niveauMonde0.Add("000000000000000000000000000000000000000000000000000000000000000000000_");
                    niveauMonde0.Add("000000000000000000000000000000000000000000000000000000000000000000000_");
                    niveauMonde0.Add("000000000000000000000000000000000000000000000000000000000000000000000_");
                    niveauMonde0.Add("000000000000000000000000000000000000000000000000000000000000000000000_");
                    nbParcheminA = 3;
                    nbParcheminE = 3;
                    nbParcheminF = 3;
                    nbParcheminT = 3;
                    #endregion
                    break;
                case 5:
                    #region Monde 0 Niveau 2 //a changer
                    niveauMonde0.Add("000000000000000000000000000000000000000000000000000000000000000000000_");
                    niveauMonde0.Add("000000000000000000000000000000000000000000000000000000000000000000000_");
                    niveauMonde0.Add("000000000000000000000000000000000000000000000000000000000000000000000_");
                    niveauMonde0.Add("000000000000000000000000000000000000000000000000000000000000000000000_");
                    niveauMonde0.Add("000000000000000000000000000000000000000000000000000000000000000000000_");
                    niveauMonde0.Add("000000000000000000000000000000000000000000000000000000000000000000000_");
                    niveauMonde0.Add("000000000000000000000000000000000000000000000000000000000000000000000_");
                    niveauMonde0.Add("0000000000000000000000000000000000000000000000000h0000000000000000000_");
                    niveauMonde0.Add("0000000000000000000ABBCBDDCDDCCDBCCDCBCCCDCCCBCCBDCE00000000000000000_");
                    niveauMonde0.Add("0000@0000000000000000000000000000000000000000000000000000000000000000_");
                    niveauMonde0.Add("00000000b0b000b00000a000000000000000000000000000000000000000000000000_");
                    niveauMonde0.Add("00ADBDCCDBCBBCDCBBCDCCDE000000000000000000000000000000000000000000000_");
                    niveauMonde0.Add("000000000000000000000000000000000000000000000000000000000000000000000_");
                    niveauMonde0.Add("0000=0000000000000000000000000000000000000000000000000000000000000000_");
                    niveauMonde0.Add("000000000000000000000000000000000000000000000000000000000000000000000_");
                    niveauMonde0.Add("000000000000000000000000000000000000000000000000000000000000000000000_");
                    niveauMonde0.Add("000000000000000000000000000000000000000000000000000000000000000000000_");
                    niveauMonde0.Add("000000000000000000000000000000000000000000000000000000000000000000000_");
                    niveauMonde0.Add("000000000000000000000000000000000000000000000000000000000000000000000_");
                    niveauMonde0.Add("000000000000000000000000000000000000000000000000000000000000000000000_");
                    nbParcheminA = 3;
                    nbParcheminE = 3;
                    nbParcheminF = 3;
                    nbParcheminT = 3;
                    #endregion
                    break;
            }

            return niveauMonde0;
        }

        private List<string> RécupNiveauMonde1()  //Monde 1
        {
            List<string> niveauMonde1 = new List<string>();
            switch (numeroDeNiveau) //Ce switch sert à mettre un nouveau niveau dans le monde /!\ vérifier variable niveauMax dans Monde.cs pour tout ajout
            {
                case 1:
                    #region Monde 1 Niveau 1
                    niveauMonde1.Add("00000000000000000000000000000000_");
                    niveauMonde1.Add("00000000000000000000000000000000_");
                    niveauMonde1.Add("00000000000000000000000000000000_");
                    niveauMonde1.Add("00000000000000000000000000000000_");
                    niveauMonde1.Add("00000000000000000000000000000000_");
                    niveauMonde1.Add("00000000000000000000000000000000_");
                    niveauMonde1.Add("00000000h00000000000000000000000_");
                    niveauMonde1.Add("000000AdE000ABCCDBCE000000000000_");
                    niveauMonde1.Add("00000000@00000000000000000000000_");
                    niveauMonde1.Add("00e0eea000i0a000000a088000000000_");
                    niveauMonde1.Add("00ABCCDBCDDCEf0000ACDBE000000000_");
                    niveauMonde1.Add("00000000000000000000000000000000_");
                    niveauMonde1.Add("000000000000ACdDDBE0060a00000000_");
                    niveauMonde1.Add("00000000000000000000ACBBE0000000_");
                    niveauMonde1.Add("00000000000000000000000000000000_");
                    niveauMonde1.Add("00000000600000000060a00000000000_");
                    niveauMonde1.Add("0000000ACBCCBBBDCDCCE00000000000_");
                    niveauMonde1.Add("00000000000000000000000000000000_");
                    niveauMonde1.Add("00000000000000000000000000000000_");
                    niveauMonde1.Add("00000000000000000000000000000000_");           
                    nbParcheminA = 1;
                    nbParcheminE = 2;
                    nbParcheminF = 1;
                    nbParcheminT = 2;
                    #endregion
                    break;
                case 2:
                    #region Monde 1 Niveau 2
                    niveauMonde1.Add("00000000000000000000000000000000_");
                    niveauMonde1.Add("00000000000000000000000000000000_");
                    niveauMonde1.Add("00000000000000000000000000000000_");
                    niveauMonde1.Add("00000000000000000000000000000000_");
                    niveauMonde1.Add("00000000000000000000000000000000_");
                    niveauMonde1.Add("0000000000a0000000h0000000000000_");
                    niveauMonde1.Add("0000ACDDBCE00000ACCE000000000000_");
                    niveauMonde1.Add("00@00000000000000000000000000000_");
                    niveauMonde1.Add("0000a0000000000ba000000000000000_");
                    niveauMonde1.Add("00ABCE00000ACDDCDE00000000000000_");
                    niveauMonde1.Add("00000000000000000000000000000000_");
                    niveauMonde1.Add("00000000670000000000000000000000_");
                    niveauMonde1.Add("00000000ABBE00000000000000000000_");
                    niveauMonde1.Add("00000000000000000000000000000000_");
                    niveauMonde1.Add("00000000000000000000000000000000_");
                    niveauMonde1.Add("00000000000000000000000000000000_");
                    niveauMonde1.Add("00000000000000000000000000000000_");
                    niveauMonde1.Add("00000000000000000000000000000000_");
                    niveauMonde1.Add("00000000000000000000000000000000_");
                    niveauMonde1.Add("00=00000000000000000000000000000_");
                    nbParcheminA = 2;
                    nbParcheminE = 2;
                    nbParcheminF = 0;
                    nbParcheminT = 0;
                    #endregion
                    break;
                case 3:
                    #region Monde 1 Niveau 3
                    niveauMonde1.Add("0000000000000000000000000000000000_");
                    niveauMonde1.Add("0000000000000000000000000000000000_");
                    niveauMonde1.Add("0000000000000000000000000000000000_");
                    niveauMonde1.Add("0000000000000000070000000000000000_");
                    niveauMonde1.Add("000000000000000ACBBCDE000000000000_");
                    niveauMonde1.Add("0000000000000000000000000000000000_");
                    niveauMonde1.Add("000008800000000bh000a0000000066000_");
                    niveauMonde1.Add("0000ABBCE0000ACBCCdDE0000ACdBDE000_");
                    niveauMonde1.Add("0000000000000000000000000000000000_");
                    niveauMonde1.Add("00000000a0660a000000a00000a0000000_");
                    niveauMonde1.Add("00000000ACDBCE000000ACDDCBCCE00000_");
                    niveauMonde1.Add("0000000000000000@00000000000000000_");
                    niveauMonde1.Add("0000000000000a000000a0000000000000_");
                    niveauMonde1.Add("0000000000000ABCCDDBE0000000000000_");
                    niveauMonde1.Add("0000000000000000000000000000000000_");
                    niveauMonde1.Add("0000000000000000000000000000000000_");
                    niveauMonde1.Add("0000000000000000000000000000000000_");
                    niveauMonde1.Add("0000000000000000000000000000000000_");
                    niveauMonde1.Add("0000000000000000000000000000000000_");
                    niveauMonde1.Add("0000000000000000=00000000000000000_");
                    nbParcheminA = 1;
                    nbParcheminE = 2;
                    nbParcheminF = 0;
                    nbParcheminT = 0;
                    #endregion
                    break;
                case 4:
                    #region Monde 1 Niveau 4
                    niveauMonde1.Add("0000000000000000000000000000_");
                    niveauMonde1.Add("0000000000000000000000000000_");
                    niveauMonde1.Add("0000000000000000000000000000_");
                    niveauMonde1.Add("0000000000000000000000000000_");
                    niveauMonde1.Add("0000000000000000000000000000_");
                    niveauMonde1.Add("0000000000000000000000800000_");
                    niveauMonde1.Add("0000000ACCBdDCDDBCDDCBCDBE00_");
                    niveauMonde1.Add("00@0000000000000000000000000_");
                    niveauMonde1.Add("0000000a00000000a00000000h00_");
                    niveauMonde1.Add("0ABCCDBDCDBCDCdDCBCDBBdCCE00_");
                    niveauMonde1.Add("0000000000000000000000000000_");
                    niveauMonde1.Add("0000000000000000000a00008000_");
                    niveauMonde1.Add("000000000000ABCDBDCBBCDCDE00_");
                    niveauMonde1.Add("0000000000000000000000000000_");
                    niveauMonde1.Add("0000000000000000000000000000_");
                    niveauMonde1.Add("0000000000000000000000000000_");
                    niveauMonde1.Add("0000000000000000000000000000_");
                    niveauMonde1.Add("0000000000000000000000000000_");
                    niveauMonde1.Add("0000000000000000000000000000_");
                    niveauMonde1.Add("00=0000000000000000000000000_");
                    nbParcheminA = 0;
                    nbParcheminE = 2;
                    nbParcheminF = 1;
                    nbParcheminT = 0;
                    #endregion
                    break;
                case 5:
                    #region Monde 1 Niveau 5
                    niveauMonde1.Add("000000000000000000_");
                    niveauMonde1.Add("000000000000000000_");
                    niveauMonde1.Add("000000000000000000_");
                    niveauMonde1.Add("000000000000000000_");
                    niveauMonde1.Add("000000000000000000_");
                    niveauMonde1.Add("0@0000000000000000_");
                    niveauMonde1.Add("000000000000000000_");
                    niveauMonde1.Add("0ABCDE000000h00000_");
                    niveauMonde1.Add("0000000000ACBE0000_");
                    niveauMonde1.Add("000000000000000000_");
                    niveauMonde1.Add("0000b0000a00000000_");
                    niveauMonde1.Add("0000ACCCBCBCBDE000_");
                    niveauMonde1.Add("000000000000000000_");
                    niveauMonde1.Add("0600001000000a0000_");
                    niveauMonde1.Add("0ACCDCdBCE0ABCBE00_");
                    niveauMonde1.Add("000000000000000000_");
                    niveauMonde1.Add("000000000009a00000_");
                    niveauMonde1.Add("000000000ABDBE0000_");
                    niveauMonde1.Add("000000000000000000_");
                    niveauMonde1.Add("0=0000000000000000_");
                    nbParcheminA = 0;
                    nbParcheminE = 2;
                    nbParcheminF = 2;
                    nbParcheminT = 2;
                    #endregion
                    break;
                case 6:
                    #region Monde 1 Niveau 6
                    niveauMonde1.Add("0000000000000000000_");
                    niveauMonde1.Add("0000000000000000000_");
                    niveauMonde1.Add("0000000000000000000_");
                    niveauMonde1.Add("0000000000000000000_");
                    niveauMonde1.Add("000@000000000000000_");
                    niveauMonde1.Add("000000000000b00h000_");
                    niveauMonde1.Add("00ABCDCdBBCDCdBBE00_");
                    niveauMonde1.Add("0000000000000000000_");
                    niveauMonde1.Add("0000a00006000000000_");
                    niveauMonde1.Add("00ACBBCDCBE00000000_");
                    niveauMonde1.Add("0000000000000000000_");
                    niveauMonde1.Add("0000000000000000000_");
                    niveauMonde1.Add("0000000000000000000_");
                    niveauMonde1.Add("0000000000000000000_");
                    niveauMonde1.Add("0000000000000000000_");
                    niveauMonde1.Add("0000000000000000000_");
                    niveauMonde1.Add("0000000000000000000_");
                    niveauMonde1.Add("0000000000000000000_");
                    niveauMonde1.Add("0000000000000000000_");
                    niveauMonde1.Add("000=000000000000000_");
                    nbParcheminA = 0;
                    nbParcheminE = 0;
                    nbParcheminF = 1;
                    nbParcheminT = 3;
                    #endregion
                    break;
                case 7:
                    #region Monde 1 Niveau 7
                    niveauMonde1.Add("00000000000000000000_");
                    niveauMonde1.Add("00000000000000000000_");
                    niveauMonde1.Add("00000000000000000000_");
                    niveauMonde1.Add("00000000000000000000_");
                    niveauMonde1.Add("00000000000000000000_");
                    niveauMonde1.Add("000000000000000bh000_");
                    niveauMonde1.Add("00ABBCdCDBDCCBDDCE00_");
                    niveauMonde1.Add("00000000000000000000_");
                    niveauMonde1.Add("0000000000000a000000_");
                    niveauMonde1.Add("000000000ACBDCE00000_");
                    niveauMonde1.Add("000@0000000000000000_");
                    niveauMonde1.Add("000000000a0000000000_");
                    niveauMonde1.Add("00ACDDBCDCE000000000_");
                    niveauMonde1.Add("00000000000000000000_");
                    niveauMonde1.Add("00000000000000000000_");
                    niveauMonde1.Add("00000000000000000000_");
                    niveauMonde1.Add("00000000000000000000_");
                    niveauMonde1.Add("00000000000000000000_");
                    niveauMonde1.Add("00000000000000000000_");
                    niveauMonde1.Add("000=0000000000000000_");
                    nbParcheminA = 0;
                    nbParcheminE = 2;
                    nbParcheminF = 1;
                    nbParcheminT = 0;
                    #endregion
                    break;

                case 8:
                    #region Monde 1 Niveau 8
                    niveauMonde1.Add("00000000000000000000000000000_");
                    niveauMonde1.Add("00000000000000000000000000000_");
                    niveauMonde1.Add("00000000000000000000000000000_");
                    niveauMonde1.Add("00000000000000000000000000000_");
                    niveauMonde1.Add("000000000000000000h0000000000_");
                    niveauMonde1.Add("0000000000ACBdCCBCDDBE0000000_");
                    niveauMonde1.Add("00000000000000000000000000000_");
                    niveauMonde1.Add("0000000070a0000000000a0000000_");
                    niveauMonde1.Add("0000000ADBCE0000000ABCCE00000_");
                    niveauMonde1.Add("000@0000000000000000000000000_");
                    niveauMonde1.Add("0000000a000000000000a00a00000_");
                    niveauMonde1.Add("00ACCBBCCCDDACdDCBBDE00ADE000_");
                    niveauMonde1.Add("0000000000000000000000000000_");
                    niveauMonde1.Add("00000000000000000000009867600_");
                    niveauMonde1.Add("00000000000000000000ACCBCBE00_");
                    niveauMonde1.Add("00000000000000000000000000000_");
                    niveauMonde1.Add("00000000000000000000000000000_");
                    niveauMonde1.Add("00000000000000000000000000000_");
                    niveauMonde1.Add("00000000000000000000000000000_");
                    niveauMonde1.Add("000=0000000000000000000000000_");
                    nbParcheminA = 0;
                    nbParcheminE = 2;
                    nbParcheminF = 1;
                    nbParcheminT = 0;
                    #endregion
                    break;

                case 9:
                    #region Monde 1 Niveau 9
                    niveauMonde1.Add("00000000000000000_");
                    niveauMonde1.Add("00000000000000000_");
                    niveauMonde1.Add("000000@0000000000_");
                    niveauMonde1.Add("0000hb00000000000_");
                    niveauMonde1.Add("0000ACCE000000000_");
                    niveauMonde1.Add("00000000000000000_");
                    niveauMonde1.Add("0000000a000700000_");
                    niveauMonde1.Add("0000000ACdBDE0000_");
                    niveauMonde1.Add("00000000000000000_");
                    niveauMonde1.Add("000000000000a0000_");
                    niveauMonde1.Add("00000ABDCDCCBE000_");
                    niveauMonde1.Add("00000000000000000_");
                    niveauMonde1.Add("00070a00000000000_");
                    niveauMonde1.Add("000ACE00000000000_");
                    niveauMonde1.Add("00000000000000000_");
                    niveauMonde1.Add("00000000000000000_");
                    niveauMonde1.Add("00000000000000000_");
                    niveauMonde1.Add("00000000000000000_");
                    niveauMonde1.Add("00000000000000000_");
                    niveauMonde1.Add("000000=0000000000_");
                    nbParcheminA = 0;
                    nbParcheminE = 2;
                    nbParcheminF = 1;
                    nbParcheminT = 0;
                    #endregion
                    break;

                case 10:
                    #region Monde 1 Niveau 10
                    niveauMonde1.Add("00000000000000_");
                    niveauMonde1.Add("00000000000000_");
                    niveauMonde1.Add("00000000000000_");
                    niveauMonde1.Add("00000000000000_");
                    niveauMonde1.Add("00000000000000_");
                    niveauMonde1.Add("00000000000000_");
                    niveauMonde1.Add("00000000000000_");
                    niveauMonde1.Add("00000000000000_");
                    niveauMonde1.Add("00000000000000_");
                    niveauMonde1.Add("00000000000000_");
                    niveauMonde1.Add("00000000000000_");
                    niveauMonde1.Add("0000000bcbbh00_");
                    niveauMonde1.Add("0000000ADCBE00_");
                    niveauMonde1.Add("00000@00000000_");
                    niveauMonde1.Add("000000ea000000_");
                    niveauMonde1.Add("0000ACBBE00000_");
                    niveauMonde1.Add("00000000000000_");
                    niveauMonde1.Add("00000000000000_");
                    niveauMonde1.Add("00000000000000_");
                    niveauMonde1.Add("00000=00000000_");
                    nbParcheminA = 2;
                    nbParcheminE = 2;
                    nbParcheminF = 1;
                    nbParcheminT = 0;
                    #endregion
                    break;
            }

            return niveauMonde1;
        }

        private List<string> RécupNiveauMonde2()  //Monde 2
        {
            List<string> niveauMonde2 = new List<string>();
            switch (numeroDeNiveau) //Ce switch sert à mettre un nouveau niveau dans le monde /!\ vérifier variable niveauMax dans Monde.cs pour tout ajout
           
{
                case 1:
                    #region Monde 2 Niveau 1
                    niveauMonde2.Add("00000000000000_");
                    niveauMonde2.Add("00000000000000_");
                    niveauMonde2.Add("0000000@000000_");
                    niveauMonde2.Add("00000000000000_");
                    niveauMonde2.Add("000000KNMlO000_");
                    niveauMonde2.Add("00000600000000_");
                    niveauMonde2.Add("00000KlkNMO000_");
                    niveauMonde2.Add("00h00060000000_");
                    niveauMonde2.Add("00KlkNO0000000_");
                    niveauMonde2.Add("00000000000000_");
                    niveauMonde2.Add("00000000000000_");
                    nbParcheminA = 0;
                    nbParcheminE = 0;
                    nbParcheminF = 0;
                    nbParcheminT = 0;
                    #endregion
                    break;
                case 2:
                    #region Monde 2 Niveau 2
                    niveauMonde2.Add("000000000000000000000_");
                    niveauMonde2.Add("000000000800000006000_");
                    niveauMonde2.Add("00000000KMkO0KkLNO000_");
                    niveauMonde2.Add("000000000000000000000_");
                    niveauMonde2.Add("0000000i0086j0000h000_");
                    niveauMonde2.Add("000000@KO0KMO000KO000_");
                    niveauMonde2.Add("000000000000000000000_");
                    niveauMonde2.Add("000000000i00008j00000_");
                    niveauMonde2.Add("000000KMLNO000KO00000_");
                    niveauMonde2.Add("000000000000000000000_");
                    niveauMonde2.Add("000000000000000000000_");
                    nbParcheminA = 1;
                    nbParcheminE = 0;
                    nbParcheminF = 1;
                    nbParcheminT = 1;
                    #endregion
                    break;
                case 3:
                    #region Monde 2 Niveau 3
                    niveauMonde2.Add("000000000000000000000_");
                    niveauMonde2.Add("000000000000000000000_");
                    niveauMonde2.Add("000000000000000000000_");
                    niveauMonde2.Add("000000000000000000000_");
                    niveauMonde2.Add("000000@00000000000000_");
                    niveauMonde2.Add("000000000000000800000_");
                    niveauMonde2.Add("000000000000000000000_");
                    niveauMonde2.Add("000000KO0KMLMNkO00000_");
                    niveauMonde2.Add("000000000000000000000_");
                    niveauMonde2.Add("00000000j000000000000_");
                    niveauMonde2.Add("00000KMkO0KO0000h0000_");
                    niveauMonde2.Add("000000000000000KO0000_");
                    niveauMonde2.Add("000000006i06800000000_");
                    niveauMonde2.Add("0000000KLMlNO0j000000_");
                    niveauMonde2.Add("00000000000000KO00000_");
                    niveauMonde2.Add("000000000000000000000_");
                    niveauMonde2.Add("000000000000000000000_");
                    niveauMonde2.Add("000000000000000000000_");
                    niveauMonde2.Add("000000000000000000000_");
                    nbParcheminA = 1;
                    nbParcheminE = 2;
                    nbParcheminF = 0;
                    nbParcheminT = 0;
                    #endregion
                    break;
                case 4:
                    #region Monde 2 Niveau 4
                    niveauMonde2.Add("000000000000000000000_");
                    niveauMonde2.Add("000000000000000000000_");
                    niveauMonde2.Add("000000000000000000000_");
                    niveauMonde2.Add("000000000000000000000_");
                    niveauMonde2.Add("000000000000000000000_");
                    niveauMonde2.Add("000006000000000000000_");
                    niveauMonde2.Add("000@0KMkO000000000000_");
                    niveauMonde2.Add("000000000009000000000_");
                    niveauMonde2.Add("000000000iKO0000h0000_");
                    niveauMonde2.Add("000KklO0KO0000KlO0000_");
                    niveauMonde2.Add("000000000000000000000_");
                    niveauMonde2.Add("0000008j80086j0000000_");
                    niveauMonde2.Add("00000KMNO00KLO0000000_");
                    niveauMonde2.Add("000000000000000000000_");
                    niveauMonde2.Add("000000000000000000000_");
                    niveauMonde2.Add("000000000000000000000_");
                    niveauMonde2.Add("000000000000000000000_");
                    niveauMonde2.Add("000000000000000000000_");
                    niveauMonde2.Add("000000000000000000000_");
                    nbParcheminA = 0;
                    nbParcheminE = 2;
                    nbParcheminF = 0;
                    nbParcheminT = 1;
                    #endregion
                    break; 
                case 5:
                    #region Monde 2 Niveau 5
                    niveauMonde2.Add("000000000000000000000_");
                    niveauMonde2.Add("000000000000000000000_");
                    niveauMonde2.Add("0000000h0000000000000_");
                    niveauMonde2.Add("000000KNO000000000000_");
                    niveauMonde2.Add("000000000000000000000_");
                    niveauMonde2.Add("00000j000i00000000000_");
                    niveauMonde2.Add("0000KO000KkO000000000_");
                    niveauMonde2.Add("000000000000000000000_");
                    niveauMonde2.Add("000j000000i0000000000_");
                    niveauMonde2.Add("000KkO0000KLO00000000_");
                    niveauMonde2.Add("000000000000000000000_");
                    niveauMonde2.Add("00i000i000000j0000000_");
                    niveauMonde2.Add("00KlO0KO0KMkNO0000000_");
                    niveauMonde2.Add("000000000000000000000_");
                    niveauMonde2.Add("00000000j000000000000_");
                    niveauMonde2.Add("0000000KNO00000000000_");
                    niveauMonde2.Add("000000000000000000000_");
                    niveauMonde2.Add("000000i000j0000000000_");
                    niveauMonde2.Add("0000KkO000KlO00000000_");
                    niveauMonde2.Add("000000000000000000000_");
                    niveauMonde2.Add("000j000000000i0000000_");
                    niveauMonde2.Add("000KlNlO0KkkMO0000000_");
                    niveauMonde2.Add("000000000000000000000_");
                    niveauMonde2.Add("00000000j0i0000000000_");
                    niveauMonde2.Add("0000000KNLO0000000000_");
                    niveauMonde2.Add("000000000000000000000_");
                    niveauMonde2.Add("000000i00@0i000000000_");
                    niveauMonde2.Add("00000KO0000KO00000000_");
                    niveauMonde2.Add("000000000000000000000_");
                    niveauMonde2.Add("0000i886KO987i0000000_");
                    niveauMonde2.Add("0000KMNO00KLMO0000000_");
                    niveauMonde2.Add("000000000000000000000_");
                    niveauMonde2.Add("000000000000000000000_");
                    nbParcheminA = 2;
                    nbParcheminE = 3;
                    nbParcheminF = 1;
                    nbParcheminT = 4;
                    #endregion
                    break;
            }
            return niveauMonde2;
        }
    }
}
