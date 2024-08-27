using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public delegate void Noel(double montant);
    public class ExempleDelegate
    {
        public Noel delegateDeNoel;

        public void declenchementDeNoel(double montant)
        {
            if(delegateDeNoel is not null)
            {
                delegateDeNoel(montant);
            }
        }
    }
}
