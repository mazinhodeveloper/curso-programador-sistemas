using zapTito.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Adicionar suporte a Controllers 
builder.Services.AddControllers(); 

// Configura Swagger 
builder.Services.AddEndpointsApiExplorer(); 
builder.Services.AddSwaggerGen();

// -- CONFUfIGURAÇÃO DE CORS (Essencial para o HTML funcionar) ou Requisição via HTTP ou HTTP --- 
builder.Services.AddCors( options =>
{
    options.AddPolicy("PermitirTudo", policy => 
    {
        policy.AllowAnyOrigin() // Permite que qualquer página (seu HTML) acesse a API 
              .AllowAnyMethod() // Permite que 'GET, PORT, PUT, DELETE' realize a requisição 
              .AllowAnyHeader(); // Permite enviar JSON no corpo da requisição 
    });
}); 

// Registra o Reposit�rio (Inje��o de Depend�ncia) 
builder.Services.AddScoped<RepositoryUsuario>(); 

var app = builder.Build(); 

// Habilitar o CORS ANTES de mapear os controllers CORS 
app.UseCors("PermitirTudo"); 

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(); 
} 

app.UseHttpsRedirection(); 
app.UseAuthentication(); // Importante::::: --> app.UseAuthorization();  <-- SEMPRE APÓS O CORS 
app.MapControllers();

app.Run(); 
