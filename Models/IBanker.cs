using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public interface IBanker : ICustomer
    {
        Personne Titulaire { get; }
        string Numero { get;  }
        // double LigneDeCredit { get; set; }

        void AppliquerInteret();
    }
}
