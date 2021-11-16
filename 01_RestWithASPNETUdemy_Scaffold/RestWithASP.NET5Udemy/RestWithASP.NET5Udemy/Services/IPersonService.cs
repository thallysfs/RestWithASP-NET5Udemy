using RestWithASP.NET5Udemy.Model;
using System.Collections.Generic;

namespace RestWithASP.NET5Udemy.Services
{
    public interface IPersonService
    {
        Person Create(Person person);
        Person FindById(long id);
        List<Person> FindAll();
        Person Update(Person person);
        void Delete(long id);
    }
}
