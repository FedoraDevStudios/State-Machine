using Sirenix.OdinInspector;
using UnityEngine;

namespace FedoraDev.StateMachine.Implementations
{
	public class DefaultStateMachine : IStateMachine
	{
		public IState CurrentState { get => _currentState; private set => _currentState = value; }

		[SerializeField, HideLabel, BoxGroup("Current State")] IState _currentState;

		public void Tick() => CurrentState.Tick();

		public void GoToState(IState state)
		{
			if (!_currentState.CanGoTo(state))
				return;

			EnterState(state);
		}

		public void ForceState(IState state)
		{
			EnterState(state);
		}

		void EnterState(IState state)
		{
			CurrentState.Exit(state);
			state.Enter(CurrentState);
			CurrentState = state;
			CurrentState.StateMachine = this;
		}

		public T GetResource<T>() => default;
	}
}
