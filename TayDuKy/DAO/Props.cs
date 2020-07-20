using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TayDuKy.DAO
{
    public class Props
    {
        public String id { get; set; }
        public String name { get; set; }
        public String image { get; set; }
        public String desc { get; set; }
        public String quantity { get; set; }
        public String ins_date { get; set; }
        public String status { get; set; }
        public Props() { }

        public Props(string id, string name, string image, string desc, string quantity, string status)
        {
            this.id = id;
            this.name = name;
            this.image = image;
            this.desc = desc;
            this.quantity = quantity;
            this.status = status;
        }
    }
}