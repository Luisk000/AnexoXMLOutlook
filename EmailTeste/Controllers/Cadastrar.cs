using Limilabs.Client.IMAP;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System.Linq;
using VerificaXmlOutlook.Models;

namespace VerificaXmlOutlook.Controllers
{
    [Route("[controller]")]
    public class Cadastrar : Controller
    {
        private readonly CadastroDbContext context = new CadastroDbContext();

        [HttpPost]
        [Route("[action]")]
        public IActionResult Registrar(Cadastro cadastro)
        {
            var email = cadastro.Email;
            var senha = cadastro.Senha;
            var ativo = cadastro.Ativo;
            var serverImap = cadastro.ServerImap;

            using (Imap imap = new Imap())
            {
                try
                {
                    imap.Connect(serverImap);
                    imap.UseBestLogin(email, senha);
                    imap.Close();

                    context.Cadastros.Add(cadastro);
                    context.SaveChanges();

                    Log.Information("Cadastro Válido");
                    return Json("Cadastro Válido");
                }
                catch
                {
                    Log.Information("Cadastro Inálido");
                    return Json("Cadastro Inválido");
                }
            }
        }


        [HttpPost]
        [Route("[action]")]
        public IActionResult GerenciarAtivo(Cadastro cadastro, bool ativo)
        {
            try
            {
                var email = cadastro.Email;
                var senha = cadastro.Senha;
                var verificado = context.Cadastros.Where(b => b.Email == email && b.Senha == senha).Single();

                if (ativo == false)
                    verificado.Ativo = false;

                else if (ativo == true)
                    verificado.Ativo = true;

                if (context.Entry(verificado).State == EntityState.Modified)
                {
                    context.Cadastros.Update(verificado);
                    context.SaveChanges();
                    return Json("O email " + cadastro.Email + " agora está no estado " + cadastro.Ativo);
                }

                else
                    return Json("O email " + cadastro.Email + " continua no estado " + cadastro.Ativo);

            }
            catch
            {
                context.Dispose();
                return Json("Informações Inválidas");
            }

        }
    }
}

