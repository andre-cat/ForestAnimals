
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalController : InBoundObject
{
    [SerializeField] private float speed;
    [SerializeField] private int foodNeeded;

    private PlayerController player;
    private int currentFood;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        currentFood = 0;
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Update()
    {
        if (!ImInBounds())
        {
            if (!IsFed())
            {
                player.Lives--;
                player.PrintLives();
            }

            Destroy(gameObject);
        }
    }

    private void Move()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Food") && !IsFed())
        {
            currentFood++;
            player.Score++;
            player.PrintScore();
            Destroy(collider.gameObject);
        }
    }

    public bool IsFed()
    {
        return currentFood >= foodNeeded;
    }

    public int FoodNeeded {
        get => foodNeeded;
    }

    public int CurrentFood {
        get => currentFood;
    }
}