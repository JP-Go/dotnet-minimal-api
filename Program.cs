using MinimalApi.Dtos;
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapPost("/login", (LoginDTO loginDTO) =>
{
    if (loginDTO.Email == "admin@teste.com" && loginDTO.Password == "123456")
    {
        return Results.Ok("Login feito com sucesso!");
    }
    else
    {
        return Results.Unauthorized();
    }

});

app.Run();
