using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using dotnetMicroservicedockerImage.Models;
using Microsoft.Extensions.Configuration;

namespace dotnetMicroservicedockerImage.Controllers
{
    public class employeecontroller : Controller
    {

       // private IConfiguration Configuration;
        //string connectionString = "Server=.\\SQLEXPRESS;Database=CRUD;Trusted_Connection=True;";
        

        EmployeeDataAccessLayer objemployee = new EmployeeDataAccessLayer();
        // GET: employeecontroller
        public ActionResult Index()
        {
            List<Employee> lstEmployee = new List<Employee>();
            lstEmployee = objemployee.GetAllEmployees().ToList();

            return View(lstEmployee);
        }

        // GET: employeecontroller/Details/5
        public ActionResult Details(int id)
        {
            Employee employee = objemployee.GetEmployeeData(id);
            return View(employee);
        }

        // GET: employeecontroller/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: employeecontroller/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Employee collection)
        {
            if (ModelState.IsValid)
            {
                objemployee.AddEmployee(collection);
                return RedirectToAction("Index");
            }
            return View(collection);
        }

        // GET: employeecontroller/Edit/5
        public ActionResult Edit(int id)
        {
            Employee employee =   objemployee.GetEmployeeData(id);
            //Employee employee = objemployee.GetEmployeeData(id);
            return View(employee);
        }

        // POST: employeecontroller/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id,[Bind] Employee employee)
        {
            objemployee.UpdateEmployee(employee);

            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: employeecontroller/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: employeecontroller/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
