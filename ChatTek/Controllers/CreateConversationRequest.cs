using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ChatTek.Controllers
{
    public class CreateConversationRequest
    {
        [Required] 
        public IEnumerable<Guid> Participants { get; set; }
    }
}
