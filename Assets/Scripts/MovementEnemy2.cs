using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementEnemy2 : MonoBehaviour
{
    [SerializeField] private Vector3 patrolPointA;
    [SerializeField] private Vector3 patrolPointB;
    [SerializeField] private Vector3 patrolPointC;
    [SerializeField] private Vector3 patrolPointD;
    [SerializeField] private float speed = 4f;

    private Vector3 currentTarget;

    void Start()
    {
        currentTarget = patrolPointA;

    }
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, currentTarget, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, currentTarget) < 0.01f)
        {
            if (currentTarget == patrolPointA)
                currentTarget = patrolPointB;
            else if (currentTarget == patrolPointB)
                currentTarget = patrolPointC;
            else if (currentTarget == patrolPointC)
                currentTarget = patrolPointD;
            else
                currentTarget = patrolPointA;
        }
    }
}
