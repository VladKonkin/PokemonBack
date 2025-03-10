﻿using PokemonBack.Battle.Models.BattleMembers;
using PokemonBack.Battle.Models.TurnDataCore;
using PokemonBack.Battle.Models.TurnDataCore.StatesLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace PokemonBack.Battle.BattleMain.StateMachine.States
{
	public class BattleCalculateState : BattleStateBase
	{
		private StateLogBase _firstStateLog;
		private StateLogBase _secondStateLog;
		public BattleCalculateState(BattleStateMachine battleStateMachine, BattleSession battle) : base(battleStateMachine, battle)
		{
		}

		public override void OnStart()
		{
			_firstStateLog = null;
			_secondStateLog = null;

            Console.WriteLine("FirstAction " + _battle.FirstBattleMember.ActiveTurnAction);
            Console.WriteLine("FirstActionPokemon " + _battle.FirstBattleMember.ActiveTurnAction.Pokemon);
            Console.WriteLine("FirstActionPokemon " + _battle.FirstBattleMember.ActiveTurnAction.Pokemon);
            Console.WriteLine("SecondAction " + _battle.SecondBattleMember.ActiveTurnAction);

			CalculateTurn(_battle.FirstBattleMember.ActiveTurnAction, _battle.SecondBattleMember.ActiveTurnAction);
		}

		public override void OnStop()
		{
			StateLog = new CalculateLog(_firstStateLog, _secondStateLog);
			
			_battle.OnStateChange(StateLog);
		}
		public override void OnBattleMemberAction()
		{
			
		}
		
		private void CalculateTurn(TurnAction firstMemberTurn, TurnAction secondMemberTurn)
		{

			if (PriorityEqualsCheck(firstMemberTurn, secondMemberTurn))
			{
				if (SpeedCheck(firstMemberTurn, secondMemberTurn))
				{
					ExecuteTurn(_battle.FirstBattleMember, _battle.SecondBattleMember, ref _firstStateLog);
					ExecuteTurn( _battle.SecondBattleMember, _battle.FirstBattleMember, ref _secondStateLog);
				}
				else
				{
					ExecuteTurn(_battle.SecondBattleMember, _battle.FirstBattleMember, ref _secondStateLog);
					ExecuteTurn(_battle.FirstBattleMember, _battle.SecondBattleMember, ref _firstStateLog);
				}
			}
			else
			{
				if (PriorityCheck(firstMemberTurn, secondMemberTurn))
				{
					ExecuteTurn(_battle.FirstBattleMember, _battle.SecondBattleMember, ref _firstStateLog);
					ExecuteTurn(_battle.SecondBattleMember, _battle.FirstBattleMember, ref _secondStateLog);
				}
				else
				{
					ExecuteTurn(_battle.SecondBattleMember, _battle.FirstBattleMember, ref _secondStateLog);
					ExecuteTurn(_battle.FirstBattleMember, _battle.SecondBattleMember, ref _firstStateLog);
				}
			}
			if (_battle.FirstBattleMember.CantСontinueBattle() | _battle.SecondBattleMember.CantСontinueBattle())
			{
				_battleStateMachine.SwitchState<BattleEndState>();
			}
			else
			{
				if (_battle.FirstBattleMember.ActivePokemon.IsAlive & _battle.SecondBattleMember.ActivePokemon.IsAlive)
				{
					_battleStateMachine.SwitchState<BattleTurnEndState>();
				}
				else
				{
					_battleStateMachine.SwitchState<BattleTurnSwitchWaitState>();
				}
			}
		}
	
		private void ExecuteTurn(BattleMember attacker, BattleMember defender, ref StateLogBase stateLog)
		{
			if (attacker.ActivePokemon.IsAlive)
			{
				if (attacker.ActiveTurnAction is MoveAction moveAction)
				{
					AttackAction(attacker, defender, ref stateLog);
				}
			}
			else if (attacker.ActiveTurnAction is SwitchAction switchAction)
			{
				SwitchAction(attacker, defender, ref stateLog);
			}

		}
		private void AttackAction(BattleMember attacker, BattleMember defender, ref StateLogBase stateLog)
		{
			int initialHp = defender.ActivePokemon.CurrentHp;

			attacker.MakeMove(defender);     
			
			int damageDealt = initialHp - defender.ActivePokemon.CurrentHp;
            
			stateLog = new AttackLog(attacker.GetId(),
				attacker.ActiveTurnAction.Pokemon.Id,
				attacker.ActiveTurnAction.Move.Id,
				defender.ActiveTurnAction.Pokemon.Id,
				damageDealt);
		}
		private void SwitchAction(BattleMember attacker, BattleMember defender, ref StateLogBase stateLog)
		{
			var prevPokemonId = attacker.ActivePokemon.Id;
			attacker.MakeMove();
			stateLog = new SwitchPokemonLog(attacker.GetId(), prevPokemonId, attacker.ActivePokemon.Id);
			Console.WriteLine("SwitchAction StateLog: " + stateLog.ToJson());
		}
		private bool SpeedCheck(TurnAction firstMemberTurn, TurnAction secondMemberTurn)
		{
			return firstMemberTurn.Pokemon.Speed >= secondMemberTurn.Pokemon.Speed;
		}
		private bool PriorityCheck(TurnAction firstMemberTurn, TurnAction secondMemberTurn)
		{
			return firstMemberTurn.Priority >= secondMemberTurn.Priority;
		}
		private bool PriorityEqualsCheck(TurnAction firstMemberTurn, TurnAction secondMemberTurn)
		{
			return firstMemberTurn.Priority == secondMemberTurn.Priority;
		}
	}
}
