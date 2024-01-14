using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mvcClinicRegistrationManagementSystem.DAL.Model
{
    public class Doctor
    {
        [Key]
        public string DoctorId { get; set; }

        public string DoctorName { get; set; }
        public ICollection<Appointment> Appointment { get; set; } = new List<Appointment>();


    }
}
