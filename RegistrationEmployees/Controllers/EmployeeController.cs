using System.Net;
using System.Web.Mvc;
using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.Services;
using BusinessLogicLayer;

namespace PresentationLayer.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService employeeService;
        private readonly ICompanyService companyService;
        private readonly SelectList companiesName;

        public EmployeeController()
        {
            employeeService = new EmployeeService();
            companyService = new CompanyService();
            companiesName = new SelectList(companyService.GetCompanies(), "Id", "Name");
        }

        public ActionResult List()
        {
            return View(employeeService.GetEmployees());
        }

        public ActionResult Create()
        {
            ViewBag.Companies = companiesName;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EmployeeDTO employeeDTO)
        {
            ViewBag.Companies = companiesName;

            if (ModelState.IsValid)
            {
                employeeService.InsertNew(employeeDTO);
                return RedirectToAction("List", "Employee");
            }

            return View();
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            var employeeDTO = employeeService.GetEmployeeById(id);
            ViewBag.Companies = companiesName;


            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            if (employeeDTO == null)
            {
                return HttpNotFound();
            }

            return View(employeeDTO);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EmployeeDTO employeeDTO)
        {
            if (ModelState.IsValid)
            {
                employeeService.Update(employeeDTO);

                return RedirectToAction("List", "Employee");
            }
            ViewBag.Companies = companiesName;

            return View();
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            var employeeDTO = employeeService.GetEmployeeById(id);

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            if (employeeDTO == null)
            {
                return HttpNotFound();
            }

            return View(employeeDTO);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult ConfirmDelete(int id)
        {
            var employeeDTO = employeeService.GetEmployeeById(id);
            employeeService.Delete(employeeDTO);

            return RedirectToAction("List", "Employee");
        }
    }
}
