using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mvcClinicRegistrationManagementSystem.DAL.Model
{
    public class Patient
    {
        [Key]
        public int PatientsID { get; set; }

        [MaxLength(50)]
        public string PatientsName { get; set; }

        [Range(18, 50)]
        public int ContactDetails { get; set; }

        // Navigation property for appointments
        public ICollection<Appointment> Appointment { get; set; } = new List<Appointment>();

    }
}