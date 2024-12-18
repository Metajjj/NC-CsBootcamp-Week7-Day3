using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AspNet_MVC.Tables
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        public int Year { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }

                //Needed to add AuthID as its the PK of author table! cannot connect via name as names can be same
        public int authorId { get; set;  } //Connects to the foreign table of author
        public Author author { get; set; } //book is by an author
    }
}
