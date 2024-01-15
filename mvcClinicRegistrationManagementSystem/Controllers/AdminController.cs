using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mvcClinicRegistrationManagementSystem.BLL.Interface;
using mvcClinicRegistrationManagementSystem.DAL.Context;
using mvcClinicRegistrationManagementSystem.DAL.Model;

namespace mvcClinicRegistrationManagementSystem.PL.Controllers
{
    public class AdminController : Controller
    {
      

       
        private readonly IAppointmentReposatory _appointmentRepo;
        private readonly IPatientReposatory _patientRepo;
        private readonly ISpecializationReposatory _specializationRepo;
        private readonly IDoctorReposatory _doctorRepo;

        private readonly ApplicationDbContext _context;
        public AdminController(ApplicationDbContext context)
        {
            _context = context;
           
        }


        //This is the index view :
        public IActionResult Index()
        {
            var appointments = _context.Appointment
                .Include(a => a.Patient)
                .Include(a => a.Specialization)
                .Include(a => a.Doctor)
                .ToList();

            return View(appointments);
        }


        //ApproveAppointment sets the status of the appointment to "Approved":

            [HttpPost]
            public IActionResult ApproveAppointment(int AppoID)
            {
                var appointment = _context.Appointment.Find(AppoID);

                if (appointment != null)
                {
                    appointment.Status = "Approved";
                    _context.SaveChanges();
                }

                return RedirectToAction(nameof(Index));
            }



        //RescheduleAppointment updates the date and time of the appointment with the provided values:



        [HttpPost]
        public IActionResult RescheduleAppointment(int AppoID, DateTime newDateTime)
        {
            var appointment = _context.Appointment.Find(AppoID);

            if (appointment != null)
            {
                appointment.Date = newDateTime.Date;
                appointment.Time = newDateTime.ToString("HH:mm");

                _context.SaveChanges();
            }

            return RedirectToAction(nameof(Index));
        }




        //CancelAppointment sets the status of the appointment to "Canceled":
        [HttpPost]
            public IActionResult CancelAppointment(int AppoID)
            {
                var appointment = _context.Appointment.Find(AppoID);

                if (appointment != null)
                {
                    appointment.Status = "Canceled";
                    _context.SaveChanges();
                }

                return RedirectToAction(nameof(Index));
            }

    }
}
//    public class AdminController : Controller
//    {
//        private readonly IAppointmentReposatory _appointmentRepo;
//        private readonly IPatientReposatory _patientRepo;
//        private readonly ISpecializationReposatory _specializationRepo;
//        private readonly IDoctorReposatory _doctorRepo;

//        //IDepartmentReposatory depo = new DepartmentRepository();
//        public AdminController(IAppointmentReposatory appointmentRepo,IDoctorReposatory doctorRepo, IPatientReposatory patientRepo, ISpecializationReposatory specializationRepo)
//        {

//            _appointmentRepo = appointmentRepo;
//            _doctorRepo = doctorRepo;
//            _patientRepo = patientRepo;
//            _specializationRepo = specializationRepo;

//        }
//        public IActionResult Index()
//        {

//            // ViewBag || ViewdData
//            ViewBag.massage = "Hello from Action";
//            ViewData["msg"] = "Hello from ViewData";
//            var appo = _appointmentRepo.GetAll();
//            return View(appo);
//        }
//        public IActionResult Details(int? id)
//        {
//            if (id == null)
//            {
//                return BadRequest();
//            }
//            var appos = _appointmentRepo.Get(id.Value);
//            return View(appos);

//        }
//        public IActionResult Create()
//        {
//            return View();
//        }
//        [HttpPost]
//        public IActionResult Create(Appointment appos)
//        {

//            if (ModelState.IsValid)
//            {
//                _appointmentRepo.Create(appos);
//                TempData["success"] = "Added Successfully";
//                return RedirectToAction("Index");
//            }
//            return View();
//        }


//        public IActionResult Update(int id)
//        {
//            var appos = _appointmentRepo.Get(id);
//            return View(appos);
//        }

//        [HttpPost]
//        public IActionResult Update(Appointment appos)
//        {
//            if (ModelState.IsValid)
//            {
//                _appointmentRepo.Update(appos);
//                return RedirectToAction("Index");
//            }
//            return View(appos);
//        }

//        public ActionResult Delete(int id)
//        {
//            var appos = _appointmentRepo.Get(id);
//            _appointmentRepo.Delete(appos);
//            return RedirectToAction("Index");
//        }

//    }
//}
