using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBoundsX : MonoBehaviour
{
    private float leftLimit = -40;
    private float bottomLimit = 0;

    void Update()
    {
        // Destroy dogs if x position less than left limit
        if (gameObject.CompareTag("Dog") && transform.position.x < leftLimit)
        {
            Destroy(gameObject);
        }
        // Destroy balls if y position is less than bottomLimit
        else if (gameObject.CompareTag("Ball") && transform.position.y < bottomLimit)
        {
            Destroy(gameObject);
        }
    }
}
