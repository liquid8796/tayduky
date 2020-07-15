using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TayDuKy.DAO
{
    public class Caster
    {
        public String id { get; set; }
        public String password { get; set; }
        public String name { get; set; }
        public String image { get; set; }
        public String desc { get; set; }
        public String phone { get; set; }
        public String email { get; set; }
        public String status { get; set; }
        public Caster() { }

        public Caster(string id, string password, string name, string image, string desc, string phone, string email, string status)
        {
            this.id = id;
            this.password = password;
            this.name = name;
            this.image = image;
            this.desc = desc;
            this.phone = phone;
            this.email = email;
            this.status = status;
        }
    }
}