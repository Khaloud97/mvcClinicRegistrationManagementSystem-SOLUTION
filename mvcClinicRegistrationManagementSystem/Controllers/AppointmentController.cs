using Microsoft.AspNetCore.Mvc;
using mvcClinicRegistrationManagementSystem.BLL.Interface;
using mvcClinicRegistrationManagementSystem.DAL.Model;

namespace mvcClinicRegistrationManagementSystem.PL.Controllers
{
    public class AppointmentController : Controller
    {
        private readonly IAppointmentReposatory _appointmentRepo;
        private readonly IPatientReposatory _patientRepo;
        private readonly ISpecializationReposatory _specializationRepo;
        private readonly IDoctorReposatory _doctorRepo;

        //IDepartmentReposatory depo = new DepartmentRepository();
        public AppointmentController(IAppointmentReposatory appointmentRepo,IDoctorReposatory doctorRepo, IPatientReposatory patientRepo, ISpecializationReposatory specializationRepo)
        {

            _appointmentRepo = appointmentRepo;
            _doctorRepo = doctorRepo;
            _patientRepo = patientRepo;
            _specializationRepo = specializationRepo;
            
        }
        public IActionResult Index()
        {

            // ViewBag || ViewdData
            ViewBag.massage = "Hello from Action";
            ViewData["msg"] = "Hello from ViewData";
            var appo = _appointmentRepo.GetAll();
            return View(appo);
        }
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            var appos = _appointmentRepo.Get(id.Value);
            return View(appos);

        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Appointment appos)
        {

            if (ModelState.IsValid)
            {
                _appointmentRepo.Create(appos);
                TempData["success"] = "Added Successfully";
                return RedirectToAction("Index");
            }
            return View();
        }


        public IActionResult Update(int id)
        {
            var appos = _appointmentRepo.Get(id);
            return View(appos);
        }

        [HttpPost]
        public IActionResult Update(Appointment appos)
        {
            if (ModelState.IsValid)
            {
                _appointmentRepo.Update(appos);
                return RedirectToAction("Index");
            }
            return View(appos);
        }

        public ActionResult Delete(int id)
        {
            var appos = _appointmentRepo.Get(id);
            _appointmentRepo.Delete(appos);
            return RedirectToAction("Index");
        }

    }
}
