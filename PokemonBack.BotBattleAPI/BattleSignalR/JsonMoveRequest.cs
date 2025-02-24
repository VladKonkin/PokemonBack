namespace PokemonBack.BotBattleAPI.BattleSignalR
{
	public class JsonMoveRequest
	{
		public string BattleId { get; set; }
		public string PlayerId { get; set; }
		public string ActionType { get; set; } // "Attack", "SwitchPokemon"

		// Только для атак
		public string? MoveId { get; set; }

		// Только для смены покемона
		public string? NewPokemonId { get; set; }
	}
}
