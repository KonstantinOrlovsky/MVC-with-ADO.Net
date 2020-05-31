using BusinessLogicLayer.Services;
using System.Net;
using System.Web.Mvc;
using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer;

namespace PresentationLayer.Controllers
{
    public class CompanyController : Controller
    {
        private readonly ICompanyService companyService;

        public CompanyController()
        {
            companyService = new CompanyService();
        }

        public ActionResult List()
        {
            return View(companyService.GetCompanies());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CompanyDTO companyDTO)
        {
            if (ModelState.IsValid)
            {
                companyService.InsertNew(companyDTO);
                return RedirectToAction("List", "Company");
            }

            return View();
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            var companyDTO = companyService.GetCompanyById(id);

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            if (companyDTO == null)
            {
                return HttpNotFound();
            }

            return View(companyDTO);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CompanyDTO companyDTO)
        {
            if (ModelState.IsValid)
            {
                companyService.Update(companyDTO);
                return RedirectToAction("List", "Company");
            }
            return View();
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            var companyDTO = companyService.GetCompanyById(id);

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            if (companyDTO == null)
            {
                return HttpNotFound();
            }

            return View(companyDTO);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult ConfirmDelete(int id)
        {
            var companyDTO = companyService.GetCompanyById(id);
            companyService.Delete(companyDTO);

            return RedirectToAction("List", "company");
        }
    }
}