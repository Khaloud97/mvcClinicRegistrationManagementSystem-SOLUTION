using Microsoft.AspNetCore.Mvc;
using mvcClinicRegistrationManagementSystem.BLL.Interface;
using mvcClinicRegistrationManagementSystem.DAL.Context;
using mvcClinicRegistrationManagementSystem.DAL.Model;

namespace mvcClinicRegistrationManagementSystem.PL.Controllers
{
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IAppointmentReposatory _appointmentRepo;
        private readonly IPatientReposatory _patientRepo;
        private readonly ISpecializationReposatory _specializationRepo;
        private readonly IDoctorReposatory _doctorRepo;

        public AdminController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult AppointmentOverview()
        {
            var appointments = _context.Appointment
                .Include(a => a.Patient)
                .Include(a => a.Specialization)
                .ToList();

            return View(appointments);
        }

        public IActionResult ManageAppointment(int appointmentId)
        {
            var appointment = _context.Appointment
                .Include(a => a.Patient)
                .Include(a => a.Specialization)
                .FirstOrDefault(a => a.AppointmentID == appointmentId);

            if (appointment == null)
            {
                return NotFound(); // Handle case where appointment is not found
            }

            return View(appointment);
        }

        [HttpPost]
        public IActionResult ApproveAppointment(int appointmentId)
        {
            var appointment = _context.Appointment.Find(appointmentId);

            if (appointment == null)
            {
                return NotFound(); 
            }

            appointment.Status = "Approved"; 
            _context.SaveChanges();

            return RedirectToAction(nameof(AppointmentOverview));
        }

        [HttpPost]
        public IActionResult RescheduleAppointment(int appointmentId, DateTime newDateTime)
        {
            var appointment = _context.Appointment.Find(appointmentId);

            if (appointment == null)
            {
                return NotFound(); 
            }

            appointment.Date = newDateTime.Date;
            appointment.Time = newDateTime.TimeOfDay;
            _context.SaveChanges();

            return RedirectToAction(nameof(AppointmentOverview));
        }

        [HttpPost]
        public IActionResult CancelAppointment(int appointmentId)
        {
            var appointment = _context.Appointment.Find(appointmentId);

            if (appointment == null)
            {
                return NotFound(); // Handle case where appointment is not found
            }

            appointment.Status = "Canceled"; // Update status as needed
            _context.SaveChanges();

            return RedirectToAction(nameof(AppointmentOverview));
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
