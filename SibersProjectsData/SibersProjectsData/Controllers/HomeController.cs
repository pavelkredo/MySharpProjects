using SibersProjectsData.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;

namespace SibersProjectsData.Controllers
{
    public class HomeController : Controller
    {
        ProjectContext projectDb = new ProjectContext();

        public ActionResult Projects(ProjectFilter projectFilter, string sortOrder)
        {
            var projects = projectDb.Projects.Include(p => p.Chief);
            projects.Include(p => p.Implementer);

            // Код фильтра проектов
            if (projectFilter.StartProjectDateStart != null && projectFilter.StartProjectDateEnd != null)
            {
                projects = projects.Where(p =>
                    p.StartProjectDate >= projectFilter.StartProjectDateStart &&
                    p.StartProjectDate <= projectFilter.StartProjectDateEnd);
            }

            if (projectFilter.EndProjectDateStart != null && projectFilter.EndProjectDateEnd != null)
            {
                projects = projects.Where(p =>
                    p.EndProjectDate >= projectFilter.EndProjectDateStart &&
                    p.EndProjectDate <= projectFilter.EndProjectDateEnd);
            }

            if (projectFilter.PrioritiesMin != null && projectFilter.PrioritiesMax != null)
            {
                projects = projects.Where(p =>
                    p.Priority >= projectFilter.PrioritiesMin &&
                    p.Priority <= projectFilter.PrioritiesMax);
            }

            // Код сортировки проектов
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Дата начала" ? "start_date_desc" : "Дата начала";
            ViewBag.PrioritySortParm = sortOrder == "Приоритет" ? "priority_desc" : "Приоритет";

            switch (sortOrder)
            {
                case "name_desc":
                    projects = projects.OrderByDescending(p => p.ProjectName);
                    break;
                case "Дата начала":
                    projects = projects.OrderBy(p => p.StartProjectDate);
                    break;
                case "start_date_desc":
                    projects = projects.OrderByDescending(p => p.StartProjectDate);
                    break;
                case "Приоритет":
                    projects = projects.OrderBy(p => p.Priority);
                    break;
                case "priority_desc":
                    projects = projects.OrderByDescending(p => p.Priority);
                    break;
                default:
                    projects = projects.OrderBy(p => p.ProjectName);
                    break;
            }

            ViewBag.Projects = projects;

            return View();
        }

        [HttpGet]
        public ActionResult CreateProject()
        {
            var employees = new SelectList(projectDb.Employees, "Id", "Surname");

            ViewBag.Employees = employees;

            return View();
        }

        [HttpPost]
        public ActionResult CreateProject(Project project)
        {
            projectDb.Projects.Add(project);
            projectDb.SaveChanges();

            return RedirectToAction("Projects");
        }

        [HttpGet]
        public ActionResult EditProject(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            var project = projectDb.Projects.Find(id);

            if (project != null)
            {
                var employees = new SelectList(projectDb.Employees, "Id", "Surname");

                ViewBag.Employees = employees;

                return View(project);
            }

            return HttpNotFound();
        }

        [HttpPost]
        public ActionResult EditProject(Project project)
        {
            projectDb.Entry(project).State = EntityState.Modified;
            projectDb.SaveChanges();

            return RedirectToAction("Projects");
        }

        public ActionResult Employees()
        {
            IEnumerable<Employee> employees = projectDb.Employees;

            ViewBag.Employees = employees;

            return View();
        }

        [HttpGet]
        public ActionResult CreateEmployee()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateEmployee(Employee employee)
        {
            projectDb.Employees.Add(employee);
            projectDb.SaveChanges();

            return RedirectToAction("Employees");
        }

        [HttpGet]
        public ActionResult EditEmployee(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            var employee = projectDb.Employees.Find(id);

            if (employee != null)
            {
                return View(employee);
            }

            return HttpNotFound();
        }

        [HttpPost]
        public ActionResult EditEmployee(Employee employee)
        {
            projectDb.Entry(employee).State = EntityState.Modified;
            projectDb.SaveChanges();

            return RedirectToAction("Employees");
        }

        [HttpGet]
        public ActionResult DeleteEmployee(int id)
        {
            var employee = projectDb.Employees.Find(id);

            if (employee == null)
            {
                return HttpNotFound();
            }

            return View(employee);
        }

        [HttpPost, ActionName("DeleteEmployee")]
        public ActionResult DeleteEmployeeConfirmed(int id)
        {
            var employee = projectDb.Employees.Find(id);

            if (employee == null)
            {
                return HttpNotFound();
            }

            projectDb.Projects.ForEach(p =>
            {
                if (p.ChiefId == id)
                {
                    p.ChiefId = null;
                }

                if (p.ImplementerId == id)
                {
                    p.ImplementerId = null;
                }
            });

            projectDb.Employees.Remove(employee);
            projectDb.SaveChanges();

            return RedirectToAction("Projects");
        }

        [HttpGet]
        public ActionResult DeleteProject(int id)
        {
            var project = projectDb.Projects.Find(id);

            if (project == null)
            {
                return HttpNotFound();
            }

            return View(project);
        }

        [HttpPost, ActionName("DeleteProject")]
        public ActionResult DeleteProjectConfirmed(int id)
        {
            var project = projectDb.Projects.Find(id);

            if (project == null)
            {
                return HttpNotFound();
            }

            projectDb.Projects.Remove(project);
            projectDb.SaveChanges();

            return RedirectToAction("Projects");
        }
    }
}