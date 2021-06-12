namespace FedoraDev.StateMachine
{
    public interface IStateMachine
    {
        IState CurrentState { get; }

        void Tick();
        void GoToState(IState state);
        void ForceState(IState state);
    }
}
