using Models.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Courant : Compte
    {
        #region Champs
        private double _LigneDeCredit;
        #endregion

        #region Props
        public double LigneDeCredit
        {
            get { return _LigneDeCredit; }
            private set 
            { 
                if(value < 0)  { throw new InvalidOperationException(); }

                _LigneDeCredit = value; 
            }
        }
        #endregion

        #region Constructeurs
        public Courant(string numero, Personne titulaire) : base(numero, titulaire)
        {
        }
        public Courant(string numero, Personne titulaire, double solde) : base(numero, titulaire, solde)
        {
        }
        public Courant(string numero, Personne titulaire, double solde, double ligneDeCredit) : this(numero, titulaire, solde)
        {
            LigneDeCredit = ligneDeCredit;
        }
        #endregion

        #region Méthodes
        public override void Retrait(double montant)
        {
            if(montant > (Solde + LigneDeCredit))
            {
                throw new SoldeInsuffisantException();
                // TODO Customiser l'exception =)
            }

            base.Retrait(montant);
        }
        protected override double CalculInteret()
        {
            return (Solde < 0) ? Solde * 0.0975 : Solde * 0.03;
        }

        #endregion

        #region Surcharge d'operateur
        public static double operator +(Courant c1, Courant c2)
        {
            double solde1 = c1.Solde > 0 ? c1.Solde : 0;
            double solde2 = Math.Max(c2.Solde, 0);

            return solde1 + solde2;
        }

        public static double operator +(double left, Courant rigth)
        {
            return left + Math.Max(rigth.Solde, 0);
        }

        public static double operator +(Courant rigth, double left)
        {
            return left + rigth;
        }
        #endregion
    }
}
