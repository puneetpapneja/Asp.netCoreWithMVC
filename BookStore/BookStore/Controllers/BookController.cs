﻿using System;
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

        public List<BookModel> GetAllBooks() 
        {
            return _bookRepo.GetAllBooks();
        }

        public BookModel GetById(int id) 
        {
            return _bookRepo.GetById(id);
        }

        public List<BookModel> Search(string bookName,string authorName)
        {
            return _bookRepo.Search(bookName, authorName);
        }
    }
}
