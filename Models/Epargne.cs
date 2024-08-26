using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Epargne : Compte
    {
        #region Props
        public DateTime? DateDernierRetrait { get; private set; }
        #endregion

        #region Méthodes
        public override void Retrait(double montant)
        {
            if (Solde - montant < 0)
            {
                throw new Exception("Votre compte epargne ne peut pas passer en négatif :o");
            }

            base.Retrait(montant);
            DateDernierRetrait = DateTime.Now;
        }

        protected override double CalculInteret()
        {
            return Solde * 0.045;
        }
        #endregion
    }
}
