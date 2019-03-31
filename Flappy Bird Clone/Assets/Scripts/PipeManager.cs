using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeManager : MonoBehaviour
{
    public Pipe pipePrefab;

    // The minimum and maximum height to spawn the pipes
    public float minY = 0f;
    public float maxY = 10f;
    
    // Pipes will be spawned with a delay in between.
    public float spawnInterval = 1f;

    // TESTING: REMOVE FUNCTION LATER
    private void Start()
    {
        StartCoroutine(SpawnPipes());
    }

    private IEnumerator SpawnPipes()
    {
        while (true)
        {
            // Create a variable containing the spwan point position.
            Vector3 pos = transform.position;

            // Move the point to fit the range we've established
            pos.y = Random.Range(minY, maxY);

            // Create a copy of the pipe
            Instantiate<Pipe>(pipePrefab, pos, Quaternion.identity);

            // Delay the function by an amount of time so we don't break the game
            yield return new WaitForSeconds(spawnInterval); 
        }
    }
}
