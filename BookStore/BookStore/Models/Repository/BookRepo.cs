using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using BookStore.Models;

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
            BookModel newBook = new BookModel()
            {
                AutherName = book.AutherName,
                BookName = book.BookName,
                Description = book.Description
            };

            await _context.bookModel.AddAsync(newBook);
            await _context.SaveChangesAsync();
            return newBook.Id;
        }

        public async Task<List<BookModel>> GetAllBooks()
        {
            return await _context.bookModel.ToListAsync<BookModel>();            
        }

        public async Task<BookModel> GetById(int id)
        {
           var data =  await _context.bookModel.FindAsync(id);
            if(data != null)
            {
                return new BookModel(){
                    AutherName = data.AutherName,
                    BookName = data.BookName,
                    Image = data.Image
                };
            }
            return null;
        }

        public List<BookModel> SearchByBookName(string bookName)
        {

            return Books().Where(x => x.BookName.ToLower().Contains(!string.IsNullOrEmpty(bookName) ? bookName : "")).ToList();
        }

        public List<BookModel> Search(string bookName, string autherName)
        {            

            return Books().Where(x => x.BookName.ToLower().Contains(!string.IsNullOrEmpty(bookName) ? bookName : "") || x.AutherName.ToLower().Contains(!string.IsNullOrEmpty(autherName)? autherName:"")).ToList();
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
