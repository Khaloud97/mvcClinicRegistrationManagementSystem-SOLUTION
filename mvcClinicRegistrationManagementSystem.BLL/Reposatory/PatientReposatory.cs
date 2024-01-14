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
    public class PatientReposatory : GenericRepository<Patient>, IPatientReposatory
    {
        private readonly ApplicationDbContext _context;

        public PatientReposatory(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }



    }
}