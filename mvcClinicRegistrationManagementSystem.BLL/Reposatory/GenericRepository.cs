using Microsoft.EntityFrameworkCore;
using mvcClinicRegistrationManagementSystem.BLL.Interface;
using mvcClinicRegistrationManagementSystem.DAL.Context;
using mvcClinicRegistrationManagementSystem.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mvcClinicRegistrationManagementSystem.BLL.Reposatory
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {

        private readonly ApplicationDbContext _context; //==> EMPTY 

        public GenericRepository(ApplicationDbContext context)
        {
            //_context = new ApplicationDbContext()
            _context = context; //
        }


        public int Create(T item)
        {
            _context.Set<T>().Add(item);
            return _context.SaveChanges();
        }

        public int Delete(T item)
        {
            _context.Set<T>().Remove(item);
            return _context.SaveChanges();
        }

        public T Get(int id)
           => _context.Set<T>().Find(id);



        public IEnumerable<T> GetAll()
        {
            if (typeof(T) == typeof(Patient))
            {
                return _context.Patient.ToList() as IEnumerable<T>;

            }
            else
            {
                return _context.Set<T>().ToList();

            }


        }

        public int Update(T item)
        {

            _context.Set<T>().Update(item);
            return _context.SaveChanges();
        }
    }
}
