using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace FedoraDev.StateMachine.Implementations
{
    public class StateMachineBehaviour : SerializedMonoBehaviour, IStateMachine
    {
        [SerializeField, HideLabel, BoxGroup("State Machine")] IStateMachine _stateMachine;
		[SerializeField, HideLabel, BoxGroup("Resource Behaviours")] GameObject[] _resources;

		public IState CurrentState => _stateMachine.CurrentState;

		public void ForceState(IState state)
		{
			_stateMachine.ForceState(state);
			_stateMachine.CurrentState.StateMachine = this;
		}

		public void GoToState(IState state)
		{
			_stateMachine.GoToState(state);
			_stateMachine.CurrentState.StateMachine = this;
		}

		public void Tick() => _stateMachine.Tick();

		private void Awake() => _stateMachine.CurrentState.Enter(_stateMachine.CurrentState);
		void Update() => Tick();

		public T GetResource<T>()
		{
			foreach (GameObject gObject in _resources)
			{
				T resource = gObject.GetComponent<T>();
				if (resource != null)
					return resource;
			}

			return default;
		}
	}
}
