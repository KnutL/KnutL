using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb5
{
    class User
    {
        public string Namn { get; set; }
        public string Epost { get; set; }

        public override string ToString()
        {
            return Namn;
        }

        public User(string Name, string Email)
        {
            Name = Namn;
            Email = Epost;
        }
    }
}
