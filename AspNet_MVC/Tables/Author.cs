using System.ComponentModel.DataAnnotations;

namespace AspNet_MVC.Tables
{
    public class Author
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Nationality { get; set; }

                                            //Need to initialise!
        public List<Book> Books { get; set; } = []; //Authors make many books
    }
}
