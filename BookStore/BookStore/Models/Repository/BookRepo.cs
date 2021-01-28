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

        public List<BookModel> Search(string bookName, string autherName)
        {
            

            return Books().Where(x => x.BookName.ToLower().Contains(!string.IsNullOrEmpty(bookName) ? bookName : "") || x.AutherName.ToLower().Contains(!string.IsNullOrEmpty(autherName)? autherName:"")).ToList();
        }

        public List<BookModel> Books()
        {
            return new List<BookModel>()
            {
                new BookModel(){Id=1,BookName="MVC",AutherName="John"},
                new BookModel(){Id=2,BookName="Asp.Net Core",AutherName="George Orwell"},
                new BookModel(){Id=3,BookName="Asp.Net with MVC",AutherName="Lewis Carroll"},
                new BookModel(){Id=4,BookName="Asp.Net Core with MVC",AutherName="Mark Twain"},
            };
        }
    }
}
