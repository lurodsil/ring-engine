using UnityEngine;
using System.Collections;

public class Needlenose : MonoBehaviour {

    public bool attackPlayer;
    new Rigidbody rigidbody;
    Vector3 pos;


	// Use this for initialization
	void Start () {
        rigidbody = GetComponent<Rigidbody>();

       
	}
	
	// Update is called once per frame
	void Update () {
        pos = transform.position;

        RaycastHit hit = new RaycastHit();

        bool grounded = Physics.Raycast(transform.position, transform.forward, out hit, 0.8f);

        if (attackPlayer && !grounded)
        {
            transform.forward = Vector3.Lerp(transform.forward, Vector3.down, 10 * Time.deltaTime);

            rigidbody.useGravity = true;


        }
        else if (grounded)
        {

            rigidbody.velocity = Vector3.zero;
        }
        else
        {
            pos.y = Mathf.PingPong(Time.time, 0.2f);
            pos.y += 3;
        }

        if (rigidbody.velocity.magnitude > 5)
        {
            transform.forward = rigidbody.velocity.normalized;
        }

        transform.position = pos;

	}
}
