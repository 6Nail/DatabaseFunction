using System;

namespace HW
{
    public class Book
    {
        public Guid Id { get; set; } 
        public string TitleName { get; set; }
        public int Price { get; set; }
        public string Author { get; set; }
        
        public Book()
        {
            Id = Guid.NewGuid();
        }

        public Book(Book book)
        {
            Id = Guid.NewGuid();
            TitleName = book.TitleName;
            Price = book.Price;
            Author = book.Author;
        }
    }
}
