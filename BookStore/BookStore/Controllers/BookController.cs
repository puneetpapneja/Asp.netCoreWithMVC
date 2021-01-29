using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BookStore.Models;
using BookStore.Models.Repository;

namespace BookStore.Controllers
{
    public class BookController : Controller
    {

        private readonly BookRepo _bookRepo = null;
        public BookController()
        {
            _bookRepo = new BookRepo();
        }

        public IActionResult Index()
        {
            return View();
        }

        public ViewResult GetAllBooks() 
        {
            //return _bookRepo.GetAllBooks();
            return View();
        }

        public ViewResult GetById(int id) 
        {
            //return _bookRepo.GetById(id);
            return View();
        }

        public ViewResult Search(string bookName,string authorName)
        {
            //eturn _bookRepo.Search(bookName, authorName);
            return View();
        }
    }
}
