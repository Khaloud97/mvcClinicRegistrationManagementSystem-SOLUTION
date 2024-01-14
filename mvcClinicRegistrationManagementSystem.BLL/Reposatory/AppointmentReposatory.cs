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
    public class AppointmentReposatory : GenericRepository<Appointment>, IAppointmentReposatory
    {
        private readonly ApplicationDbContext _context;

        public AppointmentReposatory(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }



    }
}