using System.ComponentModel.DataAnnotations;

namespace API.DTOs
{
    public class EmailDto
    {
        [Required]
        public string Name {get; set;}
        [Required]
        public string PhoneNumber {get; set;}
        [Required]
        public string Email {get; set;}
        [Required]
        public string Subject {get; set;}
        [Required]
        public string Message {get; set;}
    }
}