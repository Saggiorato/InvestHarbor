using InvestHarbor.Service.Models;
using InvestHarbor.Service.Services.Clientes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvestHarbor.Site.Apis
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly ClienteService _clienteService;

        public ClienteController()
        {
            _clienteService = new ClienteService();
        }

        [HttpGet]
        public async Task<RetornoViewModel> ObterClientes(string nome)
        {
            var clientes = await _clienteService.ObterClientes(nome);

            return clientes;
        }

        [HttpGet("ObterClientesComSaldoDisponivel")]
        public async Task<RetornoViewModel> ObterClientesComSaldoDisponivel(string nome)
        {
            var clientes = await _clienteService.ObterClientesComSaldoDisponivel(nome);

            return clientes;
        }
    }
}
