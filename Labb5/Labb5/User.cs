using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb5
{
    class User
    {
        public string Namn { set; get; }
        public string Epost { set; get; }

        public override string ToString()
        {
            return Namn;
        }

        public User(string Namn, string Epost)
        {
            this.Namn = Namn;
            this.Epost = Epost;
        }
    }
}
