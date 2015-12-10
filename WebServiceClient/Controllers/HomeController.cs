using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebServiceClient.Models;
using WebServiceClient.ServicePerson;

namespace WebServiceClient.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ListPerson()
        {
            List<Person> persons = new List<Person>();
            Func clients = new Func();
            persons = clients.GetPersons();
            return Json(persons);
        }
        public ActionResult DeletePerson(string id)
        {
            Func func = new Func();
            func.DeletePerson(Convert.ToInt32(id));
            return null;
        }
        public ActionResult CreatePerson(Person pers)
        {
            Func func = new Func();
            func.CreatePerson(pers);
            return null;
        }
        public ActionResult UpdatePerson(Person pers)
        {
            Func func = new Func();
            func.UpdatePerson(pers);
            return null;
        }
    }
}
