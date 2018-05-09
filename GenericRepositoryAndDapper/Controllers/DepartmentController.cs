using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GenericRepositoryAndDapper.Models;
using Dapper;
using GenericRepositoryAndDapper.Repository;
using System.Configuration;
using System.Data.SqlClient;

namespace GenericRepositoryAndDapper.Controllers
{
    public class DepartmentController : Controller
    {
        IDbConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ContextDB"].ConnectionString);

        // GET: Department
        public ActionResult Index()
        {
           
            DPGenericRepository<Department> departmentRepository = new DPGenericRepository<Department>(conn);


            return View(departmentRepository.All());
        }

        // GET: Department/Details/5
        public ActionResult Details(int? id)
        {
            DPGenericRepository<Department> departmentRepository = new DPGenericRepository<Department>(conn);
            object pk = new { DepartmentID = id };

            if (pk == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
           
            if (departmentRepository.Find(pk) == null)
            {
                return HttpNotFound();
            }
            return View(departmentRepository.Find(pk));
        }

        //// GET: Department/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Department/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "DepartmentID,Name,Comments")] Department department)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        conn.Departments.Add(department);
        //        conn.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(department);
        //}

        //// GET: Department/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Department department = conn.Departments.Find(id);
        //    if (department == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(department);
        //}

        //// POST: Department/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "DepartmentID,Name,Comments")] Department department)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        conn.Entry(department).State = EntityState.Modified;
        //        conn.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(department);
        //}

        //// GET: Department/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Department department = conn.Departments.Find(id);
        //    if (department == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(department);
        //}

        //// POST: Department/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Department department = conn.Departments.Find(id);
        //    conn.Departments.Remove(department);
        //    conn.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        conn.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
