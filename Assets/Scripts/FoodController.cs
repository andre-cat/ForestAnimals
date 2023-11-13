using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodController : InBoundObject
{
    [SerializeField] private float speed;

    private void FixedUpdate()
    {
        Move();
    }

    private void Update()
    {
        if (!ImInBounds())
        {
            Destroy(gameObject);
        }
    }

    private void Move()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }

}
