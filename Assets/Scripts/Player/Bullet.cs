using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public static Bullet instance;

    private void Awake()
    {
        instance = this;
    }

    private Transform target;
    public GameObject ImpactEffects;
    public int damageEnemy;

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
        Destroy(effectsObj, 2f);

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
                Enemy enemy = collider.GetComponent<Enemy>();
                enemy.TakeDamage(3);
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
        Enemy e = enemy.GetComponent<Enemy>();

        if(e != null)
        {
            e.TakeDamage(damageEnemy);
        }
    }
}
