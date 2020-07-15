using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RestfulAPI.Controllers
{
    public class TeacherController : ApiController
    {
        private masterEntities db = new masterEntities();
        // GET api/teacher/list
        [HttpGet]
        public List<Teacher> list()
        {

            return db.Teachers.ToList();
        }

        // GET api/teacher/get/{id}
        [HttpGet]
        public Teacher get(int id)
        {
            return db.Teachers.FirstOrDefault(x => x.id == id);
        }

        // POST api/teacher/insert
        [HttpPost]
        public bool insert(int id, string name, string sex, string major)
        {
            try
            {
                Teacher teacher = new Teacher();
                teacher.id = id;
                teacher.name = name;
                teacher.sex = sex;
                teacher.major = major;
                db.Teachers.Add(teacher);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        // PUT api/teacher/update/{id}
        [HttpPut]
        public bool update(int id, string name, string sex, string major)
        {
            try
            {
                Teacher teacher = db.Teachers.FirstOrDefault(x => x.id == id);
                if (teacher == null) return false;
                teacher.name = name;
                teacher.sex = sex;
                teacher.major = major;
                db.Teachers.AddOrUpdate(teacher);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        // DELETE api/teacher/delete/{id}
        [HttpDelete]
        public bool delete(int id)
        {
            Teacher teacher = db.Teachers.FirstOrDefault(x => x.id == id);
            if (teacher == null) return false;
            db.Teachers.Remove(teacher);
            db.SaveChanges();
            return true;
        }
    }
}