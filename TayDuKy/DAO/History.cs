using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TayDuKy.DAO
{
    public class History
    {
        public String id { get; set; }
        public String adminId { get; set; }
        public String casterId { get; set; }
        public String update_time { get; set; }
        public History() { }

        public History(string id, string adminId, string casterId, string update_time)
        {
            this.id = id;
            this.adminId = adminId;
            this.casterId = casterId;
            this.update_time = update_time;
        }
    }
}