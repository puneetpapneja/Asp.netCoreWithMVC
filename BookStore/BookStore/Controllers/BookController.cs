using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BookStore.Models;
using BookStore.Models.Repository;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BookStore.Controllers
{
    public class BookController : Controller
    {

        private readonly BookRepo _bookRepo = null;
        private readonly LanguageRepo _languageRepo = null;
        public BookController(BookRepo bookRepo, LanguageRepo languageRepo)
        {
            _bookRepo = bookRepo;
            _languageRepo = languageRepo;
        }

        public IActionResult Index()
        {
            return View();
        }
                
        [Route("bookDetails/{id}",Name ="bookDetails")]
        public async Task<ViewResult> GetById(int id) 
        {
            var book =  await  _bookRepo.GetById(id);
            return View(book);
        }        

        public ViewResult Asp()
        {
            var books =  _bookRepo.Search("asp");
            return View(books);
        }

        public ViewResult Php()
        {
            var books = _bookRepo.Search("php");
            return View(books);
        }

        public ViewResult Android()
        {
            var books = _bookRepo.Search("android");
            return View(books);
        }

        public async Task<ViewResult> AddNew(bool isSuccess = false, int id = 0)
        {
            var book = new BookModel();            
            var languages = await _languageRepo.GetAll();
            ViewBag.language = new SelectList(languages, "Id", "Name");
            ViewBag.isSuccess = isSuccess;
            ViewBag.Id = id;
            return View(book);
        }

        [HttpPost]
        public async Task<IActionResult> AddNew(BookModel newBook)
        {
            if (ModelState.IsValid)
            {
                int id = await _bookRepo.Add(newBook);
                if (id > 0)
                {
                    return RedirectToAction(nameof(AddNew), new { isSuccess = true, Id = id });
                }                
            }
            var languages = await _languageRepo.GetAll();
            ViewBag.language = new SelectList(languages,"Id","Name");
            //ModelState.AddModelError("", "this is my custom error");
            return View();
        }

    }
}
