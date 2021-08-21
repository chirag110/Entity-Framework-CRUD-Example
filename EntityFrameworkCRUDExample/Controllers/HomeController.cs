using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using EntityFrameworkCRUDExample.Models;
namespace EntityFrameworkCRUDExample.Controllers
{
 public class HomeController: Controller
 {
 CompanyDbContext db = new CompanyDbContext();

    public ActionResult Index()
    {
        List<Employee> emps = db.Employees.ToList();
        return View(emps);
    }

    public ActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public ActionResult Create(Employee emp)
    {
        db.Employees.Add(emp);
        db.SaveChanges();
        return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
        Employee emp = db.Employees.Find(id);
        return View(emp);
    }

    public ActionResult Edit(int id)
    { 
        Employee emp = db.Employees.Find(id);
        return View(emp);
    }

    [HttpPost]
    public ActionResult Edit(Employee e)
    {
        Employee emp = db.Employees.Where(temp => temp.EmpID == e.EmpID).FirstOrDefault();
        emp.EmpName = e.EmpName;
        emp.Salary = e.Salary;
        db.SaveChanges();
        return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
        Employee emp = db.Employees.Where(temp => temp.EmpID == id).FirstOrDefault();
        return View(emp);
    }

    [HttpPost]
    public ActionResult Delete(int id, Employee e)
    {
        Employee emp = db.Employees.Where(temp => temp.EmpID == id).FirstOrDefault();
        db.Employees.Remove(emp);
        db.SaveChanges();
        return RedirectToAction("Index");
    }
}
}