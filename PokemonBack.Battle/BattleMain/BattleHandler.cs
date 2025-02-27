using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using PokemonBack.Battle.Models.BattleMembers;
using PokemonBack.Battle.Models.TurnDataCore.StatesLog;
using PokemonBack.ServiceDefaults.Data.DTO;
using PokemonBack.ServiceDefaults.Data.Repositories;
using PokemonBack.ServiceDefaults.Data.TestData;

namespace PokemonBack.Battle.BattleMain
{
	public class BattleHandler
	{
        private List<BattleRoom> _battleRoomList;
        private List<BattleSession> _activeBattleList;

        private IServiceProvider _serviceProvider;

        public List<BattleRoom> ReadyBattleRooms => _battleRoomList;
        public List<BattleSession> ActiveBattles => _activeBattleList;
        public Action<Guid, StateLogBase> BattleStateChanged;
        public Action<BattleSession> OnBattleEnd;
        public BattleHandler(IServiceProvider serviceProvider)
        {
            _battleRoomList = new List<BattleRoom>();
			_activeBattleList = new List<BattleSession>();

			_serviceProvider = serviceProvider;
        }
        public BattleSession GetBattleById(Guid battleId)
        {
            return _activeBattleList.FirstOrDefault(b => b.Id == battleId);
        }
        public async Task<BattleRoom> CreateBattleRoom(string userId)
        {
            //
			var battleUser = await CreateBattleMemberById(userId);

            var battleRoom = new BattleRoom(battleUser);
            _battleRoomList.Add(battleRoom);
            Console.WriteLine(_battleRoomList.Count + " Create Count");
            Console.WriteLine(battleRoom + " Create battleRoom");
            return battleRoom;
        }
        public async Task<BattleSession> ConnectToFirstBattleRoom(string userId)
        {
           var battleUser = await CreateBattleMemberById(userId);

            var room = _battleRoomList[0];
            
            room.AddUser(battleUser);
			return CreateBattle(room);
        }
        public async Task<BattleSession> ConnectToBattleRoom(Guid battleId,string userId)
        {
			var room = _battleRoomList.FirstOrDefault(r => r.BattleID == battleId);

			if (room == null)
			{
				Console.WriteLine("Battle room not found!");
				return null; 
			}

			var battleUser = await CreateBattleMemberById(userId);
			room.AddUser(battleUser);
			return CreateBattle(room);

		}
        public BattleMember GetBattleMemberById(string userId)
        {
            var battle = _activeBattleList.FirstOrDefault(b => b.FirstBattleMember.GetId() == userId | b.SecondBattleMember.GetId() == userId);
            if (battle == null) throw new Exception("Battle not found");
            var battleMember = battle.FirstBattleMember.GetId() == userId ? battle.FirstBattleMember : battle.SecondBattleMember;
            if (battleMember == null) throw new Exception("BattleMember not found");
            return battleMember;
        }
        public void CloseBattleRoom(string userId)
        {
            Console.WriteLine($"Close. UserId: {userId}");
            Console.WriteLine($"Close. Count: {_battleRoomList.Count}");
            
            var battleRoom = _battleRoomList.FirstOrDefault(r => r.FirstBattleMember.GetId() == userId);
            Console.WriteLine($"Close. Battle Room: {battleRoom}");
            if(battleRoom == null)
            {
                Console.WriteLine($"Close. User not found");
                return;
            }
            _battleRoomList.Remove(battleRoom);
        }
        private BattleSession CreateBattle(BattleRoom battleRoom)
        {
			_battleRoomList.Remove(battleRoom);
            var battle = new BattleSession(battleRoom.BattleID, battleRoom.FirstBattleMember, battleRoom.SecondBattleMember);

            _activeBattleList.Add(battle);
            BattleSubscribe(battle);

			return battle;
		}
        private async Task<UserBattleMember> CreateBattleMemberById(string userId)
        {
            TestDataUserModel test = new TestDataUserModel();
            var userDTO = test.GetUserById(userId);


            //Egor json to UserDTO TODO



            var battleUser = new UserBattleMember(userDTO);

            Console.WriteLine($"User: {JsonConvert.SerializeObject(userDTO)}");
            Console.WriteLine($"User Pokemons: {JsonConvert.SerializeObject(userDTO.Pokemons)}");




            return battleUser;
		}
        private void BattleSubscribe(BattleSession battleSession)
        {
            battleSession.OnStateChangeAction += BattleInfoInvoke;
            battleSession.OnBattleEndAction += BattleEnd;
		}
        private void BattleUnSubscribe(BattleSession battleSession) 
        {
			battleSession.OnStateChangeAction -= BattleInfoInvoke;
			battleSession.OnBattleEndAction -= BattleEnd;
		}
        private void BattleInfoInvoke(Guid battleId,StateLogBase stateLogBase)
        {
            Console.WriteLine("BattleHandler BattleInfoInvoke");
            BattleStateChanged?.Invoke(battleId, stateLogBase);
		}
        private async Task BattleEnd(BattleSession battleSession)
        {
			using var scope = _serviceProvider.CreateScope();
			var battleLogRepository = scope.ServiceProvider.GetRequiredService<BattleLogRepository>();
            await battleLogRepository.AddNewBattleLog(battleSession.Id, battleSession.FirstBattleMember.GetId(), battleSession.SecondBattleMember.GetId(), battleSession.BattleLoger.GetJsonLog());
			Console.WriteLine($"BattleHandler End ");
            _activeBattleList.Remove(battleSession);
			BattleUnSubscribe(battleSession);
		}

    }
}
