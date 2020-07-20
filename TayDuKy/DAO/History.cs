using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TayDuKy.DAO
{
    public class History
    {
        public String admin { get; set; }
        public String caster { get; set; }
        public String update_time { get; set; }
        public History() { }

        public History(string admin, string caster, string update_time)
        {
            this.admin = admin;
            this.caster = caster;
            this.update_time = update_time;
        }
    }
}