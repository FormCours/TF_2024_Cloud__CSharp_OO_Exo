using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Courant
    {
        #region Champs
        private double _LigneDeCredit;
        private double _Solde;
        #endregion

        #region Props
        public string Numero { get; set; }

        public double Solde 
        {
            get { return _Solde; }
            private set { _Solde = Math.Round(value, 2); }
        }

        public double LigneDeCredit
        {
            get { return _LigneDeCredit; }
            set 
            { 
                if(value < 0)  { throw new ArgumentException(); }

                _LigneDeCredit = value; 
            }
        }

        public Personne Titulaire { get; set; }
        #endregion

        #region Méthodes
        public void Depot(double montant)
        {
            RaiseExceptionIfNegatif(montant);

            Solde = Solde + montant;
        }

        public void Retrait(double montant)
        {
            RaiseExceptionIfNegatif(montant);

            if(montant > (Solde + LigneDeCredit))
            {
                throw new Exception("Vous n'avez pas assez de thune !");
                // TODO Customiser l'exception =)
            }

            Solde = Solde - montant;
        }

        private void RaiseExceptionIfNegatif(double montant)
        {
            if (montant <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(montant));
                // throw new ArgumentOutOfRangeException("montant"));
            }
        }
        #endregion
    }
}
