using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FedoraDev.StateMachine.Implementations
{
	public class ApplicationClosedState : IState
	{
		public string Name => "Application Closed State";

		public IStateMachine StateMachine { get; private set; }

		public bool CanGoTo(IState targetState) => true;
		public void Enter(IState previousState) { }
		public void Exit(IState nextState) { }
		public void SetStateMachine(IStateMachine stateMachine) => StateMachine = stateMachine;
		public void Tick() { }
	}
}
