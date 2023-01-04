using Microsoft.EntityFrameworkCore;


namespace MSSA_Assignment_12._2.Models
{
    public class BookContext : DbContext
    {
        public BookContext(DbContextOptions<BookContext> options) : base(options)
        {

        }
        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().HasData(
            new Book() { Id = 1001, Price = 30, Name = "CHAINSAWMAN - Chapter 1", Author = "Tatsuki Fujimoto", Description = "Chainsaw Man follows the story of Denji, an impoverished young man who makes a contract that fuses his body with that of a dog-like devil named Pochita, granting him the ability to transform parts of his body into chainsaws.", ImageName = "ChainsawmanCh1.jpg" },
            new Book() { Id = 1002, Price = 30, Name = "Kaiju No. 8 - Chapter 1", Author = "MATSUMOTO Naoya", Description = "Kafka Hibino is a 32-year-old member of the Professional Kaiju Cleanup Corp. His job as a Monster Sweeper is to chop up and dispose of Kaiju killed by the Defense Force.", ImageName = "KaijuNo.8Ch1.jpg" },
            new Book() { Id = 1003, Price = 30, Name = "Spy x Family - Chapter 1", Author = "Tatsuya Endo", Description = "The story follows a spy who has to \"build a family\" to execute a mission, not realizing that the girl he adopts as his daughter is a telepath , and the woman he agrees to be in a marriage with is a skilled assassin .", ImageName = "SpyxFamilyCh1.jpg" }
                
                );
        }
    }
}
