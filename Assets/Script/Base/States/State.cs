public class State
{
    protected StateMachine stateMachine;
    public string name;
    public State(StateMachine stateMachine,string name)
    {
        this.stateMachine=stateMachine;
        this.name=name;
    }

    public virtual void Enter(){}
    public virtual void Update(){}
    public virtual void FixedUpdate(){}
    public virtual void Exit(){}


}
