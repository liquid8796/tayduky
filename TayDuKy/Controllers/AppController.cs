using Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace TayDuKy.Controllers
{
    public class AppController : ApiController
    {
        DataSource db = new DataSource();

        [HttpPost]
        public HttpResponseMessage loginAdmin(string email, string password)
        {
            string user = db.checkLoginAdmin(email, password);
            if (!user.Equals(""))
            {
                return Request.CreateResponse<string>(HttpStatusCode.OK, user);
            }
            return Request.CreateResponse<string>(HttpStatusCode.BadRequest, "error");
        }

        [HttpPost]
        public Boolean addNewProps(string id, string name, string image, string desc, string quantity, string status)
        {
            bool result = db.AddNewProps(id, name, image, desc, quantity, status);
            return result;
        }

        [HttpPost]
        public Boolean addNewCaster(string id, string password, string name, string image, string desc, string phone, string email, string status)
        {
            bool result = db.AddNewCaster(id, password, name, image, desc, phone, email, status);
            return result;
        }

        [HttpPost]
        public Boolean addNewKiepnan(string id, string name, string desc, string location, string start, string end, string record, string status)
        {
            bool result = db.AddNewKiepnan(id, name, desc, location, start, end, record, status);
            return result;
        }
    }
}
