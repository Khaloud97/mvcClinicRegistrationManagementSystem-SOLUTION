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
    public class SpecializationReposatory : GenericRepository<Specialization>, ISpecializationReposatory
    {
        private readonly ApplicationDbContext _context;

        public SpecializationReposatory(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }


    }
}