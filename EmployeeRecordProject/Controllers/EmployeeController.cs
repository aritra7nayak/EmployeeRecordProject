using EmployeeRecordProject.Models;
using EmployeeRecordProject.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace EmployeeRecordProject.Controllers
{
    public class EmployeeController : Controller
    {
        private EmployeeRepository _employeeRepository;
        private EducationRepository _educationRepository;


        public EmployeeController()
        {
            _employeeRepository = new EmployeeRepository();
            _educationRepository = new EducationRepository();
        }

        public ActionResult Index()
        {
            var employees = _employeeRepository.GetAllEmployees();
            return View(employees);
        }

        public ActionResult Create()
        {
            ViewBag.Educations = new List<EmployeeEducation>();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Employee employee, HttpPostedFileBase imageFile, List<EmployeeEducation> educations)
        {
            if (ModelState.IsValid)
            {
                if (imageFile != null && imageFile.ContentLength > 0)
                {
                    string fileName = Path.GetFileName(imageFile.FileName);
                    string filePath = Path.Combine(Server.MapPath("~/Images/"), fileName);
                    imageFile.SaveAs(filePath);
                    employee.UploadedPhoto = fileName;
                }
                _employeeRepository.AddEmployee(employee);

                foreach (var education in educations)
                {
                    education.EmployeeId = employee.Id;
                    _educationRepository.AddEducation(education);
                }

                return RedirectToAction("Index");
            }

            // Repopulate the education section if needed

            return View(employee);
        }

        public ActionResult Edit(int id)
        {
            Employee employee = _employeeRepository.GetEmployeeById(id);
            List<EmployeeEducation> educations = _educationRepository.GetEducationsByEmployeeId(id);

            if (employee == null)
            {
                return HttpNotFound();
            }

            ViewBag.Educations = educations;

            return View(employee);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Employee employee)
        {
            if (ModelState.IsValid)
            {
                _employeeRepository.UpdateEmployee(employee);
                return RedirectToAction("Index");
            }

            return View(employee);
        }

        public ActionResult Delete(int id)
        {
            Employee employee = _employeeRepository.GetEmployeeById(id);
            if (employee == null)
            {
                return HttpNotFound();
            }

            List<EmployeeEducation> educations = _educationRepository.GetEducationsByEmployeeId(id);

            ViewBag.Employee = employee;
            ViewBag.Educations = educations;

            return View(employee);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            // Delete associated education records
            List<EmployeeEducation> educations = _educationRepository.GetEducationsByEmployeeId(id);
            foreach (var education in educations)
            {
                _educationRepository.DeleteEducation(education.Id);
            }

            // Delete employee
            _employeeRepository.DeleteEmployee(id);

            return RedirectToAction("Index");
        }


        public ActionResult Details(int id)
        {
            Employee employee = _employeeRepository.GetEmployeeById(id);
            if (employee == null)
            {
                return HttpNotFound();
            }

            List<EmployeeEducation> educations = _educationRepository.GetEducationsByEmployeeId(id);

            ViewBag.Employee = employee;
            ViewBag.Educations = educations;

            return View(employee);
        }


        public ActionResult EducationDetails(int id)
        {
            EmployeeEducation education = _educationRepository.GetEducationById(id); // Replace with your actual repository method
            if (education == null)
            {
                return HttpNotFound();
            }

            return View(education);
        }

        public ActionResult Education()
        {
            return PartialView("Education", new EmployeeEducation());
        }


    }
}