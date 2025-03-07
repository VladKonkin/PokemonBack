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
	public class TestDataUserModel
	{
        private List<UserModel> _userList;
        public TestDataUserModel()
        {
            _userList = new List<UserModel>()
            {
                GenerateTestUser("1"),
                GenerateTestUser("2")
            };
        }
        public UserModel GetUserById(string id)
        {
            return _userList.FirstOrDefault(u => u.Id == id);
        }
        private UserModel GenerateTestUser(string userID)
        {
            UserModel user = new UserModel
            {
                Id = userID,
                UserName = "User" + userID
            };
            List<PokemonModel> pokemonList = new List<PokemonModel>();

            pokemonList.Add(GenerateTestPokemon(user.Id, "00"));
            //pokemonList.Add(GenerateTestPokemon(user, "01"));
            //pokemonList.Add(GenerateTestPokemon(user, "02"));
            //pokemonList.Add(GenerateTestPokemon(user, "03"));
            //pokemonList.Add(GenerateTestPokemon(user, "04"));
            //pokemonList.Add(GenerateTestPokemon(user, "05"));

            user.Pokemons = pokemonList;
			return user;
        }

        public PokemonModel GenerateTestPokemon(string userId,string id)
        {
			Random rnd = new Random();
			var pokemon1 = new PokemonModel
			{
				Id = id + userId,
				Level = 10,
				MaxHp = 100 + rnd.Next(50),
				Attack = 50 + rnd.Next(30),
				SpAttack = 40 + rnd.Next(30),
				Defence = 30 + rnd.Next(30),
				SpDefence = 35 + rnd.Next(30),
				Speed = 45 + rnd.Next(30),
				PokemonType = (PokemonType)rnd.Next(17)
			};
            pokemon1.CurrentHp = pokemon1.MaxHp;
            List<MoveModel> moveList = new List<MoveModel>();

            moveList.Add(GenerateTestMoves(pokemon1, pokemon1.Id+"00"));
            moveList.Add(GenerateTestMoves(pokemon1, pokemon1.Id+"01"));
            moveList.Add(GenerateTestMoves(pokemon1, pokemon1.Id+"02"));
            moveList.Add(GenerateTestMoves(pokemon1, pokemon1.Id+"03"));

            pokemon1.Moves = moveList;

            return pokemon1;
		}

        private MoveModel GenerateTestMoves(PokemonModel pokemon,string id)
        {
            Random rnd = new Random();
            var move = new MoveModel
            {
                Id = id,
                Power = 10 + rnd.Next(30),
                Accuracy = 20 + rnd.Next(50),
                MaxPP = 100,
                CurrentPP = 100,
                AttackType = (PokemonType)rnd.Next(17),
            };

            return move;
        }
    }
}
