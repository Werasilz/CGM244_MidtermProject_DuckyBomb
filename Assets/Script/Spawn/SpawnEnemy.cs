using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    [SerializeField] private GameObject danger;
    public static SpawnEnemy instance;
    private float minRandom;
    private float maxRandom;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        Difficult();
    }

    //Difficult 7 Level
    //1. 0 - 19
    //2. 20 - 39
    //3. 40 - 59
    //4. 60 - 89
    //5. 90 - 119
    //6. 120 - 149
    //7. 150

    private void Difficult()
    {
        if (GameManager.instance.score >= 0 && GameManager.instance.score <= 19)
        {
            Debug.Log("Very Easy Mode");
            GameManager.instance.speedEnemy = 200;
            GameManager.instance.speedObstacle = 2;
            minRandom = 6;
            maxRandom = 9;
        }
        else if (GameManager.instance.score >= 20 && GameManager.instance.score <= 39)
        {
            Debug.Log("Easy Mode");
            GameManager.instance.speedEnemy = 250;
            GameManager.instance.speedObstacle = 2.5f;
            minRandom = 4;
            maxRandom = 7;
        }
        else if (GameManager.instance.score >= 40 && GameManager.instance.score <= 59)
        {
            Debug.Log("Normal Mode");
            GameManager.instance.speedEnemy = 300;
            GameManager.instance.speedObstacle = 3;
            minRandom = 2;
            maxRandom = 5;
        }
        else if (GameManager.instance.score >= 60 && GameManager.instance.score <= 89)
        {
            Debug.Log("Hard Mode");
            GameManager.instance.speedEnemy = 350;
            GameManager.instance.speedObstacle = 3.5f;
            minRandom = 1;
            maxRandom = 2;
        }
        else if (GameManager.instance.score >= 90 && GameManager.instance.score <= 119)
        {
            Debug.Log("Very Hard Mode");
            GameManager.instance.speedEnemy = 400;
            GameManager.instance.speedObstacle = 4;
            minRandom = 0.5f;
            maxRandom = 1.5f;
        }
        else if (GameManager.instance.score >= 120 && GameManager.instance.score <= 149)
        {
            Debug.Log("God Mode");
            GameManager.instance.speedEnemy = 450;
            GameManager.instance.speedObstacle = 4.5f;
            minRandom = 0.5f;
            maxRandom = 1.5f;
        }
        else if (GameManager.instance.score >= 150)
        {
            Debug.Log("Oh My Holy God Mode");
            GameManager.instance.speedEnemy = 500;
            GameManager.instance.speedObstacle = 5;
            minRandom = 0.5f;
            maxRandom = 1.5f;
        }
    }

    IEnumerator RandomSpawnEnemy()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minRandom, maxRandom));

            int i = Random.Range(1, 4);

            if (i == 1)
            {
                danger.SetActive(true);
                danger.transform.position = new Vector3(-1.5f, 3.9f, 0);
                Invoke("SpawnEnemy1", 3);
            }
            else if (i == 2)
            {
                danger.SetActive(true);
                danger.transform.position = new Vector3(0, 3.9f, 0);
                Invoke("SpawnEnemy2", 3);
            }
            else if (i == 3)
            {
                danger.SetActive(true);
                danger.transform.position = new Vector3(1.5f, 3.9f, 0);
                Invoke("SpawnEnemy3", 3);
            }
        }
    }

    public void SpawnEnemyOnScreen()
    {
        StartCoroutine(RandomSpawnEnemy());
    }

    private void SpawnEnemy1()
    {
        danger.SetActive(false);
        Instantiate(enemy, new Vector3(transform.position.x - 1.5f, transform.position.y, transform.position.z), transform.rotation);
    }

    private void SpawnEnemy2()
    {
        danger.SetActive(false);
        Instantiate(enemy, new Vector3(transform.position.x, transform.position.y, transform.position.z), transform.rotation);
    }

    private void SpawnEnemy3()
    {
        danger.SetActive(false);
        Instantiate(enemy, new Vector3(transform.position.x + 1.5f, transform.position.y, transform.position.z), transform.rotation);
    }
}
