using PokemonBack.ServiceDefaults.Data.Entity.Pokedex;
using PokemonBack.ServiceDefaults.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonBack.ServiceDefaults.Data.DTO
{
	public class MoveDTO
	{
		public Guid Id { get;  set; }

		public PokemonType Element { get; set; }
		public int Power { get; set; }
		public int Accuracy { get; set; }
		public int MaxPP { get; set; }
		public int CurrentPP { get; set; }
		public PokemonDTO PokemonDTO { get; set; }

        public MoveDTO()
        {
            
        }
        public MoveDTO(MoveEntity moveEntity)
        {
            Id = moveEntity.Id;
			Element = moveEntity.Element;
			Power = moveEntity.Power;
			Accuracy = moveEntity.Accuracy;
			MaxPP = moveEntity.MaxPP;
			CurrentPP = moveEntity.CurrentPP;

        }
    }
}
