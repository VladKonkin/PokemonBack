namespace PokemonBack.BotBattleAPI.BattleSignalR
{
	public class JsonMoveRequest
	{
		public Guid BattleId { get; set; }
		public Guid PlayerId { get; set; }
		public string ActionType { get; set; } // "Attack", "SwitchPokemon"

		// Только для атак
		public Guid? MoveId { get; set; }
		public Guid? TargetPokemonId { get; set; }

		// Только для смены покемона
		public Guid? NewPokemonId { get; set; }
	}
}
