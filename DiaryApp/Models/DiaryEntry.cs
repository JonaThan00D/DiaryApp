using System.ComponentModel.DataAnnotations;

namespace DiaryApp.Models
{
    public class DiaryEntry
    {

        //Each of these properties will be a column in our database

        //Anotations
        //[Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required]
        public string Title { get; set; } = string.Empty;
        [Required]
        public string Content { get; set; } = string.Empty;

        [Required]
        public DateTime Created { get; set; } = DateTime.MinValue;

    }
}
