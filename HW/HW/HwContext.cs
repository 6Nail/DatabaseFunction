using Microsoft.EntityFrameworkCore;

namespace HW
{
    public class HwContext : DbContext
    {
        public HwContext()
        {
            Database.EnsureCreated();
        }

        public DbSet<Book> Books { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=A-303-14;Database=BindingHw;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().HasData(new Book
            {
                Price = 1001,
                TitleName = "1000 и 1 отмазок",
                Author = "Василий Петрович"
            });
            modelBuilder.Entity<Book>().HasData(new Book
            {
                Price = 1200,
                TitleName = "Забей на всё",
                Author = "Извращенный Отшельник"
            });
            modelBuilder.Entity<Book>().HasData(new Book
            {
                Price = 200,
                TitleName = "Лайфхаки для армии.",
                Author = "Извращенный Отшельник"
            });
        }
    }
}
