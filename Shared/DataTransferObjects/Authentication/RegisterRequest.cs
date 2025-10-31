using System.ComponentModel.DataAnnotations;

namespace Shared.DataTransferObjects.Authentication
{
    public class RegisterRequest
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string parentPhonenumber { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public string Government { get; set; }
        public string FullName { get; set; }

        public int LevelNumber { get; set; }
    }
}
