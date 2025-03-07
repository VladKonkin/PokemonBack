using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonBack.ServiceDefaults.Data.Model
{
	public class PokemonAbillityModel
	{
		[JsonProperty] public string Name { get; set; }
		[JsonProperty] public string Description { get;set; }
		[JsonProperty] public bool IsHidden { get; set; }
	}
}
