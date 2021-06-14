public class Spinner : Enemy
{
    public override void Start()
    {
        base.Start();

        stateMachine.Initialize(gameObject, Empty);
    }

    public override void Update()
    {
        base.Update();

        stateMachine.Update();
    }

    void Empty()
    {

    }
}
