using mvcClinicRegistrationManagementSystem.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mvcClinicRegistrationManagementSystem.BLL.Interface
{
    public interface IAppointmentReposatory : IGenericRepository<Appointment>
    {
        // 5 actions ==> Get All , get , create ,  delete, update

       // IEnumerable<Patient> Search(string name);
    }
}

