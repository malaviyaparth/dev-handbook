using Book_Management.Models;
using Book_Management_2.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Net;
using static System.Reflection.Metadata.BlobBuilder;

namespace Book_Management.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookRepository _repository;

        public BookController(IBookRepository repository)
        {
            _repository = repository;
        }
        public IActionResult Index()
        {
            var books = _repository.GetAll();
            return View(books);
        }
        public IActionResult Details(int id)
        {
            Book? book = _repository.GetById(id);
            if (book == null) return NotFound();

            return View("View", book);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Book book)
        {
            _repository.Add(book);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            Book? book = _repository.GetById(id);

            if (book == null)
                return NotFound();

            return View(book);
        }

        [HttpPost]
        public IActionResult Edit(Book book)
        {
            _repository.Update(book);

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            Book? book = _repository.GetById(id);

            if (book == null)
                return NotFound();

            return View(book);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _repository.Delete(id);

            return RedirectToAction("Index");
        }
    }
}
