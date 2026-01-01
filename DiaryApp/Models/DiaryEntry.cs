using System.ComponentModel.DataAnnotations;

namespace DiaryApp.Models
{
    public class DiaryEntry
    {

        //Each of these properties will be a column in our database

        //Anotations
        //[Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required(ErrorMessage = "Title can not be empty")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Title must be between 3 and 100 characters!")]
        public string Title { get; set; } = string.Empty;
        [Required(ErrorMessage = "Content can not be empty")]
        public string Content { get; set; } = string.Empty;

        [Required(ErrorMessage = "The date can not be empty")]
        public DateTime Created { get; set; } = DateTime.MinValue;

    }
}
