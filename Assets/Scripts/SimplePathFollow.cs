using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimplePathFollow : MonoBehaviour
{
    [SerializeField] BezierPath path;
    [SerializeField] float velocity = 10;
    [SerializeField] float rotationDamping = 10;
    private BezierKnot bezierKnot;

    Rigidbody _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        path.PutOnPath(transform, PutOnPathMode.BinormalAndNormal, out bezierKnot, out _, 10);

        _rigidbody.velocity = bezierKnot.tangent * velocity;

        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(bezierKnot.tangent, bezierKnot.normal), rotationDamping * Time.deltaTime);
    }
}
