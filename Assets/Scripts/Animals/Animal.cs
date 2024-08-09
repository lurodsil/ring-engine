using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : MonoBehaviour
{
    private Animator animator;
    [SerializeField] AnimalType animalType;
    [SerializeField] AnimalState animalState;

    [SerializeField] float targetMinDistance = 1;
    [SerializeField] float targetMaxDistance = 10;
    [SerializeField] float maxVelocity = 5;
    [SerializeField] float acceleration = 5;
    [SerializeField] List<GameObject> animals;

    private new Rigidbody rigidbody;
    private GameObject player;
    private bool animalFly;
    private Vector3 targetOffset;
    private Vector3 targetOffsetIdle;

    private void OnValidate()
    {
        for (int i = 0; i < animals.Count; i++)
        {
            if (i == (int)animalType)
            {
                animals[i].SetActive(true);
            }
            else
            {
                animals[i].SetActive(false);
            }
        }
    }

    void Start()
    {
        player = GameManager.instance.player;
        rigidbody = GetComponent<Rigidbody>();

        for (int i = 0; i < animals.Count; i++)
        {
            if (i == (int)animalType)
            {
                animals[i].SetActive(true);
                animator = animals[i].GetComponent<Animator>();
            }
            else
            {
                animals[i].SetActive(false);
            }
        }
        animator.SetInteger("animal_id", (int)animalType);

        targetOffset.x = Random.Range(-3, 3);
        targetOffset.y = Random.Range(1, 3);
        targetOffset.z = Random.Range(-3, 3);

        if (animalType == AnimalType.Picky)
        {
            targetOffset.y = 0;
        }

        targetOffsetIdle = targetOffset;
        targetOffsetIdle.y = 0;
    }

    void FixedUpdate()
    {
        animalState = rigidbody.velocity.magnitude > 0.1f ? AnimalState.Moving : AnimalState.Idle;

        if(animalState == AnimalState.Moving)
        {
            rigidbody.useGravity = false;
        }
        else
        {
            rigidbody.useGravity = true;
        }

        animator.SetInteger("animal_state", (int)animalState);

        if (player)
        {
            Vector3 offset = animalState == AnimalState.Moving ? targetOffset : targetOffsetIdle;

            Vector3 targetPosition = Player.instance.transform.position + offset;

            Vector3 targetDirection = (targetPosition - transform.position).normalized;

            float distanceToTarget = Vector3.Distance(transform.position, targetPosition);

            if (distanceToTarget > targetMinDistance && distanceToTarget < targetMaxDistance)
            {
                if (rigidbody.velocity.magnitude < maxVelocity)
                {
                    rigidbody.AddForce(targetDirection * acceleration);
                }
            }

            if (animalState == AnimalState.Moving)
            {
                Vector3 playerDir = (Player.instance.transform.position - transform.position).normalized;
                playerDir.y = 0;
                transform.rotation = Quaternion.LookRotation(playerDir, Vector3.up);
            }
        }

        
    }
}
