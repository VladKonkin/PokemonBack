using PokemonBack.ServiceDefaults.Data.Context;
using PokemonBack.ServiceDefaults.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonBack.ServiceDefaults.Data.Repositories
{
	public class BattleLogRepository
	{
        private BattleLogDbContext _battleLogDbContext;
        public BattleLogRepository(BattleLogDbContext battleLogDbContext)
        {
            _battleLogDbContext = battleLogDbContext;
        }


        public async Task AddNewBattleLog(Guid battleId,string firstPlayerId,string secondPlayerId,string jsonLog)
        {
            Console.WriteLine("new BattleLog ");
            var battlelog = new BattleLogEntity
            {
                Id = battleId,
                FirstBattleMemberId = firstPlayerId,
                SecondBattleMemberId = secondPlayerId,
                BattleLogJson = jsonLog
            };

            await _battleLogDbContext.BattleLogDbSet.AddAsync(battlelog);
            await _battleLogDbContext.SaveChangesAsync();
        }
        public  List<BattleLogEntity> GetAllLog()
        {

            var result = _battleLogDbContext.BattleLogDbSet.ToList();

			return result;
        }
    }
}
