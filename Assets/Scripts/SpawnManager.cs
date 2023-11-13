using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject[] spawnables;
    [SerializeField] private float spawnSeconds;
    [SerializeField] private Type spawnAxis;
    [SerializeField] private Transform parent;
    [SerializeField] private Renderer bounds;

    private Vector3 boundsPosition;
    private Vector3 boundsSize;

    private float secondsElapsed = 0;

    private void Start()
    {
        boundsPosition = bounds.gameObject.transform.position;
        boundsSize = bounds.bounds.size;
    }

    private void Update()
    {
        if (secondsElapsed < spawnSeconds)
        {
            secondsElapsed += Time.deltaTime;
        }
        else
        {
            secondsElapsed = 0;
            Spawn();
        }
    }

    private void Spawn()
    {
        GameObject spawnable = spawnables[Random.Range(0, spawnables.Length)];

        Vector3 position = new(0, 0, 0);

        float min = 0;
        float max = 0;

        switch (spawnAxis)
        {
            case Type.X:
                min = boundsPosition.x - boundsSize.x / 2f;
                max = boundsPosition.x + boundsSize.x / 2f;
                position = new(Random.Range(min, max), parent.position.y, parent.position.z);
                break;
            case Type.Y:
                min = boundsPosition.y - boundsSize.y / 2f;
                max = boundsPosition.y + boundsSize.y / 2f;
                position = new(parent.position.x, Random.Range(min, max), parent.position.z);
                break;
            case Type.Z:
                min = boundsPosition.z - boundsSize.z / 2f;
                max = boundsPosition.z + boundsSize.z / 2f;
                position = new(parent.position.x, parent.position.y, Random.Range(min, max));
                break;
        }

        Instantiate(spawnable, position, parent.rotation, parent);
    }

    private enum Type
    {
        X,
        Y,
        Z
    }

}
