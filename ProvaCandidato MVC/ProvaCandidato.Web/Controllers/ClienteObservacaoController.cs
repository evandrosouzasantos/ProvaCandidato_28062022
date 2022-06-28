using ProvaCandidato.Data.Entidade;
using ProvaCandidato.Data.Service;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ProvaCandidato.Controllers
{
    public class ClienteObservacaoController : Teste<ClienteObservacao>
    {
        private ClienteObservacaoService db = new ClienteObservacaoService();

        public ActionResult AdicionarObservacao(int id)
        {
            ClienteObservacao model = new ClienteObservacao() { ClienteId = id };
            return PartialView(model);
        }


        [HttpPost]
        public void Post(ClienteObservacao value)
        {
            ClienteObservacao model = new ClienteObservacao();
            model.ClienteId = value.ClienteId;
            model.Observacao = value.Observacao;

            db.ClienteObservacaos.Add(model);
            db.Entry(model).State = System.Data.Entity.EntityState.Added;
            db.SaveChanges();
        }



        [HttpDelete]
        public void Delete(int id)
        {
            ClienteObservacao clienteObservacao = db.ClienteObservacaos.Find(id);
            db.ClienteObservacaos.Remove(clienteObservacao);
            db.SaveChanges();
        }
    }
}