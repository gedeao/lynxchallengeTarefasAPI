using ObjectToJSONConversion;
var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
var app = builder.Build();
// Configure the HTTP request pipeline.
app.UseHttpsRedirection();

app.MapPost("/list", () =>
{
    var response = new Tarefas();
    return response.ListarTarefas();
});

app.MapPost("/insert", async context =>
{
    // You can access the request parameters here
    var request = context.Request;

    // Retrieve values from the request
    //string param1 = request.Form["TarefaId"];
    string param1 = request.Form["TarefaTitulo"];
    string param2 = request.Form["TarefaDataCriacao"];
    string param3 = request.Form["TarefaPrazo"];
    string param4 = request.Form["TarefaAtendimento"];
    string param5 = request.Form["TarefaStatus"];
    // Do something with the parameters
    // ...
    var response = new Tarefas();
    response.inserirTarefa(param1, param2, param3, param4, param5);
    await context.Response.WriteAsync("Tarefas Inseridas Com Sucesso");
    return;
});

app.MapPost("/update", async context =>
{
    // You can access the request parameters here
    var request = context.Request;

    // Retrieve values from the request
    string param0 = request.Form["TarefaId"];
    string param1 = request.Form["TarefaTitulo"];
    string param2 = request.Form["TarefaDataCriacao"];
    string param3 = request.Form["TarefaPrazo"];
    string param4 = request.Form["TarefaAtendimento"];
    string param5 = request.Form["TarefaStatus"];
    // Do something with the parameters
    // ...
    var response = new Tarefas();
    response.updateTarefa(param0, param1, param2, param3, param4, param5 );
    await context.Response.WriteAsync("Tarefa Atualizada Com Sucesso");
    return;
});

app.MapPost("/delete", async context =>
{
    var request = context.Request;
    string param0 = request.Form["TarefaId"];
    var response = new Tarefas();
    response.deleteTarefa(param0);
    await context.Response.WriteAsync("Tarefa Deletada Com Sucesso");
    return;
});
app.Run();