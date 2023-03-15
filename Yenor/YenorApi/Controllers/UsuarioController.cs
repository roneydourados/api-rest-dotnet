using Microsoft.AspNetCore.Mvc;
using YenorApi.Repositorios.UsuarioRepository;
using YenorApiModels;

namespace YenorApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IRepository<Usuario> _usuarioRepository;

        public UsuarioController(IRepository<Usuario> repository)
        {
            _usuarioRepository = repository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var listaUsuarios = _usuarioRepository.GetAll();

            return Ok(listaUsuarios);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var usuario = _usuarioRepository.Get(id);

            return Ok(usuario);
        }

        [HttpPost]
        public IActionResult Create([FromBody]Usuario usuario)
        {
            _usuarioRepository.Create(usuario);

            return Ok(usuario);
        }

        [HttpPut]
        public IActionResult Update([FromBody] Usuario usuario)
        {
            _usuarioRepository.Update(usuario);

            return Ok(usuario);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _usuarioRepository.Delete(id);

            return Ok();
        }
    }
}
