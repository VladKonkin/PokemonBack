using Microsoft.EntityFrameworkCore;
using PokemonBack.ServiceDefaults.Data.Context;
using PokemonBack.ServiceDefaults.Data.DTO;
using PokemonBack.ServiceDefaults.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PokemonBack.ServiceDefaults.Data.Repositories
{
	public class PokemonRepository
	{
		private readonly PokemonContext _context;

		public PokemonRepository(PokemonContext context)
		{
			_context = context;
		}

		public async Task<List<PokemonDTO>> GetAllPokemonAsync()
		{
			return await _context.PokemonDBSet
				.Include(p => p.Moves)
				.Include(p => p.User)
				.Select(p => new PokemonDTO
				{
					Id = p.Id,
					Level = p.Level,
					MaxHp = p.MaxHp,
					CurrentHp = p.CurrentHp,
					Attack = p.Attack,
					SpAttack = p.SpAttack,
					Defence = p.Defence,
					SpDefence = p.SpDefence,
					Speed = p.Speed,
					Element = p.Element,
					Moves = p.Moves.Select(m => new MoveDTO
					{
						Id = m.Id,
						Element = m.Element,
						Power = m.Power,
						Accuracy = m.Accuracy,
						MaxPP = m.MaxPP,
						CurrentPP = m.CurrentPP
					}).ToList(),
					User = new UserDTO
					{
						Id = p.User.UserId,
						UserName = p.User.UserName
					}
				})
				.ToListAsync();
		}

		// Получение покемона по Id
		public async Task<PokemonDTO> GetPokemonByIdAsync(Guid pokemonId)
		{
			var pokemon = await _context.PokemonDBSet
				.Include(p => p.Moves)
				.Include(p => p.User)
				.FirstOrDefaultAsync(p => p.Id == pokemonId);

			if (pokemon == null) return null;

			return new PokemonDTO
			{
				Id = pokemon.Id,
				Level = pokemon.Level,
				MaxHp = pokemon.MaxHp,
				CurrentHp = pokemon.CurrentHp,
				Attack = pokemon.Attack,
				SpAttack = pokemon.SpAttack,
				Defence = pokemon.Defence,
				SpDefence = pokemon.SpDefence,
				Speed = pokemon.Speed,
				Element = pokemon.Element,
				Moves = pokemon.Moves.Select(m => new MoveDTO
				{
					Id = m.Id,
					Element = m.Element,
					Power = m.Power,
					Accuracy = m.Accuracy,
					MaxPP = m.MaxPP,
					CurrentPP = m.CurrentPP
				}).ToList(),
				User  = new UserDTO()
				{
					Id = pokemon.User.UserId,
					UserName = pokemon.User.UserName
				}
			};
		}

		// Создание нового покемона
		public async Task AddPokemonAsync(PokemonDTO pokemonDto)
		{
			var pokemon = new PokemonEntity
			{
				Id = Guid.NewGuid(),
				Level = pokemonDto.Level,
				MaxHp = pokemonDto.MaxHp,
				CurrentHp = pokemonDto.CurrentHp,
				Attack = pokemonDto.Attack,
				SpAttack = pokemonDto.SpAttack,
				Defence = pokemonDto.Defence,
				SpDefence = pokemonDto.SpDefence,
				Speed = pokemonDto.Speed,
				Element = pokemonDto.Element,
				UserId = pokemonDto.User.Id,
				Moves = pokemonDto.Moves.Select(m => new MoveEntity
				{
					Id = Guid.NewGuid(),
					Element = m.Element,
					Power = m.Power,
					Accuracy = m.Accuracy,
					MaxPP = m.MaxPP,
					CurrentPP = m.CurrentPP
				}).ToList()
			};

			_context.PokemonDBSet.Add(pokemon);
			await _context.SaveChangesAsync();
		}

		// Обновление существующего покемона
		public async Task UpdatePokemonAsync(PokemonDTO pokemonDto)
		{
			var pokemon = await _context.PokemonDBSet
				.Include(p => p.Moves)
				.FirstOrDefaultAsync(p => p.Id == pokemonDto.Id);

			if (pokemon == null) throw new KeyNotFoundException("Pokemon not found");

			pokemon.Level = pokemonDto.Level;
			pokemon.MaxHp = pokemonDto.MaxHp;
			pokemon.CurrentHp = pokemonDto.CurrentHp;
			pokemon.Attack = pokemonDto.Attack;
			pokemon.SpAttack = pokemonDto.SpAttack;
			pokemon.Defence = pokemonDto.Defence;
			pokemon.SpDefence = pokemonDto.SpDefence;
			pokemon.Speed = pokemonDto.Speed;
			pokemon.Element = pokemonDto.Element;

			// Обновляем движения
			pokemon.Moves.Clear();
			foreach (var moveDto in pokemonDto.Moves)
			{
				pokemon.Moves.Add(new MoveEntity
				{
					Id = moveDto.Id == Guid.Empty ? Guid.NewGuid() : moveDto.Id,
					Element = moveDto.Element,
					Power = moveDto.Power,
					Accuracy = moveDto.Accuracy,
					MaxPP = moveDto.MaxPP,
					CurrentPP = moveDto.CurrentPP
				});
			}

			await _context.SaveChangesAsync();
		}

		// Удаление покемона
		public async Task DeletePokemonAsync(Guid pokemonId)
		{
			var pokemon = await _context.PokemonDBSet
				.Include(p => p.Moves)
				.FirstOrDefaultAsync(p => p.Id == pokemonId);

			if (pokemon == null) throw new KeyNotFoundException("Pokemon not found");

			_context.PokemonDBSet.Remove(pokemon);
			await _context.SaveChangesAsync();
		}
		public async Task<UserDTO> GetUserByIdAsync(Guid id)
		{
			//var userDTO = await _context.UserDBSet
			//.Where(u => u.UserId == id)
			//.Select(u => new UserDTO
			//{
			//	Id = u.UserId,
			//	UserName = u.UserName,
			//	Pokemons = u.Pokemons.Select(p => new PokemonDTO
			//	{
			//		Id = p.Id,
			//		Level = p.Level
			//	}).ToList()
			//})
			//.FirstOrDefaultAsync();
			var userDTO = await _context.UserDBSet
				.Where(u => u.UserId == id)
				.Include(u => u.Pokemons) // Загружаем Покемонов
					.ThenInclude(p => p.Moves) // Загружаем их атаки
				.Select(u => new UserDTO
				{
					Id = u.UserId,
					UserName = u.UserName,
					Pokemons = u.Pokemons.Select(p => new PokemonDTO
					{
						Id = p.Id,
						Level = p.Level,
						MaxHp = p.MaxHp,
						CurrentHp = p.CurrentHp,
						Attack = p.Attack,
						SpAttack = p.SpAttack,
						Defence = p.Defence,
						SpDefence = p.SpDefence,
						Speed = p.Speed,
						Element = p.Element,
						Moves = p.Moves.Select(m => new MoveDTO
						{
							Id = m.Id,
							Element = m.Element,
							Power = m.Power,
							Accuracy = m.Accuracy,
							MaxPP = m.MaxPP,
							CurrentPP = m.CurrentPP
						}).ToList()
					}).ToList()
				})
				.FirstOrDefaultAsync();
			return userDTO;
		}
		public async Task<UserDTO> GetUserByNameAsync(string name)
		{
			//var userEntity = await _context.UserDBSet
			//	.Include(p => p.Pokemons)
			//	.FirstOrDefaultAsync(u => u.UserName == name);

			//if (userEntity == null) throw new KeyNotFoundException("User Not Found");

			//var userDTO = new UserDTO(userEntity);
			//userDTO.Pokemons.ForEach(p => p.SetUser(userDTO));

			//return userDTO;
			var userDTO = await _context.UserDBSet
			.Where(u => u.UserName == name)
			.Select(u => new UserDTO
			{
				Id = u.UserId,
				UserName = u.UserName,
				Pokemons = u.Pokemons.Select(p => new PokemonDTO
				{
					Id = p.Id,
					Level = p.Level
				}).ToList()
			})
			.FirstOrDefaultAsync();
			return userDTO;
		}
	}
}

