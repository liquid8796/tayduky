using Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TayDuKy.DAO;

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
        public Boolean addNewCaster(string id, string password, string name, string sex, string image, string desc, string phone, string email, string status)
        {
            bool result = db.AddNewCaster(id, password, name, sex, image, desc, phone, email, status);
            return result;
        }

        [HttpPost]
        public Boolean addNewKiepnan(string id, string name, string desc, string location, string start, string end, string record, string status)
        {
            bool result = db.AddNewKiepnan(id, name, desc, location, start, end, record, status);
            return result;
        }

        [HttpGet]
        public List<Kiepnan> listKiepnan()
        {
            List<Kiepnan> result = db.getAllKiepnan();
            return result;
        }

        [HttpGet]
        public List<Caster> listCaster()
        {
            List<Caster> result = db.getAllCaster();
            return result;
        }

        [HttpGet]
        public List<Props> listProps()
        {
            List<Props> result = db.getAllProps();
            return result;
        }

        [HttpPut]
        public bool updateKiepnan(string id, string name, string desc, string location, string start, string end, string record, string status)
        {
            Kiepnan kiepnan = new Kiepnan(id, name, desc, location, start, end, record, status);
            return db.UpdateMisery(kiepnan);
        }

        [HttpPut]
        public bool updateCaster(string id, string password, string name, string sex, string image, string desc, string phone, string email, string status)
        {
            Caster caster = new Caster(id, password, name, sex, image, desc, phone, email, status);
            return db.UpdateCaster(caster);
        }

        [HttpPut]
        public bool updateProps(string id, string name, string image, string desc, string quantity, string status)
        {
            Props props = new Props(id, name, image, desc, quantity, status);
            return db.UpdateProps(props);
        }

        [HttpDelete]
        public bool deleteKiepnan(String id)
        {
            return db.DeleteMisery(id);
        }

        [HttpDelete]
        public bool deleteCaster(String id)
        {
            return db.DeleteCaster(id);
        }

        [HttpDelete]
        public bool deleteProps(String id)
        {
            return db.DeleteProps(id);
        }

        [HttpPost]
        public Boolean addNewCasterCart(string casterId, string role, string roleDesc, string miseryId)
        {
            return db.AddNewCasterCart(casterId, role, roleDesc, miseryId);
        }

        [HttpPost]
        public Boolean addNewPropsCart(string propsId, string quantity, string miseryId)
        {
            return db.AddNewPropsCart(propsId, quantity, miseryId);
        }
    }
}
