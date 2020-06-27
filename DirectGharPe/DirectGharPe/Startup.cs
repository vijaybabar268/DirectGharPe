using DirectGharPe.Data;
using DirectGharPe.Models;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DirectGharPe.Startup))]
namespace DirectGharPe
{
    public partial class Startup
    {
        private readonly ApplicationDbContext _context;

        public Startup()
        {
            _context = new ApplicationDbContext();
        }
                
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);

            // Import some data.
            Seed.Data(_context);
        }
    }
}
