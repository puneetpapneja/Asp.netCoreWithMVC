using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BookStore.Models;
using BookStore.Models.Repository;
using BookStore.Data;
namespace BookStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly BookRepo _bookRepo = null;
        public HomeController(BookRepo bookRepo)
        {
            _bookRepo = bookRepo;
        }

        public async Task<ViewResult> Index()
        {
            var books = await _bookRepo.GetAllBooks();
            return View(books);
        }
    }
}
