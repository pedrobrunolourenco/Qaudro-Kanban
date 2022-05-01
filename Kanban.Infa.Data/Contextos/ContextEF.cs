using Kanban.Infa.Data.Mapping;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Kanban.Infa.Data.Contextos
{

    public class ContextEF : DbContext
    {

        public ContextEF(DbContextOptions<ContextEF> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new QuadroMapping());
            base.OnModelCreating(modelBuilder);
        }

        public static string ApplicationExeDirectory()
        {
            var location = System.Reflection.Assembly.GetExecutingAssembly().Location;
            var appRoot = Path.GetDirectoryName(location);
            return appRoot;
        }
    }

}
