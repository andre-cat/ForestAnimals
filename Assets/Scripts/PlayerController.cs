using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : InBoundObject
{

    [SerializeField] private float speed;

    [SerializeField] private GameObject[] projectiles;

    private float horizontalInput;
    private float verticalInput;

    private int lives;
    private int score;

    private Vector3 lastPosition;

    private void Start()
    {
        lives = 3;
        score = 0;

        PrintLives();
        PrintScore();
    }

    private void FixedUpdate()
    {
        TrackInput();
    }

    private void Update()
    {
        if (ImInBounds())
        {
            Move();
            lastPosition = transform.position;
        }
        else
        {
            transform.position = lastPosition;
        }

        if (!ImAlive())
        {
            Debug.Log("Game Over");
        }
    }

    private void TrackInput()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
    }

    private void Move()
    {
        transform.Translate(Vector3.forward * verticalInput * speed * Time.deltaTime);
        transform.Translate(Vector3.right * horizontalInput * speed * Time.deltaTime);

        float h = 1;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject projectile = projectiles[Random.Range(0, projectiles.Length)];

            Instantiate(projectile, transform.position + new Vector3(0, h, 0), transform.rotation);
        }
    }

    private bool ImAlive()
    {
        return lives > 0;
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("AgressiveAnimal"))
        {
            lives--;
            PrintLives();
        }
    }

    public void PrintLives()
    {
        Debug.Log($"Lives: {lives}");
    }

    public void PrintScore()
    {
        Debug.Log($"Score: {score}");
    }

    public int Lives
    {
        get => lives;
        set => lives = value;
    }

    public int Score
    {
        get => score;
        set => score = value;
    }

}
