using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{

    public float Speed = 10f;
    public float E_HP = 2;

    private Transform target;
    private int wavepointIndex = 0;

    int lastwavepointIndex = -1;
    bool turn_check = false;

    public float return_money = 1;

    void Start()
    {
        target = Waypoints.points[0];
    }

    void GetNextWaypoint()
    {
        if (wavepointIndex >= Waypoints.points.Length - 1)
        {
            EndPath();
            return;
        }
        wavepointIndex++;
        target = Waypoints.points[wavepointIndex];
    }

    public void TakeDamage(float amount)
    {
        E_HP = E_HP - amount;
        if (E_HP <= 0)
        {
            PlayerStats.Money = PlayerStats.Money + return_money;
            Destroy(gameObject);
        }
    }

    public void Turn_Enemy()
    {
        if (lastwavepointIndex != wavepointIndex)
        {
            turn_check = true;
            lastwavepointIndex = wavepointIndex;
        }

        if (wavepointIndex == 1 || wavepointIndex == 7 || wavepointIndex == 9 || wavepointIndex == 13 || wavepointIndex == 17 || wavepointIndex == 23 || wavepointIndex == 27)
        {
            if (turn_check == true)
            {
                gameObject.transform.Rotate(0.0f, -90.0f, 0.0f);
                turn_check = false;
            }
        }

        if (wavepointIndex == 3 || wavepointIndex == 5 || wavepointIndex == 11 || wavepointIndex == 15 || wavepointIndex == 19 || wavepointIndex == 21 || wavepointIndex == 25)
        {
            if (turn_check == true)
            {
                gameObject.transform.Rotate(0.0f, 90.0f, 0.0f);
                turn_check = false;
            }
        }
    }


    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * Speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.2f)
        {
            GetNextWaypoint();
        }

        if (E_HP == 0)
        {
            Destroy(gameObject);
            return;
        }

        Turn_Enemy();
    }

    void EndPath()
    {
        PlayerStats.Lives--;
        Destroy(gameObject);
    }
}
