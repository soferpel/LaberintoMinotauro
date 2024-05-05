using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyInteligent : MonoBehaviour
{
    public Transform target;
    public float Velocity;
    public float timeToHit = 1f;
    public NavMeshAgent IA;
    public Animator anim;

    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);
        Debug.Log(distance);
        IA.speed = Velocity;
        IA.SetDestination(target.position);
        updateAnimations();
        if(distance > 0 && distance < 2.05)
        {
            StartCoroutine(hitActivate());
        }

    }

    void updateAnimations()
    {
        float speed1;
        speed1 = IA.velocity.magnitude;
        speed1 = Mathf.Clamp01(speed1);
        anim.SetFloat("Speed", speed1, 0.1f, Time.deltaTime);
    }

    IEnumerator hitActivate()
    {

        yield return new WaitForSeconds(timeToHit);

        hitPlayer();
    }

    void hitPlayer()
    {
        GameManager.updateDamage();
    }
}