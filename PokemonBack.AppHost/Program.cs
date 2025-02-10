

var builder = DistributedApplication.CreateBuilder(args);





var postgres = builder.AddPostgres("postgres");


builder.AddProject<Projects.PokemonBack_BotBattleAPI>("pokemonback-botbattleapi")
	.WithReference(postgres);



builder.Build().Run();
