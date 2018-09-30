using System.Data.Entity;

namespace ClientDbTelegramBot.Models
{
    public class ClientDbInitializer : DropCreateDatabaseAlways<ClientContext>
    {
        protected override void Seed(ClientContext db)
        {
            db.Clients.Add(new Client { Surname = "Пупкин", Name = "Василий", Patronymic = "Васильевич", Birthday = "01.01.1990" });

            base.Seed(db);
        }
    }
}