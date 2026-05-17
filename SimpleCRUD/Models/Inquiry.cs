using System.ComponentModel.DataAnnotations;

namespace SimpleCRUD.Models
{
    public class Inquiry
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Subject Title is required.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Please select a category.")]
        public string Category { get; set; }

        [Required(ErrorMessage = "Message cannot be empty.")]
        public string Message { get; set; }
    }
}