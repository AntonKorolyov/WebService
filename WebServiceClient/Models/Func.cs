using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebServiceClient.ServicePerson;

namespace WebServiceClient.Models
{

    public class Func
    {
      WebServicePersonSoapClient client = new WebServicePersonSoapClient();
      public List<Person> GetPersons()
      {
          List<Person> persons = new List<Person>();
          var p = client.ListPerson();
          persons = p.OfType<Person>().ToList();
          return persons;
      }

      public void CreatePerson(Person person)
      {
          client.CreatePerson(person);
      }
      public void UpdatePerson(Person person)
      {
          client.UpdatePerson(person);
      }
      public void DeletePerson(int id)
      {
          client.DeletePerson(id);
      }
    }
}
