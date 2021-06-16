public class Spinner : Enemy
{
    public override void Start()
    {
        base.Start();
    }

    public override void Update()
    {
        base.Update();

        if (stateMachine.initiated)
        {
            stateMachine.Update();
        }
        else
        {
            stateMachine.Initialize(gameObject, Empty);
        }
    }

    void Empty()
    {

    }
}
