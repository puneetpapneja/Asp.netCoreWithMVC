using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    public class BookController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public string GetAllBooks() 
        {
            return "all books";
        }

        public string GetById(int id) 
        {
            return $"Book ID is {id}";
        }

        public string Search(string bookName,string authorName)
        {
            return $"Book name is {bookName} and author name is {authorName}";
        }
    }
}
