using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
namespace VerificaXmlOutlook.Models
{
    public class CadastroDbContext : DbContext
    {
        public CadastroDbContext() { }

        private static IConfigurationRoot configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true).Build();

        public CadastroDbContext(DbContextOptions<CadastroDbContext> options) : base(options)
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DbConnection"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Cadastro> Cadastros { get; set; }
    }
}
