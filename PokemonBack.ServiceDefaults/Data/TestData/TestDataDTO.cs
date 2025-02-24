using PokemonBack.ServiceDefaults.Data.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace PokemonBack.ServiceDefaults.Data.TestData
{
	public class TestDataDTO
	{
        private List<UserDTO> _userList;
        public TestDataDTO()
        {
            _userList = new List<UserDTO>()
            {
                GenerateTestUser("1"),
                GenerateTestUser("2")
            };
        }
        public UserDTO GetUserById(string id)
        {
            return _userList.FirstOrDefault(u => u.Id == id);
        }
        private UserDTO GenerateTestUser(string userID)
        {
            UserDTO user = new UserDTO
            {
                Id = userID,
                UserName = "Test" + userID
            };
            List<PokemonDTO> pokemonList = new List<PokemonDTO>();

            pokemonList.Add(GenerateTestPokemon(user, "00"));
            pokemonList.Add(GenerateTestPokemon(user, "01"));
            pokemonList.Add(GenerateTestPokemon(user, "02"));
            pokemonList.Add(GenerateTestPokemon(user, "03"));
            pokemonList.Add(GenerateTestPokemon(user, "04"));
            pokemonList.Add(GenerateTestPokemon(user, "05"));

            user.Pokemons = pokemonList;
			return user;
        }

        private PokemonDTO GenerateTestPokemon(UserDTO user,string id)
        {
			Random rnd = new Random();
			var pokemon1 = new PokemonDTO
			{
				Id = id + user.Id,
				Level = 10,
				MaxHp = 100 + rnd.Next(50),
				Attack = 50 + rnd.Next(30),
				SpAttack = 40 + rnd.Next(30),
				Defence = 30 + rnd.Next(30),
				SpDefence = 35 + rnd.Next(30),
				Speed = 45 + rnd.Next(30),
				Element = (PokemonType)rnd.Next(17),
				User = user
			};
            pokemon1.CurrentHp = pokemon1.MaxHp;
            List<MoveDTO> moveList = new List<MoveDTO>();

            moveList.Add(GenerateTestMoves(pokemon1, pokemon1.Id+"00"));
            moveList.Add(GenerateTestMoves(pokemon1, pokemon1.Id+"01"));
            moveList.Add(GenerateTestMoves(pokemon1, pokemon1.Id+"02"));
            moveList.Add(GenerateTestMoves(pokemon1, pokemon1.Id+"03"));

            pokemon1.Moves = moveList;

            return pokemon1;
		}

        private MoveDTO GenerateTestMoves(PokemonDTO pokemon,string id)
        {
            Random rnd = new Random();
            var move = new MoveDTO
            {
                Id = id,
                Power = 10 + rnd.Next(30),
                Accuracy = 20 + rnd.Next(50),
                MaxPP = 100,
                CurrentPP = 100,
                Element = (PokemonType)rnd.Next(17),
                PokemonDTO = pokemon
            };

            return move;
        }
    }
}
