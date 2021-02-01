using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Models;

namespace BookStore.Models.Repository
{
    public class BookRepo
    {
        public List<BookModel> GetAllBooks()
        {
            return Books().ToList();
        }

        public BookModel GetById(int id)
        {
            return Books().Where(x => x.Id == id).FirstOrDefault();
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
