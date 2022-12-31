using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;
    public GameObject ImpactEffects;

    public float speed = 70f;

    public void Seek(Transform _target)
    {
        target = _target;
    }

    void Update()
    {
        VerificationBulletTarget();
    }

    void VerificationBulletTarget()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if (dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
    }

    void HitTarget()
    {
        GameObject effectsObj = Instantiate(ImpactEffects, transform.position, transform.rotation);
        Destroy(effectsObj, 2f);
        Destroy(target.gameObject);

        Destroy(gameObject);
    }
}
