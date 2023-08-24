using EmployeeRecordProject.DataConnection;
using EmployeeRecordProject.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace EmployeeRecordProject.Repository
{
    public class EducationRepository
    {
        private EmployeeDBContext _context;

        public EducationRepository()
        {
            _context = new EmployeeDBContext();
        }

        public void AddEducation(EmployeeEducation employeeEducation)
        {
            _context.EmployeeEducations.Add(employeeEducation);
            _context.SaveChanges();
        }

        public void UpdateEducation(EmployeeEducation employeeEducation)
        {
            _context.Entry(employeeEducation).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeleteEducation(int educationId)
        {
            EmployeeEducation employeeEducation = _context.EmployeeEducations.Find(educationId);
            if (employeeEducation != null)
            {
                _context.EmployeeEducations.Remove(employeeEducation);
                _context.SaveChanges();
            }
        }

        public EmployeeEducation GetEducationById(int educationId)
        {
            return _context.EmployeeEducations.Find(educationId);
        }

        public List<EmployeeEducation> GetEducationsByEmployeeId(int employeeId)
        {
            return _context.EmployeeEducations
                .Where(education => education.EmployeeId == employeeId)
                .ToList();
        }
    }
}