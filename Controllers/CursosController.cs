using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ASPNETfaculdade2.DAL;
using ASPNETfaculdade2.Models;

namespace ASPNETfaculdade2.Controllers
{
    public class CursosController : Controller
    {
        private EFContext db = new EFContext();

        // GET: Cursos
        public ActionResult Index()
        {
            var cursos = db.Cursos.Include(c => c.Universidade);
            return View(cursos.ToList());
        }

        // GET: Cursos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Curso curso = db.Cursos.Find(id);
            if (curso == null)
            {
                return HttpNotFound();
            }
            return View(curso);
        }

        // GET: Cursos/Create
        public ActionResult Create()
        {
            ViewBag.UniversidadeID = new SelectList(db.Universidades, "UniversidadeID", "Nome");
            return View();
        }

        // POST: Cursos/Create
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CursoID,Nome,UniversidadeID")] Curso curso)
        {
            if (ModelState.IsValid)
            {
                db.Cursos.Add(curso);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UniversidadeID = new SelectList(db.Universidades, "UniversidadeID", "Nome", curso.UniversidadeID);
            return View(curso);
        }

        // GET: Cursos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Curso curso = db.Cursos.Find(id);
            if (curso == null)
            {
                return HttpNotFound();
            }
            ViewBag.UniversidadeID = new SelectList(db.Universidades, "UniversidadeID", "Nome", curso.UniversidadeID);
            return View(curso);
        }

        // POST: Cursos/Edit/5
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CursoID,Nome,UniversidadeID")] Curso curso)
        {
            if (ModelState.IsValid)
            {
                db.Entry(curso).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UniversidadeID = new SelectList(db.Universidades, "UniversidadeID", "Nome", curso.UniversidadeID);
            return View(curso);
        }

        // GET: Cursos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Curso curso = db.Cursos.Find(id);
            if (curso == null)
            {
                return HttpNotFound();
            }
            return View(curso);
        }

        // POST: Cursos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Curso curso = db.Cursos.Find(id);
            db.Cursos.Remove(curso);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
