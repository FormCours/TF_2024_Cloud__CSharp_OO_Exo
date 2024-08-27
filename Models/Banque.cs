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
        private Dictionary<string, Compte> _Comptes = new Dictionary<string, Compte>();
        #endregion

        #region Props
        public string Nom { get; set; }
        #endregion

        #region Indexeur
        public Compte? this[string numero]
        {
            get
            {
                _Comptes.TryGetValue(numero, out Compte? c);
                return c;
            }
        }
        #endregion

        #region Méthodes
        public void Ajouter(Compte compte)
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

        public double AvoirDesComptes(Personne titulaire)
        {
            // Si on utilise la surchage d'opérateur d'addition entre
            // deux comptes pour réaliser le traitement, cela complexifie
            // la traitement de cette méthode ! 
            //
            // Simplification possible -> Ajouter un autre opérateur !
            // L'opérateur d'addition entre un double et un compte :D

            double total = 0;

            foreach(KeyValuePair<string, Compte> kvp in _Comptes)
            {
                Compte c = kvp.Value;
                if (c.Titulaire == titulaire)
                {
                    total += c;
                }
            }

            return total;
        }

        #endregion
    }
}
