using DotNet_MVC_LINQ.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DotNet_MVC_LINQ.Controllers
{
    public class PersonController : Controller
    {
        PersonRepository repo = new PersonRepository();

        [HttpGet]
        public ActionResult Index()
        {
            return View(repo.GetAll());
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            //var person = context.Persons.SingleOrDefault(x => x.Id == id);
            return View(repo.Details(id));
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Person p)
        {
            //context.Persons.InsertOnSubmit(p);
            //context.SubmitChanges();
            p = repo.Create(p);
            return RedirectToAction("Details", new { id = p.id });
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            //var person = context.Persons.SingleOrDefault(x => x.Id == id);
            return View(repo.Details(id));
        }

        [HttpPost]
        public ActionResult Edit(Person p)
        {
            //var person = context.Persons.SingleOrDefault(x => x.Id == p.Id);
            //person.Name = p.Name;
            //person.Email = p.Email;
            //context.SubmitChanges();
            repo.Edit(p);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            //var person = context.Persons.SingleOrDefault(x => x.Id == id);
            return View(repo.Details(id));
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult ConfirmDelete(Person p)
        {
            //var person = context.Persons.SingleOrDefault(x => x.Id == p.Id);
            //context.Persons.DeleteOnSubmit(person);
            //context.SubmitChanges();
            repo.Delete(p);
            return RedirectToAction("Index");
        }
    }
}