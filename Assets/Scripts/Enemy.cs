using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public float speed = 4f;

    public Transform target;
    public NavMeshAgent agent;
    public Animator anim;

    void Update()
    {
        Move();
    }

    void Move()
    {
        agent.speed = speed;
        agent.SetDestination(target.position);
        anim.SetBool("Running", true);
    }

}
