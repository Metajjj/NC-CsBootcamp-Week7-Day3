using System.Text.Json;

using AspNet_MVC.Tables;

using Microsoft.EntityFrameworkCore;

namespace AspNet_MVC
{
    public class AspMvcDbContext : DbContext
    {
        public DbSet<Book> BookTable { get; set; }
        public DbSet<Author> AuthorTable { get; set; }

            //???? TODO
        public AspMvcDbContext(DbContextOptions<AspMvcDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => 
            optionsBuilder.UseSqlServer();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            var auths = JsonSerializer.Deserialize<List<Author>>(File.ReadAllText("Resources/Authors.json"));
            modelBuilder.Entity<Author>().HasData(
                auths
            );

            var books = JsonSerializer.Deserialize<List<Book>>(File.ReadAllText("Resources/Books.json"));

            //Added new FK to Books - need to populate from existing auths PK
            //TODO isn't updating!
            books.ForEach(b =>
            {
                b.authorId = auths.Find(a=> a.Name.ToLower() == b.Author.ToLower()).Id;
                    //ForEach updates the original array!
                    //Arrays store memory addresses to values!
            });

            modelBuilder.Entity<Book>().HasData(
                books
            );
        }
    }
}
