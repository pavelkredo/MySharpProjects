using System.Data.Entity;

namespace ClientDbTelegramBot.Models
{
    public class ClientContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }
    }
}