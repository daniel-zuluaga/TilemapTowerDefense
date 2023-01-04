using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;
    public GameObject ImpactEffects;

    public float speed = 70f;
    public float explosionRadius = 0f;

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
        transform.LookAt(target);

    }

    void HitTarget()
    {
        GameObject effectsObj = Instantiate(ImpactEffects, transform.position, transform.rotation);
        Destroy(effectsObj, 3f);

        if(explosionRadius > 0f)
        {
            Explode();
        }
        else
        {
            Damage(target);
        }

        Destroy(gameObject);
    }

    void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (Collider collider in colliders)
        {
            if (collider.CompareTag("Enemy"))
            {
                Damage(collider.transform);
            }
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.black; 
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }

    void Damage(Transform enemy)
    {
        Destroy(enemy.gameObject); 
    }
}
