using Demo.Models;
using Demo.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Demo.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookService _bookService;

        public BookController()
        {
            _bookService = new BookService();
        }


        [HttpGet]
        public ActionResult Index()
        {
            return View(_bookService.GetAllBooks());
        }

        [HttpGet]
        public ActionResult Details(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var book = _bookService.GetBookById(id.Value);
            if (book == null)
                return HttpNotFound();

            return View(book);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Book book)
        {
            if (ModelState.IsValid)
            {
                _bookService.CreateBook(book);
                return RedirectToAction("Index");
            }

            return View(book);
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var book = _bookService.GetBookById(id.Value);
            if (book == null)
                return HttpNotFound();

            return View(book);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Book book)
        {
            if (ModelState.IsValid)
            {
                _bookService.UpdateBook(book);
                return RedirectToAction("Index");
            }

            return View(book);
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var book = _bookService.GetBookById(id.Value);
            if (book == null)
                return HttpNotFound();
            return View(book);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            var book = _bookService.GetBookById(id);
            _bookService.DeleteBook(book);
            return RedirectToAction("Index");
        }
    }
}