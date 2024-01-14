using mvcClinicRegistrationManagementSystem.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace mvcClinicRegistrationManagementSystem.BLL.Interface
{
    public interface IPatientReposatory : IGenericRepository<Patient>
    {
        // 5 actions ==> Get All , get , create ,  delete, update

       
    }
}
