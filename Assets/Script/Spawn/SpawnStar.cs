using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnStar : MonoBehaviour
{
    public static SpawnStar instance;
    public GameObject star;

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

    public void SpawnStarOnScreen()
    {
        StartCoroutine(RandomSpawnStar());
    }

    IEnumerator RandomSpawnStar()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);

            int i = Random.Range(1, 4);

            if(i == 1)
            {
                Instantiate(star, new Vector3(transform.position.x - 1.5f, transform.position.y, transform.position.z), transform.rotation);
            }
            else if (i == 2)
            {
                Instantiate(star, new Vector3(transform.position.x, transform.position.y, transform.position.z), transform.rotation);
            }
            else if (i == 3)
            {
                Instantiate(star, new Vector3(transform.position.x + 1.5f, transform.position.y, transform.position.z), transform.rotation);
            }
        }
    }
}
