using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    private BoxCollider2D wallCollider;
    private float wallVerticalLength;

    void Awake()
    {
        wallCollider = GetComponent<BoxCollider2D>();
        wallVerticalLength = wallCollider.size.y;
    }

    void Update()
    {
        if (transform.position.y < -wallVerticalLength)
        {
            RepositionBackground();
        }
    }

    private void RepositionBackground()
    {
        transform.position = new Vector3(transform.position.x, wallVerticalLength, 0);
    }
}
