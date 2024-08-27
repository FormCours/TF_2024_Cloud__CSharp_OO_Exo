using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Personne
    {
        #region Props
        public string Prenom { get; private set; }

        public string Nom { get; private set; }

        public DateTime DateNaiss { get; private set; }

        public string NomComplet
        {
            get { return Prenom + " " + Nom; }
        }
        #endregion

        #region Constructeurs
        public Personne(string prenom, string nom, DateTime dateNaiss)
        {
            Prenom = prenom;
            Nom = nom;
            DateNaiss = dateNaiss;
        }
        #endregion

        #region Surcharge
        public static bool operator ==(Personne? left, Personne? right)
        {
            if (left is null && right is null)
                return true;

            if (left is null || right is null)
                return false;

            return left.Prenom == right.Prenom
                && left.Nom == right.Nom
                && left.DateNaiss == right.DateNaiss;
        }

        public static bool operator !=(Personne? left, Personne? right)
        {
            return !(left == right);
        }
        #endregion
    }
}
