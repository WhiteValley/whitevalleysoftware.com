using System.ComponentModel.DataAnnotations;

namespace WhiteValley.ViewModels
{
    public class AskAnything
    {

        
        public string Name { get; set; }
        
        public string Contact { get; set; }

        [Required(ErrorMessage = "You haven't entered a message. Please let us know how we can help or give some feedback.")]
        public string Message { get; set; }

        public string Captcha { get; set; }

    }
}