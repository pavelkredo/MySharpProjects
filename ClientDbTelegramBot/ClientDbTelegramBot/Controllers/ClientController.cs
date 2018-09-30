using System.Collections.Generic;
using System.Web.Http;
using ClientDbTelegramBot.Models;

namespace ClientDbTelegramBot.Controllers
{
    public class ClientController : ApiController
    {
        ClientContext db = new ClientContext();

        public IEnumerable<Client> GetClients()
        {
            return db.Clients;
        }

        public Client GetClient(int id)
        {
            Client client = db.Clients.Find(id);
            return client;
        }

        [HttpPost]
        public void CreateClient([FromBody]Client client)
        {
            db.Clients.Add(client);
            db.SaveChanges();
        }

        [HttpPut]
        public void DeleteClient(int id)
        {
            Client client = db.Clients.Find(id);

            if (client != null)
            {
                db.Clients.Remove(client);
                db.SaveChanges();
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }

            base.Dispose(disposing);
        }
    }
}
