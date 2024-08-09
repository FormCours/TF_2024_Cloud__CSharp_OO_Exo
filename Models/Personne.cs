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
        public string Prenom { get; set; }

        public string Nom { get; set; }

        public DateTime DateNaiss { get; set; }

        public string NomComplet
        {
            get { return Prenom + " " + Nom; }
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
