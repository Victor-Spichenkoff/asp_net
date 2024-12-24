using Estudo1.Helpers;

var builder = WebApplication.CreateBuilder(args);


// o parâmetro this é passado aqui quando uso builder.
builder.ConfigureBuilder();

var app = builder.Build();

app.ConfigureApp();

app.Run();