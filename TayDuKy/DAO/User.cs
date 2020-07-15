using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public class User
    {
        public String user { get; set; }
        public User(){ }
        public User(string user)
        {
            this.user = user;
        }

    }
}
