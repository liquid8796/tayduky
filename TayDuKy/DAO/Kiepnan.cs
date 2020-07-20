using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TayDuKy.DAO
{
    public class Kiepnan
    {
        public String id { get; set; }
        public String name { get; set; }
        public String desc { get; set; }
        public String location { get; set; }
        public String start { get; set; }
        public String end { get; set; }
        public String record { get; set; }
        public String numCaster { get; set; }
        public String numProps { get; set; }
        public String status { get; set; }
        public Kiepnan() { }

        public Kiepnan(string id, string name, string desc, string location, string start, string end, string record, string status)
        {
            this.id = id;
            this.name = name;
            this.desc = desc;
            this.location = location;
            this.start = start;
            this.end = end;
            this.record = record;
            this.status = status;
        }
    }
}