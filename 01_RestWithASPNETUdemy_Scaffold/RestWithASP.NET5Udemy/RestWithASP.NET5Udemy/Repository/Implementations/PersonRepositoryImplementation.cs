using RestWithASP.NET5Udemy.Model;
using RestWithASP.NET5Udemy.Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RestWithASP.NET5Udemy.Repository.Implementations
{
    public class PersonRepositoryImplementation : IPersonRepository
    {

        private MySQLContext _context;

        public PersonRepositoryImplementation(MySQLContext context)
        {
            _context = context;
        }

        public List<Person> FindAll()
        {

            return _context.Persons.ToList();
        }

        public Person FindById(long id)
        {
            return _context.Persons.SingleOrDefault(p => p.Id.Equals(id));
        }


        public Person Create(Person person)
        {
            try
            {
                _context.Add(person);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
            return person;
        }

        
        public Person Update(Person person)
        {
            // verificar se o objeto existe
            if (!Exists(person.Id)) return null;

            // encontrando e armazenando o registro
            var result = _context.Persons.SingleOrDefault(p => p.Id.Equals(person.Id));

            // verificando se o registro possui algum resultado (se ele existe)
            if (result != null)
            {
                try
                {
                    // atualizando o registro
                    _context.Entry(result).CurrentValues.SetValues(person);
                    _context.SaveChanges();
                }
                catch (Exception)
                {

                    throw;
                }

            }
                return person;

        }

        public bool Exists(long id)
        {
            return _context.Persons.Any(p => p.Id.Equals(id));
        }

        public void Delete(long id)
        {
            var result = _context.Persons.SingleOrDefault(p => p.Id.Equals(id));

            // verificando se o registro possui algum resultado (se ele existe)
            if (result != null)
            {
                try
                {
                    // atualizando o registro
                    _context.Persons.Remove(result);
                    _context.SaveChanges();
                }
                catch (Exception)
                {

                    throw;
                }

            }

        }
    }
}
