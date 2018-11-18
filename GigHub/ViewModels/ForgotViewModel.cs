using System.ComponentModel.DataAnnotations;

namespace GigHub.ViewModels
{
    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Courrier électronique")]
        public string Email { get; set; }
    }
}