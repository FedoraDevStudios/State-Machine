using Sirenix.OdinInspector;
using UnityEngine;

namespace FedoraDev.StateMachine.Implementations
{
    [CreateAssetMenu(fileName = "New State", menuName = "State Machine/State")]
    public class ScriptableState : SerializedScriptableObject, IState
    {
		public string Name => _state.Name;
		public IStateMachine StateMachine { get; private set; }

        [SerializeField, HideLabel, BoxGroup("State")] IState _state;

		public bool CanGoTo(IState targetState) => _state.CanGoTo(targetState);
		public void Enter(IState previousState) => _state.Enter(previousState);
		public void Tick() => _state.Tick();
		public void Exit(IState nextState) => _state.Exit(nextState);

		public void SetStateMachine(IStateMachine stateMachine)
		{
			StateMachine = stateMachine;
			_state.SetStateMachine(stateMachine);
		}
	}
}
