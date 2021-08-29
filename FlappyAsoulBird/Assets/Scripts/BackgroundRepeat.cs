using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundRepeat : MonoBehaviour
{
    BoxCollider2D groundCollider;
    float groundHorizontalLength;

    // Start is called before the first frame update
    void Start()
    {
        groundCollider = GetComponent<BoxCollider2D>();
        groundHorizontalLength = groundCollider.size.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < -groundHorizontalLength)
        {
            Vector2 offset = new Vector2(groundHorizontalLength * 2f -0.01f, 0);
            transform.position = (Vector2)transform.position + offset;
        }
    }
}
