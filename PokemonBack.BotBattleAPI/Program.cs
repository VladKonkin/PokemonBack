using PokemonBack.Battle.BattleMain;
using PokemonBack.Battle.Extensions;
using PokemonBack.BotBattleAPI.BattleSignalR;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.AddDBServices();
builder.AddBattleServices();
builder.Services.AddSingleton<BattleManager>();
builder.Services.AddSignalR();

builder.Services.AddCors(options =>
{
	options.AddPolicy("CorsPolicy", builder =>
	{
		builder
			.AllowAnyOrigin()   // Разрешаем любые источники
			.AllowAnyMethod()
			.AllowAnyHeader();
		// Учетные данные отключены
	});
});

var app = builder.Build();

app.MapDefaultEndpoints();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}
app.UseHttpsRedirection();

app.UseRouting();
app.UseAuthorization();
app.UseCors("CorsPolicy");
app.UseEndpoints(endpoints =>
{
	endpoints.MapHub<BattleHub>("/battleHub");
});

app.MapControllers();

app.Run();
