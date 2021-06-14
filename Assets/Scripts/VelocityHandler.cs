using UnityEngine;

public class VelocityHandler
{
    public void CalculatePlayerVelocity(ref float velocity, Vector3 rigidbodyVelocity, bool accelerate, bool decelerate, bool brake, bool boost, float acceleration, float deceleration, float brakeForce, float boostAcceleration, float maxSpeed, float maxSpeedInBoost)
    {
        if (accelerate && !decelerate && !brake && !boost)
        {
            velocity = Mathf.MoveTowards(velocity, maxSpeed, (acceleration - rigidbodyVelocity.y) * Time.deltaTime);
        }
        else if (brake)
        {
            velocity = Mathf.MoveTowards(velocity, 0, (deceleration + rigidbodyVelocity.y) * Time.deltaTime);
        }
        else if (boost)
        {
            velocity = Mathf.MoveTowards(velocity, maxSpeedInBoost, boostAcceleration * Time.deltaTime);
        }
        else
        {
            velocity = Mathf.MoveTowards(velocity, rigidbodyVelocity.magnitude, (deceleration + rigidbodyVelocity.y) * Time.deltaTime);
        }
    }

    public float Velocity(float curVelocity, float curVelocityY, bool accelerate, bool brake, float acceleration, float deceleration, float brakeForce, float maxVelocity)
    {
        if (accelerate && !brake)
        {
            curVelocity = Mathf.MoveTowards(curVelocity, maxVelocity, acceleration * Time.deltaTime);
        }
        else if (brake)
        {
            curVelocity = Mathf.MoveTowards(curVelocity, 0, brakeForce * Time.deltaTime);
        }
        else
        {
            curVelocity = Mathf.MoveTowards(curVelocity, 0, deceleration * Time.deltaTime);
        }

        ApplySlope(ref curVelocity, curVelocityY);

        return curVelocity;
    }

    private void ApplySlope(ref float curVelocity, float curVelocityY)
    {
        curVelocity -= curVelocityY * Time.deltaTime;
    }
}
