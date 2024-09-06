﻿
using UnityEngine;

public class Tails : Player
{
    public float cameraTargetUpOffset = 1.7f;
    public float cameraTargetUpOffsetInAir = 1.0f;
    private bool canFly;
    public float startTime;
    bool paused;

    public override void Start()
    {
        base.Start();

        stateMachine.Initialize(this, StateIdle);

        if (GetComponent<Animator>().GetCurrentAnimatorClipInfo(0)[0].clip.name == "sn_start_wait_a")
        {
            stateMachine.Pause();
            paused = true;
        }
    }

    public override void Update()
    {
        if (stateMachine.currentStateName == "StateFall" || stateMachine.currentStateName == "StateBall" || stateMachine.currentStateName == "StateJump")
        {
            if (canFly && Input.GetButtonDown(XboxButton.A))
            {
                stateMachine.ChangeState(StateFly);
                return;
            }
        }

        base.Update();

        if (IsGrounded())
        {
            canFly = true;
        }

        if (paused)
        {
            if (GetComponent<Animator>().GetCurrentAnimatorClipInfo(0)[0].clip.name != "sn_start_wait_a")
            {
                stateMachine.Play();
                paused = false;
            }
        }

        stateMachine.OnUpdate();
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();

        stateMachine.OnFixedUpdate();
    }


    #region State Fly
    void StateFlyStart()
    {
        rigidbody.AddForce(transform.up * (15 - rigidbody.velocity.y), ForceMode.Impulse);
        UpdateTargets();
        rigidbody.drag = 2;
    }
    void StateFly()
    {


    }
    public void StateFlyPhysics()
    {
        rigidbody.AddForce(leftStickDirection * airMotion.accelerationForce, ForceMode.Acceleration);

        if (rigidbody.HorizontalVelocity().magnitude > 0.1f && !isBraking)
        {
            transform.rotation = Quaternion.LookRotation(rigidbody.HorizontalVelocity().normalized, Vector3.up);
        }

        if (Time.time > stateMachine.lastStateTime + 5)
        {
            stateMachine.ChangeState(StateFall);
        }

        //rigidbody.velocity = Vector3.Lerp(transform.forward, direction, 6 * Time.fixedDeltaTime) * rigidbody.velocity.magnitude;

        if (Input.GetButtonDown(XboxButton.A))
        {
            rigidbody.AddForce(Vector3.up * 12, ForceMode.Impulse);
        }

        if (Physics.Raycast(transform.position, Vector3.down, 2))
        {
            stateMachine.ChangeState(StateFall);
        }
    }

    void StateFlyEnd()
    {
        canFly = false;
        rigidbody.drag = 0;
    }
    #endregion

}

