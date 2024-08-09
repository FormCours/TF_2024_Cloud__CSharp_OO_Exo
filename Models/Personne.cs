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

    }
}
