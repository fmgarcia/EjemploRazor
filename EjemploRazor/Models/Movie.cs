using System.ComponentModel.DataAnnotations;
namespace EjemploRazor.Models
{
    public class Movie
    {

        public int ID { get; set; }
        public string Title { get; set; } = String.Empty;
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        public string Genre { get; set; } = String.Empty;
        public decimal Price { get; set; }

    }
}
