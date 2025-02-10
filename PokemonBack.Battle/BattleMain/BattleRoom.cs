using PokemonBack.Battle.Models.BattleMembers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonBack.Battle.BattleMain
{
	public class BattleRoom
	{
        public Guid BattleID {  get; }
        public BattleMember FirstBattleMember { get; private set; }
		public BattleMember SecondBattleMember { get; private set; }

		public BattleRoom(BattleMember firstUser)
        {
            FirstBattleMember = firstUser;
            BattleID = Guid.NewGuid();
        }
        public void AddUser(BattleMember user)
        {
            SecondBattleMember = user;
        }

    }
}
