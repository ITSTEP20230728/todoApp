using Microsoft.EntityFrameworkCore ;
using Microsoft.AspNetCore.Identity ;

using todoAPI.Data ;


var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

// Add database services configuration
builder.Services.AddDbContext<ApplicationDbContext>(
    options => {
        options.UseSqlServer(
            builder.Configuration.GetConnectionString("DefaultConnection")
        ) ;
    }
) ;

// Add IdentityRole
builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
.AddEntityFrameworkStores<ApplicationDbContext>()
.AddDefaultTokenProviders() ;

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
else 
{
    app.UseHttpsRedirection();
}

app.UseAuthentication() ;
app.UseAuthorization()  ;

app.Run();
