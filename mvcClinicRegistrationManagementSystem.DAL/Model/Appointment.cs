using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mvcClinicRegistrationManagementSystem.DAL.Model
{
    public class Appointment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AppoID { get; set; }


        public DateTime Date { get; set; }
        public string Time { get; set; }
        public string Status { get; set; }

        public int SpecializationsID { get; set; }
        public Specialization Specialization { get; set; }


        public int PatientsID { get; set; }
        public Patient Patient { get; set; }

        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }



    }
}

