using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace WebServise
{
    /// <summary>
    /// Summary description for WebServicePerson
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebServicePerson : System.Web.Services.WebService
    {

        [WebMethod(Description ="List Persons")]
        public List<Person> ListPerson()
        {
            List<Person> pers = new List<Person>();
            FuncService persons = new FuncService();
            pers = persons.ReturnPersons();
            return pers;
        }
        [WebMethod(Description = "Create Person")]
        public void CreatePerson(Person person)
        {
            FuncService.InsertNewPerson(person);
        }
        [WebMethod(Description = "Update Person")]
        public void UpdatePerson(Person person)
        {
            FuncService.UpdatePerson(person);
        }
        [WebMethod(Description = "Delete Person")]
        public void DeletePerson(int id)
        {
            FuncService.DeletePerson(id);
        }
    }
}
