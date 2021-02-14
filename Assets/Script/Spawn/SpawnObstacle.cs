using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObstacle : MonoBehaviour
{
    public static SpawnObstacle instance;
    public GameObject[] obstacle;

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

    public void SpawnObstacleOnScreen()
    {
        StartCoroutine(RandomSpawnObstacle());
    }

    IEnumerator RandomSpawnObstacle()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(1.5f, 4));
            
            int i = Random.Range(0, 5);

            CloneObstacle(i);
        }
    }

    private void CloneObstacle(int i)
    {
        Instantiate(obstacle[i], transform.position, transform.rotation);
    }
}
