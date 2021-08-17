using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Food : MonoBehaviour
{
    public BoxCollider2D gridArea;

    private void Start()
    {
        RandomizePosition();
    }

    private void RandomizePosition()
    {
        Bounds bounds = this.gridArea.bounds;

        // Pick a random position inside the bounds
        float x = Random.Range(bounds.min.x, bounds.max.x);
        float y = Random.Range(bounds.min.y, bounds.max.y);

        // Set the food position but round the values to ensure it aligns with the grid
        this.transform.position = new Vector2(Mathf.Round(x), Mathf.Round(y));
    }

    /*private void OnTriggerEnter2D(Collider2D other)
    {
        // Move the food to a new position when the snake eats it
        if (other.CompareTag("Obstacle") || other.CompareTag("Player"))
        {
            // Move the food to a new position when the snake eats it
            RandomizePosition();
        }
    }*/

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Obstacle") || other.CompareTag("Player"))
        {
            // Move the food to a new position when the snake eats it
            RandomizePosition();
        }
    }
}