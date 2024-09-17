using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementEnemy : MonoBehaviour
{
    [SerializeField] private Vector3 patrolPointA;
    [SerializeField] private Vector3 patrolPointB;
    [SerializeField] private float speed = 2f;

    private Vector3 currentTarget;

    private void Start()
    {
        currentTarget = patrolPointA;
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, currentTarget, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, currentTarget) < 0.01f)
        {
            if (currentTarget == patrolPointA)
                currentTarget = patrolPointB;
            else
                currentTarget = patrolPointA;
        }
    }
}
