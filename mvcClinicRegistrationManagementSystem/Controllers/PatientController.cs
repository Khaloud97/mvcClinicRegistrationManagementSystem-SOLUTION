using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using mvcClinicRegistrationManagementSystem.BLL.Interface;
using mvcClinicRegistrationManagementSystem.BLL.Reposatory;
using mvcClinicRegistrationManagementSystem.DAL.Model;

namespace mvcClinicRegistrationManagementSystem.PL.Controllers
{
    public class PatientsController : Controller
    {
       

        private readonly IAppointmentReposatory _appointmentRepo;
        private readonly IPatientReposatory _patientRepo;
        private readonly ISpecializationReposatory _specializationRepo;
        private readonly IDoctorReposatory _doctorRepo;
        public PatientsController(
        IPatientReposatory patientRepository,
        ISpecializationReposatory specializationRepository,
        IAppointmentReposatory appointmentRepository,
        IDoctorReposatory doctorRepository)
        {
            _patientRepo = patientRepository;
            _specializationRepo = specializationRepository;
            _appointmentRepo = appointmentRepository;
            _doctorRepo = doctorRepository;
        }
        //=========================================

        //Patients Details:

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            var patient = _patientRepo.Get(id.Value);
            return View(patient);

        }

        //=========================================
        public IActionResult Index()
        {

            // ViewBag || ViewdData
            ViewBag.massage = "Hello from Action";
            ViewData["msg"] = "Hello from ViewData";
            var patient = _patientRepo.GetAll();
            return View(patient);
        }
        //=========================================
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Patient p)
        {
            if (ModelState.IsValid)
            {
                _patientRepo.Create(p);
                return RedirectToAction("Index");
            }
            return View(p);
        }
        public IActionResult CreateAppoin()
        {
            List<Doctor> doctors = _doctorRepo.GetAll().ToList();
            ViewBag.DoctorList = new SelectList(doctors, "DoctorId", "Name");
            return View();
        }
        [HttpPost]
        public IActionResult CreateAppoin(Appointment appo)
        {
            if (ModelState.IsValid)
            {
                _appointmentRepo.Create(appo);
                return RedirectToAction("Index");
            }
            return View();
        }



        //==========================================
        //Patients/Register:
        //public IActionResult Create()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public IActionResult Create(Patient patient)
        //{

        //    if (ModelState.IsValid)
        //    {
        //        _patientRepo.Create(patient);
        //        TempData["success"] = "Patient Details Added Successfully";
        //        return RedirectToAction("Index");
        //    }
        //    return View();
        //}


        //==========================================
        // Patients/SpecializationSelection
        public IActionResult SpecializationSelection()
        {
            var specializations = _specializationRepo.GetAll();
            return View(specializations);
        }

        //// GET: /Patients/BookAppointment
        //public IActionResult BookAppointment(int specializationId)
        //{
        //    // Retrieve specialization details and available appointment slots
        //    // Example: var availableSlots = _appointmentRepository.GetAvailableSlots(specializationId);

        //    var viewModel = new BookAppointmentViewModel
        //    {
        //        SpecializationId = specializationId,
        //        // Other properties for the view model
        //    };

        //    return View(viewModel);
        //}

        //// POST: /Patients/BookAppointment
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult BookAppointment(BookAppointmentViewModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        // Save appointment booking logic using _appointmentRepository
        //        // Example: _appointmentRepository.BookAppointment(model);

        //        return RedirectToAction(nameof(SuccessfulBooking));
        //    }
        //    return View(model);
        //}

        //// GET: /Patients/SuccessfulBooking
        //public IActionResult SuccessfulBooking()
        //{
        //    return View();
        //}
    }

    //public class PatientController : Controller
    //{
    //    private readonly IAppointmentReposatory _appointmentRepo;
    //    private readonly IPatientReposatory _patientRepo;
    //    private readonly ISpecializationReposatory _specializationRepo;
    //    private readonly IDoctorReposatory _doctorRepo;

    //    //IDepartmentReposatory depo = new DepartmentRepository();
    //    public PatientController(IPatientReposatory patientRepo, ISpecializationReposatory specializationRepo)
    //    {

    //        _patientRepo = patientRepo;
    //        _specializationRepo = specializationRepo;
    //    }

    //    public IActionResult Index()
    //    {

    //        // ViewBag || ViewdData
    //        ViewBag.massage = "Hello from Action";
    //        ViewData["msg"] = "Hello from ViewData";
    //        var appo = _appointmentRepo.GetAll();
    //        return View(appo);
    //    }
    //    public IActionResult Details(int? id)
    //    {
    //        if (id == null)
    //        {
    //            return BadRequest();
    //        }
    //        var appos = _appointmentRepo.Get(id.Value);
    //        return View(appos);

    //    }
    //    public IActionResult Create()
    //    {
    //        return View();
    //    }
    //    [HttpPost]
    //    public IActionResult Create(Appointment appos)
    //    {

    //        if (ModelState.IsValid)
    //        {
    //            _appointmentRepo.Create(appos);
    //            TempData["success"] = "Added Successfully";
    //            return RedirectToAction("Index");
    //        }
    //        return View();
    //    }


    //    public IActionResult Update(int id)
    //    {
    //        var appos = _appointmentRepo.Get(id);
    //        return View(appos);
    //    }

    //    [HttpPost]
    //    public IActionResult Update(Appointment appos)
    //    {
    //        if (ModelState.IsValid)
    //        {
    //            _appointmentRepo.Update(appos);
    //            return RedirectToAction("Index");
    //        }
    //        return View(appos);
    //    }

    //    public ActionResult Delete(int id)
    //    {
    //        var appos = _appointmentRepo.Get(id);
    //        _appointmentRepo.Delete(appos);
    //        return RedirectToAction("Index");
    //    }

    //}
}
