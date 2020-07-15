using Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace TayDuKy.Controllers
{
    public class LoginController : ApiController
    {
        DataSource db = new DataSource();
        // GET api/login/
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
        public Boolean loginAdmin(string id, string name, string image, string desc, string quantity, string status)
        {
            bool result = db.AddNewProps(id, name, image, desc, quantity, status);
            return result;
        }
    }
}
