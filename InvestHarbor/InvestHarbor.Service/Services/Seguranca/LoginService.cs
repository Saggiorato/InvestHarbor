using InvestHarbor.Data;
using InvestHarbor.Service.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestHarbor.Service.Services.Seguranca
{
    public class LoginService
    {
        private readonly Contexto _contexto;
        public LoginService()
        {
            _contexto = new Contexto();
        }

        public async Task<UsuarioLogado> Logar(string cpf, string senha)
        {
            var cliente = await _contexto.Clientes.FirstOrDefaultAsync(x => x.Cpf == cpf && x.Ativo);

            if (cliente == null)
                return null;

            var usuario = await _contexto.Usuarios.FirstOrDefaultAsync(x => x.ClienteId == cliente.Id && x.Senha == CriptografiaService.GerarHashMd5(CriptografiaService.Encrypt(senha)));

            if (usuario == null)
                return null;

            var usuarioLogado = new UsuarioLogado
            {
                Nome = cliente.Nome,
                Id = usuario.Id,
            };

            return usuarioLogado;
        }
    }
}