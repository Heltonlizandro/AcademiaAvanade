using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VoosAPI.Services;
using VoosAPI.Models;

namespace VoosAPI.Controllers
{
    public class VoosController : ControllerBase
    { 
        
        private readonly VoosService _voosService;
    

        public VoosController(VoosService voosService)
        {
            _voosService = voosService;
        }

        [HttpGet]
        [Route("/voos/todos")]
        public ActionResult<List<Voo>> Get() =>
            _voosService.Get();

        [Route("/voos/recuperar/{id}")]
        public ActionResult<Voo> Get(string id)
        {
            var voo = _voosService.Get(id);
             
            if (voo == null)
            {
                return NotFound();
            }

            return voo;
        }

        [HttpPost]
        [Route("/voos/criar")]
        public ActionResult<Voo> Create(Voo voo)
        {
            _voosService.Create(voo);

            return CreatedAtRoute("GetVoo", new { id = voo.Id.ToString() }, voo);
        }

        [HttpPut]
        [Route("/voos/atualizar/{id}")]

        public IActionResult Update(string id, Voo vooIn)
        {
            var voo = _voosService.Get(id);
            if (voo == null)
            {
                return NotFound();
            }
            _voosService.Update(id, vooIn);
            return NoContent();
        }

        [HttpDelete]
        [Route("/voos/deletar/{id}")]
        public IActionResult Delete(string id)
        {
            var voo = _voosService.Get(id);

            if (voo == null)
            {
                return NotFound();
            }

            _voosService.Remove(voo.Id);

            return NoContent();
        }

    }
}
