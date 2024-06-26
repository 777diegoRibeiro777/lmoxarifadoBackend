﻿using AlmoxarifadoServices;
using AlmoxarifadoServices.DTO;
using Microsoft.AspNetCore.Mvc;

namespace AlmoxarifadoAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RequisicoesController : ControllerBase
    {
        private readonly RequisicaoService _requisicaoService;

        public RequisicoesController(RequisicaoService requisicaoService)
        {
            _requisicaoService = requisicaoService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var requisicao = _requisicaoService.ObterTodasRequisicoes();
                return Ok(requisicao);
            }
            catch (Exception)
            {
                return StatusCode(500, "Ocorreu um erro ao acessar os dados.");
            }

        }

        [HttpGet("{id}")]
        public IActionResult GetPorID(int id)
        {
            try
            {
                var grupo = _requisicaoService.ObterRequisicaoPorId(id);
                if (grupo == null)
                {
                    return StatusCode(404, "Nenhum Usuario Encontrado com Esse Codigo");
                }
                return Ok(grupo);
            }
            catch (Exception)
            {
                return StatusCode(500, "Ocorreu um erro ao acessar os dados.");
            }

        }

        [HttpPost]
        public IActionResult CriarRequisicao(RequisicaoPostDTO requisicao)
        {
            try
            {
                var requisicaoSalva = _requisicaoService.CriarRequisicao(requisicao);
                return Ok(requisicaoSalva);
            }
            catch (Exception)
            {
                return StatusCode(500, "Ocorreu um erro ao acessar os dados.");
            }
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarRequisicao(int id, RequisicaoPutDTO novaRequisicao)
        {
            try
            {
                var requisicaoAtualizada = _requisicaoService.AtualizarRequisicao(id, novaRequisicao);
                return Ok(requisicaoAtualizada);
            }
            catch (Exception)
            {
                return StatusCode(500, "Ocorreu um erro ao acessar os dados.");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeletarItemRequisicao(int id)
        {
            try
            {
                var requisicao= _requisicaoService.ObterRequisicaoPorId(id);
                if (requisicao == null)
                {
                    return StatusCode(404, "Nenhum item encontrado com este ID");
                }
                var requisicaoDeletada = _requisicaoService.DeletarItemRequisicao(requisicao);
                if (requisicaoDeletada == null)
                {
                    return StatusCode(404, "Ocorreu um erro ao excluir o item");
                }
                return Ok(requisicaoDeletada);
            }
            catch (Exception)
            {
                return StatusCode(500, "Ocorreu um erro ao acessar os dados.");
            }
        }
    }
}
