public class ReactionPlate : GenerationsObject
{


    public bool IsChangeCameraWhenPathChange = true;
    public bool IsPathChange = false;
    public float MainAcceptingTime = 1.1f;
    public float PreAcceptingTime = 0.5f;
    public int Target;
    public float Type = 0f;
    public float m_Difficulty = 1f;
    public float m_FailOutOfControlTime = 3f;
    public float m_JumpMaxVelocity = 0f;
    public float m_JumpMinVelocity = 0f;
    public float m_Score = 1000f;

    public void SetupObject()
    {

    }
}