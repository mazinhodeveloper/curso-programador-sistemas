using zapTito.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Adicionar suporte a Controllers 
builder.Services.AddControllers(); 

// Configura Swagger 
builder.Services.AddEndpointsApiExplorer(); 
builder.Services.AddSwaggerGen();

// Registra o Repositório (Injeção de Dependência) 
builder.Services.AddScoped<RepositoryUsuario>(); 

var app = builder.Build(); 

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(); 
} 

app.UseHttpsRedirection(); 
app.UseAuthentication(); 
app.MapControllers();

app.Run(); 
