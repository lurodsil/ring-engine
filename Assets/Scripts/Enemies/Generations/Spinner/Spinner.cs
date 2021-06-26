public class Spinner : Enemy
{
    public override void Start()
    {
        base.Start();

        stateMachine.Initialize(this, Empty);
    }

    public override void Update()
    {
        base.Update();

        stateMachine.OnUpdate();
    }

    void Empty()
    {

    }
}
