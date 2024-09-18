using Microsoft.AspNetCore.Identity.EntityFrameworkCore ;
using Microsoft.EntityFrameworkCore ;


namespace todoAPI.Data
{

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        // Declare Class Constructor
        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options
        ) : base( options )
        {
            // To be implemented
        }
    }
}