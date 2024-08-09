using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StompingTarget : MonoBehaviour
{
    public float returnDelay = 1;
    public float returnSpeed = 1;
    public float stompLoseHeight = 3;
    public float stompLoseHeightVelocity = 10;
    private Vector3 initialPosition;
    private Vector3 stompInitialPosition;
    private bool returnToInitialPosition = true;

    void Start()
    {
        initialPosition = transform.position;
    }

    void Update()
    {
        if (returnToInitialPosition)
        {
            transform.position = Vector3.MoveTowards(transform.position, initialPosition, returnSpeed * Time.deltaTime);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, stompInitialPosition, stompLoseHeightVelocity * Time.deltaTime);
        }
    }

    public void ReceiveStomp()
    {
        StopAllCoroutines();
        stompInitialPosition = transform.position;
        if (!Physics.Raycast(transform.position, Vector3.down, 1))
        {
            stompInitialPosition.y -= stompLoseHeight;
        }
        returnToInitialPosition = false;
        StartCoroutine(ReturnToStartPosition());
    }

    IEnumerator ReturnToStartPosition()
    {
        yield return new WaitForSeconds(returnDelay);
        returnToInitialPosition = true;
    }
}
