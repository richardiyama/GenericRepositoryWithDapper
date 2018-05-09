using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GenericRepositoryAndDapper.Models;

namespace GenericRepositoryAndDapper.Controllers
{
    public class EmployeesController : Controller
    {
        IDbConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ContextDB"].ConnectionString);
       


        // GET: Employees
        public ActionResult Index()
        {
           

            DPGenericRepository<Employees> employeesRepository = new DPGenericRepository<Employees>(conn);

            
            return View(employeesRepository.All());
        }

        // GET: Employees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DPGenericRepository<Employees> employeesRepository = new DPGenericRepository<Employees>(conn);
            object pk = new {EmployeesID = id };
            if (employeesRepository.Find(pk) == null)
            {
                return HttpNotFound();
            }
            return View(employeesRepository.Find(pk));
        }

        // GET: Employees/Create
        public ActionResult Create()
        {
            DPGenericRepository<Department> departmentRepository = new DPGenericRepository<Department>(conn);


          
            ViewBag.DepartmentID = new SelectList(departmentRepository.All(), "DepartmentID", "Name");
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Exclude = "EmployeesID")] Employees employees)
        {
            DPGenericRepository<Department> departmentRepository = new DPGenericRepository<Department>(conn);
            DPGenericRepository<Employees> employeesRepository = new DPGenericRepository<Employees>(conn);

            if (ModelState.IsValid)
            {
                employeesRepository.Add(employees);
                
                return RedirectToAction("Index");
            }

            ViewBag.DepartmentID = new SelectList(departmentRepository.All(), "DepartmentID", "Name", employees.DepartmentID);
            return View(employees);
        }

        // GET: Employees/Edit/5
        public ActionResult Edit(int? id)
        {

            DPGenericRepository<Department> departmentRepository = new DPGenericRepository<Department>(conn);
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DPGenericRepository<Employees> employeesRepository = new DPGenericRepository<Employees>(conn);
            object pk = new { EmployeesID = id };
            if (employeesRepository.Find(pk) == null)
            {
                return HttpNotFound();
            }
            Employees employees = new Employees();
            ViewBag.DepartmentID = new SelectList(departmentRepository.All(), "DepartmentID", "Name", employees.DepartmentID);
            return View(employeesRepository.Find(pk));
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id,Employees employees)
        {
            DPGenericRepository<Employees> employeesRepository = new DPGenericRepository<Employees>(conn);
            object pk = new { EmployeesID  = id};

            //DPGenericRepository<Department> departmentRepository = new DPGenericRepository<Department>(conn);

            //ViewBag.DepartmentID = new SelectList(departmentRepository.All(), "DepartmentID", "Name", employees.DepartmentID);
            if (ModelState.IsValid)
            {
                employeesRepository.Update(employees, pk);
                return RedirectToAction("Index");
            }

          
           
            
            return View(employees);
        }

        //// GET: Employees/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Department employees = db.Employees.Find(id);
        //    if (employees == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(employees);
        //}

        //// POST: Employees/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Department employees = db.Employees.Find(id);
        //    db.Employees.Remove(employees);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
