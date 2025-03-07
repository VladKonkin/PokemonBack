using Newtonsoft.Json;

namespace PokemonBack.ServiceDefaults.Data.DTO
{
	public class MoveModel
	{
		//public Guid Id { get;  set; }
		[JsonProperty] public string Id { get;  set; }

		[JsonProperty] public PokemonType AttackType { get; set; }
		[JsonProperty] public int Power { get; set; }
		[JsonProperty] public int Accuracy { get; set; }
		[JsonProperty] public int MaxPP { get; set; }
		[JsonProperty] public int CurrentPP { get; set; }

        public MoveModel()
        {
            
        }
   //     public MoveDTO(MoveEntity moveEntity)
   //     {
   //         Id = moveEntity.Id;
			//Element = moveEntity.Element;
			//Power = moveEntity.Power;
			//Accuracy = moveEntity.Accuracy;
			//MaxPP = moveEntity.MaxPP;
			//CurrentPP = moveEntity.CurrentPP;

   //     }
    }
	public enum PokemonType
	{
		Normal,
		Fire,
		Water,
		Electric,
		Grass,
		Ice,
		Fighting,
		Poison,
		Ground,
		Flying,
		Psychic,
		Bug,
		Rock,
		Ghost,
		Dragon,
		Dark,
		Steel,
		Fairy
	}
}
