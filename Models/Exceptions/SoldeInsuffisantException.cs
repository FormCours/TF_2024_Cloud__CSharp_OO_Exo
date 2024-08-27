using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Exceptions
{
    public class SoldeInsuffisantException : Exception
    {
        public SoldeInsuffisantException() : base("Vous n'avez pas assez de thune !")
        {

        }
        public SoldeInsuffisantException(string message) : base(message)
        {

        }
    }
}
