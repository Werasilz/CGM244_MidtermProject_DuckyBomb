using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObjectManager : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("obstacle") || other.gameObject.CompareTag("star") || other.gameObject.CompareTag("enemy"))
        {
            Destroy(other.gameObject);
        }
    }
}
