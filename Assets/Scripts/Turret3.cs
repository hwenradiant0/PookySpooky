using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret3 : MonoBehaviour
{

    private Transform target;

    [Header("General")]
    public float range = 15f;

    [Header("Use Bullets (default)")]
    public GameObject bulletPrefab;
    public float fireRate = 1f; // 1초에 몇발
    private float fireCountdown = 0f;

    [Header("Unity Setup Fields")]
    public string enemyTag;
    public Transform partToRotate;
    public float turnSpeed = 10f;

    public Transform firePoint;

    [Header("Use Laser")]
    public bool useLaser = false;

    public float damageOverTime = 1.0f;

    public LineRenderer lineRender;
    public ParticleSystem impactEffect;
    public Light impactLight;


    // Use this for initialization
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;
        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
        }
        else
        {
            target = null;
        }

    }

    // Update is called once per frame
    void Update()
    {

        if (target == null)
        {
            if (useLaser)
            {
                if (lineRender.enabled)
                {
                    lineRender.enabled = false;
                    impactEffect.Stop();
                    impactLight.enabled = false;
                }
            }
            return;
        }

        //if (target.gameObject.GetComponent<Enemy>() != null)
        {
            LockOnTarget();

            if (useLaser)
            {
                Laser();

                if (fireCountdown <= 0f)
                {
                    Shoot();
                    fireCountdown = 1f / fireRate;
                }
            }

            else
            {
                if (fireCountdown <= 0f)
                {
                    Shoot();
                    fireCountdown = 1f / fireRate;
                }
            }

            fireCountdown -= Time.deltaTime;
        }
    }
    

    void LockOnTarget()
    {
        //if (target.gameObject.GetComponent<Enemy>() != null)
        {
            Vector3 dir = target.position - transform.position;
            Quaternion lookRotation = Quaternion.LookRotation(dir);
            Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
            partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);
        }
    }

    void Laser()
    {
        if(target.gameObject.GetComponent<Enemy>() != null)
            target.GetComponent<Enemy>().TakeDamage(damageOverTime * Time.deltaTime);
        if (target.gameObject.GetComponent<Enemy2>() != null)
            target.GetComponent<Enemy2>().TakeDamage(damageOverTime * Time.deltaTime);
        if (target.gameObject.GetComponent<Enemy3>() != null)
            target.GetComponent<Enemy3>().TakeDamage(damageOverTime * Time.deltaTime);

        if (!lineRender.enabled)
        {
            lineRender.enabled = true;
            impactEffect.Play();
            impactLight.enabled = true;
        }

        lineRender.SetPosition(0, firePoint.position);
        lineRender.SetPosition(1, target.position);

        Vector3 dir = firePoint.position - target.position;

        impactEffect.transform.position = target.position + dir.normalized * 0.5f;
        impactEffect.transform.rotation = Quaternion.LookRotation(dir);

    }

    void Shoot()
    {
        GameObject bulletGo = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletGo.GetComponent<Bullet>();

        if (bullet != null)
            bullet.Seek(target);
    }


    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
