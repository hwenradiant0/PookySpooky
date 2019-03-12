using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour {

    public Transform enemyPrefab_1;
    public Transform enemyPrefab_2;
    public Transform enemyPrefab2_1;
    public Transform enemyPrefab2_2;
    public Transform enemyPrefab3_1;
    public Transform enemyPrefab3_2;

    public Vector3 Offset;

    public float make_turm;

    public Transform spawnPoint1, spawnPoint2, spawnPoint3;
    
    private float countdown;
    public float F_countdown;
    private float countdown2;
    public float F_countdown2;
    private float countdown3;
    public float F_countdown3;

    public float w_countdown;
    public static float W_countdown = 10;
    public int now_round = 0;

    public Text W_CountdownText;
    public Text waveCointdownText;
    public Text waveCointdownText2;
    public Text waveCointdownText3;

    public int Enemy_num, Enemy_num2, Enemy_num3;

    bool Check_Start = false;
    bool Check_Start2 = false;
    bool Check_Start3 = false;

    bool Check_Coroutine = true;
    bool Check_Coroutine2 = true;
    bool Check_Coroutine3 = true;

    private void Start()
    {
        countdown = F_countdown;
        countdown2 = F_countdown2;
        countdown3 = F_countdown3;
        W_countdown = w_countdown;
        Offset.z = Offset.z - 5;
    }

    
    

    void Update()
    {
        if (W_countdown > 1)
        {
            W_countdown = W_countdown - Time.deltaTime;
            W_CountdownText.text = Mathf.Floor(W_countdown).ToString();
        }

        if (Check_Start == false)
        {
            countdown = countdown - Time.deltaTime;
            if(countdown >= 0)
                waveCointdownText.text = "COUNTDOWN : " + Mathf.Floor(countdown).ToString();
            else
                waveCointdownText.text = "Warning!!!";
        }

        if (Check_Start2 == false)
        {
            countdown2 = countdown2 - Time.deltaTime;
            if (countdown2 >= 0)
                waveCointdownText2.text = "COUNTDOWN : " + Mathf.Floor(countdown2).ToString();
            else
                waveCointdownText2.text = "Warning!!!";
        }

        if (Check_Start3 == false)
        {
            countdown3 = countdown3 - Time.deltaTime;
            if (countdown3 >= 0)
                waveCointdownText3.text = "COUNTDOWN : " + Mathf.Floor(countdown3).ToString();
            else
                waveCointdownText3.text = "Warning!!!";
        }

        if (Check_Start == true && Check_Coroutine == true)
         {
             StartCoroutine(SpawnWave());
             Check_Coroutine = false;
         }

         if (Check_Start2 == true && Check_Coroutine2 == true)
         {
             StartCoroutine(SpawnWave2());
             Check_Coroutine2 = false;
         }

         if (Check_Start3 == true && Check_Coroutine3 == true)
         {
             StartCoroutine(SpawnWave3());
             Check_Coroutine3 = false;
         }
        
        if (countdown <= 0)
        {
            Check_Start = true;
        }

        if (countdown2 <= 0)
        {
            Check_Start2 = true;
        }

        if (countdown3 <= 0)
        {
            Check_Start3 = true;
        }

        if (Check_Coroutine == false)
        {
            countdown = F_countdown;
        }

        if (Check_Coroutine2 == false)
        {
            countdown2 = F_countdown2;
        }

        if (Check_Coroutine3 == false)
        {
            countdown3 = F_countdown3;
        }
    }

    IEnumerator SpawnWave()
    {
        for (int i = 0; i < Enemy_num; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(make_turm);
        }
        yield return null;
    }

    IEnumerator SpawnWave2()
    {
        for (int i = 0; i < Enemy_num2; i++)
        {
            SpawnEnemy2();
            yield return new WaitForSeconds(make_turm);
        }
        yield return null;
    }

    IEnumerator SpawnWave3()
    {
        for (int i = 0; i < Enemy_num3; i++)
        {
            SpawnEnemy3();
            yield return new WaitForSeconds(make_turm);
        }
        yield return null;
    }

    void SpawnEnemy()
    {
        Instantiate(enemyPrefab_1, spawnPoint1.position, spawnPoint1.rotation);
        Instantiate(enemyPrefab_2, spawnPoint1.position+Offset, spawnPoint1.rotation);
    }

    void SpawnEnemy2()
    {
        Instantiate(enemyPrefab2_1, spawnPoint2.position, spawnPoint2.rotation);
        Instantiate(enemyPrefab2_2, spawnPoint2.position+ Offset, spawnPoint2.rotation);
    }

    void SpawnEnemy3()
    {
        Instantiate(enemyPrefab3_1, spawnPoint3.position, spawnPoint3.rotation);
        Instantiate(enemyPrefab3_2, spawnPoint3.position+ Offset, spawnPoint3.rotation);
    }

}
