using System.ComponentModel.DataAnnotations;


namespace WhiteValley.ViewModels
{
    public class ContactRequest
    {

        [MaxLength(50)]
        public string Name { get; set; }

        [Display(Name = "Email/Phone number"), MaxLength(100)]
        public string Contact { get; set; }

        [Required(ErrorMessage = "You haven't entered a message. What would you like to say?")]
        [MaxLength(1000)]
        public string Message { get; set; }

        public string Captcha { get; set; }

    }
}