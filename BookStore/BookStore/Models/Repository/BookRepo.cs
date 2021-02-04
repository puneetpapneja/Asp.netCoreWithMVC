using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using BookStore.Models;
using BookStore.Data;

namespace BookStore.Models.Repository
{
    public class BookRepo
    {
        private readonly BookDBContext _context = null;

        public BookRepo(BookDBContext context)
        {
            _context = context;
        }

        public async Task<int> Add(BookModel book)
        {
            var newBook = new Book()
            {
                AutherName = book.AutherName,
                BookName = book.BookName,
                Description = book.Description,
                LanguageId = book.LanguageId
            };

            await _context.book.AddAsync(newBook);
            await _context.SaveChangesAsync();
            return newBook.Id;
        }

        public async Task<List<BookModel>> GetAllBooks()
        {
            
            List<BookModel> allBooks = await (_context.book.Select(book => new BookModel()
            {
                Id = book.Id,
                BookName = book.BookName,
                AutherName = book.AutherName,
                Description = book.Description,
                Image = string.IsNullOrEmpty(book.Image) ? "asp-net4-5-blackbook_1_100x100.jpg" : book.Image,
                LanguageId = book.LanguageId,
                LanguageName = book.Language.Name
            })).ToListAsync();

            return allBooks;
        }

        public async Task<BookModel> GetById(int id)
        {
            return await _context.book.Where(x => x.Id == id).Select(book => new BookModel()
            {
                BookName = book.BookName,
                AutherName = book.AutherName,
                Image = string.IsNullOrEmpty(book.Image) ? "asp-net4-5-blackbook_1_100x100.jpg" : book.Image,
                LanguageId = book.LanguageId,
                LanguageName = book.Language.Name,
                Description = book.Description
                
            }).FirstOrDefaultAsync();

            
        }

        public List<BookModel> SearchByBookName(string bookName)
        {

            return Books().Where(x => x.BookName.ToLower().Contains(!string.IsNullOrEmpty(bookName) ? bookName : "")).ToList();
        }

        public List<BookModel> Search(string bookName, string autherName = null)
        {            
            return _context.book.Where(x => x.BookName.ToLower().Contains(!string.IsNullOrEmpty(bookName) ? bookName : "") || 
                (!string.IsNullOrEmpty(autherName) && x.AutherName.ToLower().Contains(!string.IsNullOrEmpty(autherName) ? autherName : "")))
                .Select(book => new BookModel()
                {
                    Id = book.Id,
                    BookName = book.BookName,
                    AutherName = book.AutherName,
                    Description = book.Description,
                    Image = string.IsNullOrEmpty(book.Image) ? "asp-net4-5-blackbook_1_100x100.jpg" : book.Image,
                    LanguageId = book.LanguageId,
                    LanguageName = book.Language.Name
                })
                .ToList();
            //return Books().Where(x => x.BookName.ToLower().Contains(!string.IsNullOrEmpty(bookName) ? bookName : "") || x.AutherName.ToLower().Contains(!string.IsNullOrEmpty(autherName)? autherName:"")).ToList();
        }

        public List<BookModel> Books()
        {
            
            return new List<BookModel>()
            {
                new BookModel(){Id=1,BookName="PHP",AutherName="John",Image="asp-net4-5-blackbook_1_100x100.jpg",Description="Book description "},
                new BookModel(){Id=2,BookName="Asp.Net Core",AutherName="George Orwell",Image="asp-net4-5-blackbook_1_100x100.jpg",Description="Book description "},
                new BookModel(){Id=3,BookName="Asp.Net with MVC",AutherName="Lewis Carroll",Image="asp-net4-5-blackbook_1_100x100.jpg",Description="Book description "},
                new BookModel(){Id=4,BookName="Android",AutherName="Mark Twain",Image="asp-net4-5-blackbook_1_100x100.jpg",Description="Book description "},
            };
        }
    }
}
