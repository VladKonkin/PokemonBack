using Microsoft.Extensions.DependencyInjection;
using PokemonBack.Battle.Models.BattleMembers;
using PokemonBack.Battle.Models.TurnDataCore.StatesLog;
using PokemonBack.ServiceDefaults.Data.Context;
using PokemonBack.ServiceDefaults.Data.DTO;
using PokemonBack.ServiceDefaults.Data.Entity;
using PokemonBack.ServiceDefaults.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonBack.Battle.BattleMain
{
	public class BattleHandler
	{
        private List<BattleRoom> _battleRoomList;
        private List<BattleSession> _activeBattleList;

        private PokemonRepository _pokemonRepository;
        private IServiceProvider _serviceProvider;

        public List<BattleRoom> ReadyBattles => _battleRoomList;
        public List<BattleSession> ActiveBattles => _activeBattleList;
        public Action<Guid, StateLogBase> BattleStateChanged;
        public Action<Guid> OnBattleEnd;
        public BattleHandler(IServiceProvider serviceProvider)
        {
            _battleRoomList = new List<BattleRoom>();
			_activeBattleList = new List<BattleSession>();

			_serviceProvider = serviceProvider;
        }
        public string Test()
        {
			//var test = _pokemonRepository.GetAllAsync<PokemonEntity>().Result;
			return "test";
		}
        public async Task<BattleRoom> CreateBattleRoom(Guid userId)
        {
			var battleUser = await CreateBattleMemberById(userId);

            var battleRoom = new BattleRoom(battleUser);
            _battleRoomList.Add(battleRoom);
            Console.WriteLine(_battleRoomList.Count + " Create Count");
            Console.WriteLine(battleRoom + " Create battleRoom");
            return battleRoom;
        }
        public async Task<BattleSession> ConnectToFirstBattleRoom(Guid userId)
        {
           var battleUser = await CreateBattleMemberById(userId);

            var room = _battleRoomList[0];
            
            room.AddUser(battleUser);
			return CreateBattle(room);
        }
        public async Task<BattleSession> ConnectToBattleRoom(Guid battleId,Guid userId)
        {
			//var room = _battleRoomList.FirstOrDefault(r => r.BattleID == battleId);
			//Console.WriteLine(room + " Room");
			//Console.WriteLine(_battleRoomList.Count + " Count");
			//var battleUser = await CreateBattleMemberById(userId);
			//room.AddUser(battleUser);
			//return CreateBattle(room);
			Console.WriteLine(_battleRoomList.Count + " Count (before search)");

			var room = _battleRoomList.FirstOrDefault(r => r.BattleID == battleId);

			Console.WriteLine(room + " Room"); // Здесь должно быть либо "null Room", либо объект
			Console.WriteLine(_battleRoomList.Count + " Count (after search)");

			if (room == null)
			{
				Console.WriteLine("Battle room not found!");
				return null; 
			}

			var battleUser = await CreateBattleMemberById(userId);
			room.AddUser(battleUser);
			return CreateBattle(room);

		}
        public BattleMember GetBattleMemberById(Guid userId)
        {
            var battle = _activeBattleList.FirstOrDefault(b => b.FirstBattleMember.GetId() == userId | b.SecondBattleMember.GetId() == userId);
            if (battle == null) throw new Exception("Battle not found");
            var battleMember = battle.FirstBattleMember.GetId() == userId ? battle.FirstBattleMember : battle.SecondBattleMember;
            if (battleMember == null) throw new Exception("BattleMember not found");
            return battleMember;
        }
        private BattleSession CreateBattle(BattleRoom battleRoom)
        {
			_battleRoomList.Remove(battleRoom);
            var battle = new BattleSession(battleRoom.BattleID, battleRoom.FirstBattleMember, battleRoom.SecondBattleMember);

            _activeBattleList.Add(battle);
            return battle;
		}
        private async Task<UserBattleMember> CreateBattleMemberById(Guid userId)
        {
			using var scope = _serviceProvider.CreateScope();
			var pokemonRepository = scope.ServiceProvider.GetRequiredService<PokemonRepository>();
			var userDTO = await pokemonRepository.GetUserByIdAsync(userId);

			var battleUser = new UserBattleMember(userDTO);
            return battleUser;
		}

    }
}
