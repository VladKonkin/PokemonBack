using PokemonBack.ServiceDefaults.Data.Context;
using PokemonBack.ServiceDefaults.Data.Entity.Pokedex;
using PokemonBack.ServiceDefaults.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace PokemonBack.ServiceDefaults.Data.Seed
{
	public static class PokemonContextSeeder
	{
		//public static void Seed(this PokemonContext context)
		//{
		//	// Убедитесь, что база данных создана
		//	context.Database.EnsureCreated();

			
		//		// Создание пользователей
		//		var user1 = new UserEntity
		//		{
		//			UserId = Guid.NewGuid(),
		//			UserName = "AshKetchum"
		//		};

		//		var user2 = new UserEntity
		//		{
		//			UserId = Guid.NewGuid(),
		//			UserName = "Misty"
		//		};
				
		//		// Создание покемонов
		//		var pokemon1 = new PokemonEntity
		//		{
		//			PokemonId = Guid.NewGuid(),
		//			UserId = user1.UserId,
		//			PokemonPokedexId = Guid.NewGuid(),
		//			PokemonStatId = Guid.NewGuid()
		//		};

		//		var pokemon2 = new PokemonEntity
		//		{
		//			PokemonId = Guid.NewGuid(),
		//			UserId = user2.UserId,
		//			PokemonPokedexId = Guid.NewGuid(),
		//			PokemonStatId = Guid.NewGuid()
		//		};

		//		// Создание характеристик покемонов
		//		var pokemonStat1 = new PokemonStatEntity
		//		{
		//			Id = pokemon1.PokemonStatId,
		//			Level = 10,
		//			MaxHp = 100,
		//			CurrentHp = 100,
		//			Attack = 50,
		//			SpAttack = 40,
		//			Defence = 30,
		//			SpDefence = 35,
		//			Speed = 45,
		//			Element = Element.Fire,
		//			PokemonId = pokemon1.PokemonId
		//		};

		//		var pokemonStat2 = new PokemonStatEntity
		//		{
		//			Id = pokemon2.PokemonStatId,
		//			Level = 12,
		//			MaxHp = 120,
		//			CurrentHp = 120,
		//			Attack = 55,
		//			SpAttack = 50,
		//			Defence = 40,
		//			SpDefence = 45,
		//			Speed = 50,
		//			Element = Element.Water,
		//			PokemonId = pokemon2.PokemonId
		//		};

		//		// Создание движений
		//		var move1 = new MoveEntity
		//		{
		//			Id = Guid.NewGuid(),
		//			PokemonId = pokemon1.PokemonId,
		//			MoveStatId = Guid.NewGuid(),
		//			MovePokedexId = Guid.NewGuid()
		//		};

		//		var moveStat1 = new MoveStatEntity
		//		{
		//			Id = move1.MoveStatId,
		//			Element = Element.Fire,
		//			Power = 40,
		//			Accuracy = 90,
		//			MaxPP = 25,
		//			CurrentPP = 25,
		//			MoveId = move1.Id
		//		};

		//		var move2 = new MoveEntity
		//		{
		//			Id = Guid.NewGuid(),
		//			PokemonId = pokemon2.PokemonId,
		//			MoveStatId = Guid.NewGuid(),
		//			MovePokedexId = Guid.NewGuid()
		//		};

		//		var moveStat2 = new MoveStatEntity
		//		{
		//			Id = move2.MoveStatId,
		//			Element = Element.Water,
		//			Power = 50,
		//			Accuracy = 95,
		//			MaxPP = 20,
		//			CurrentPP = 20,
		//			MoveId = move2.Id
		//		};

			
		//	context.MoveDBSet.AddRange(move1, move2);
		//	context.MoveStatDBSet.AddRange(moveStat1, moveStat2);

		//	// Сохранение изменений
		//	context.SaveChanges();

		//}
		public static void Seed(this PokemonContext context)
		{
			var user1 = new UserEntity
			{
				UserId = Guid.NewGuid(),
				UserName = "User1"
			};
			var user2 = new UserEntity
			{
				UserId = Guid.NewGuid(),
				UserName = "User2"
			};

			var pokemon1 = new PokemonEntity
			{
				Id = Guid.NewGuid(),
				UserId = user1.UserId,
				PokemonPokedexId = Guid.NewGuid(),
				Level = 10,
				MaxHp = 100,
				CurrentHp = 100,
				Attack = 50,
				SpAttack = 40,
				Defence = 30,
				SpDefence = 35,
				Speed = 45,
				Element = PokemonType.Fire,
			};

			var pokemon2 = new PokemonEntity
			{
				Id = Guid.NewGuid(),
				UserId = user2.UserId,
				PokemonPokedexId = Guid.NewGuid(),
				Level = 12,
				MaxHp = 120,
				CurrentHp = 120,
				Attack = 55,
				SpAttack = 50,
				Defence = 40,
				SpDefence = 45,
				Speed = 50,
				Element = PokemonType.Water,
			};

			var move1 = new MoveEntity
			{
				Id = Guid.NewGuid(),
				PokemonId = pokemon1.Id,
				MovePokedexId = Guid.NewGuid(),
				Element = PokemonType.Fire,
				Power = 40,
				Accuracy = 90,
				MaxPP = 25,
				CurrentPP = 25,
			};
			var move2 = new MoveEntity
			{
				Id = Guid.NewGuid(),
				PokemonId = pokemon2.Id,
				MovePokedexId = Guid.NewGuid(),
				Element = PokemonType.Water,
				Power = 50,
				Accuracy = 95,
				MaxPP = 20,
				CurrentPP = 20,
			};
			
			var pokemon1Pokedex = new PokemonPokedexEntity
			{
				Id = pokemon1.PokemonPokedexId,
				Name = "Charmander",
				Description = "Description",
				Attack = 1,
				SpAttack = 1,
				Defence = 1,
				SpDefence = 1,
				Element = PokemonType.Fire,
				Level = 1,
				MaxHp = 1,
				Speed = 1
			};
			var pokemon2Pokedex = new PokemonPokedexEntity
			{
				Id = pokemon2.PokemonPokedexId,
				Name = "Bulba",
				Description = "Description",
				Attack = 1,
				SpAttack = 1,
				Defence = 1,
				SpDefence = 1,
				Element = PokemonType.Fire,
				Level = 1,
				MaxHp = 1,
				Speed = 1
			};
			var move1Pokedex = new MovePokedexEntity
			{
				Id = move1.MovePokedexId,
				Name = "Move1",
				Description = "Description",
				Element = PokemonType.Fire,
				Power = 1,
				Accuracy = 1,
				MaxPP = 1,

			};
			var move2Pokedex = new MovePokedexEntity
			{
				Id = move2.MovePokedexId,
				Name = "Move2",
				Description = "Description",
				Element = PokemonType.Water,
				Power = 1,
				Accuracy = 1,
				MaxPP = 1,

			};
			context.UserDBSet.Add(user1);
			context.UserDBSet.Add(user2);

			context.PokemonPokedexDbSet.Add(pokemon1Pokedex);
			context.PokemonPokedexDbSet.Add(pokemon2Pokedex);

			context.MovePokedexDbSet.Add(move1Pokedex);
			context.MovePokedexDbSet.Add(move2Pokedex);

			
			context.SaveChanges();

			context.PokemonDBSet.Add(pokemon1);
			context.PokemonDBSet.Add(pokemon2);

			context.MoveDBSet.Add(move1);
			context.MoveDBSet.Add(move2);

			context.SaveChanges();
		}
	}
}
