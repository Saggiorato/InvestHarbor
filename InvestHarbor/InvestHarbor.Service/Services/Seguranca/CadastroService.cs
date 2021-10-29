using InvestHarbor.Data;
using InvestHarbor.Data.Models;
using InvestHarbor.Service.Models.Acesso;
using InvestHarbor.Service.Validations.Usuario;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestHarbor.Service.Services.Seguranca
{
    public class CadastroService
    {
        private readonly Contexto _contexto;

        public CadastroService()
        {
            _contexto = new Contexto();
        }

        public async Task<bool> CadastrarUsuario(CadastroViewModel dados)
        {
            try
            {
                if (!dados.Valido())
                    return false;

                var cliente = new Cliente
                {
                    Telefone = dados.Telefone,
                    Ativo = false
                };

                await _contexto.AddAsync(cliente);

                var usuario = new Usuario
                {
                    Email = dados.Email,
                    Telefone = dados.Telefone,
                    Senha = CriptografiaService.GerarHashMd5(CriptografiaService.Encrypt(dados.Senha)),
                    DataCadastro = DateTime.Now,
                    Tipo = Data.Enum.TipoUsuario.Cliente,
                    ClienteId = cliente.Id
                };

                await _contexto.AddAndSaveAsync(usuario);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> CadastrarCliente(ClienteViewModel dados)
        {
            try
            {
                if (!dados.Valido())
                    return false;

                var usuario = await _contexto.Usuarios.Where(x => x.Id == dados.UsuarioId && x.Token == dados.Token).Include(x => x.Cliente).FirstOrDefaultAsync();

                usuario.EmailVerificado = true;

                var cliente = usuario.Cliente;

                cliente.Nome = dados.Nome;
                cliente.Sobrenome = dados.Sobrenome;
                cliente.Cep = dados.Cep;
                cliente.DataCadastro = DateTime.Now;
                cliente.Cpf = dados.Cpf;
                cliente.Ativo = true;


                _contexto.Update(usuario);
                _contexto.Update(cliente);
                await _contexto.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
