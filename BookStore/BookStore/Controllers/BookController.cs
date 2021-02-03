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
        public BookController(BookRepo bookRepo)
        {
            _bookRepo = bookRepo;
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
        
        [Route("bookDetails/{id}",Name ="bookDetails")]
        public async Task<ViewResult> GetById(int id) 
        {
            var book =  await  _bookRepo.GetById(id);
            return View(book);
        }

        public ViewResult Search(string bookName,string authorName)
        {
            //eturn _bookRepo.Search(bookName, authorName);
            return View();
        }

        public ViewResult Asp()
        {
            var books =  _bookRepo.SearchByBookName("asp");
            return View(books);
        }

        public ViewResult Php()
        {
            var books = _bookRepo.SearchByBookName("php");
            return View(books);
        }

        public ViewResult Android()
        {
            var books = _bookRepo.SearchByBookName("android");
            return View(books);
        }

        public ViewResult AddNew(bool isSuccess= false,int id = 0)
        {
            var book = new BookModel()
            {
                Language = "English"
            };

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

            ModelState.AddModelError("", "this is my custom error");
            return View();
        }
    }
}
