using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Banque
    {
        #region Champs
        private Dictionary<string, Courant> _Comptes = new Dictionary<string, Courant>();
        #endregion

        #region Props
        public string Nom { get; set; }
        #endregion

        #region Indexeur
        public Courant? this[string numero]
        {
            get
            {
                _Comptes.TryGetValue(numero, out Courant? c);
                return c;
            }
        }
        #endregion

        #region Méthodes
        public void Ajouter(Courant compte)
        {
            if(_Comptes.ContainsKey(compte.Numero))
            {
                throw new Exception("Boum !!!");
            }

            _Comptes.Add(compte.Numero, compte);
        }

        public void Supprimer(string numero)
        {
            // Sénario si pas de compte avec ce numero :
            // [ ] Erreur !
            // [•] On ignore -> il n'y a pas de comptes

            _Comptes.Remove(numero);
        }
        #endregion
    }
}
