using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour {

    private Transform target;

    [Header("Attributes")]

    public float range = 15f;
    public float fireRate = 1f; // 1초에 몇발
    private float fireCountdown = 0f;

    [Header("Unity Setup Fields")]
    public string enemyTag;
    public Transform partToRotate;
    public float turnSpeed = 10f;

    public GameObject bulletPrefab;
    public Transform firePoint;

    public int damageOverTime = 1;

    // Use this for initialization
    void Start ()
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
            Debug.Log("Distance: " + shortestDistance);
            target = nearestEnemy.transform;
        }
        else
        {
            target = null;
        }

    }
	
	// Update is called once per frame
	void Update ()
    {
        if (target == null)
            return;
       
        // 타겟 조준
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation,lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f,rotation.y,0f);

        if (fireCountdown <= 0f)
        {
            Shoot();
            fireCountdown = 1f / fireRate;
        }

        fireCountdown -= Time.deltaTime;

	}

    void Shoot()
    {
        if (target.gameObject.GetComponent<Enemy>() != null)
            target.GetComponent<Enemy>().TakeDamage(damageOverTime);
        if (target.gameObject.GetComponent<Enemy2>() != null)
            target.GetComponent<Enemy2>().TakeDamage(damageOverTime);
        if (target.gameObject.GetComponent<Enemy3>() != null)
            target.GetComponent<Enemy3>().TakeDamage(damageOverTime);

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
