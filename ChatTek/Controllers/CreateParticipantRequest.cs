using System.ComponentModel.DataAnnotations;

namespace ChatTek.Controllers
{
    public class CreateParticipantRequest
    {
        [Required] 
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }
    }
}
