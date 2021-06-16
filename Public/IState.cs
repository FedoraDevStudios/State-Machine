namespace FedoraDev.StateMachine
{
    public interface IState
    {
        string Name { get; }
        IStateMachine StateMachine { get; }

        bool CanGoTo(IState targetState);
        void Enter(IState previousState);
        void Tick();
        void Exit(IState nextState);
        void SetStateMachine(IStateMachine stateMachine);
    }
}
