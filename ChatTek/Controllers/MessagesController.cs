using Microsoft.AspNetCore.Mvc;

namespace ChatTek.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MessagesController : ControllerBase
    {

        // GET api/messages/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return $"Retornando dados da mensagem de id {id}";
        }

        [HttpGet]
        public string GetAll()
        {
            return $"Retornando todas mensagem";
        }

        [HttpPost]
        public string Create()
        {
            return $"Criando nova mensagem";
        }

        [HttpPut("{id}")]
        public string Update(int id)
        {
            return $"Atualizando mensagem id {id}";
        }

        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            return $"Deletando mensagem id {id}";
        }
    }
}
