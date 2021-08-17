using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Game
{
    public class Snake : MonoBehaviour
    {
        private Vector2 _direction;
        private List<Transform> _segments = new List<Transform>();
        public Transform segmentPrefab;
        public int initialSize = 3;

        // Sound variables
        [SerializeField] AudioSource foodSound;
        [SerializeField] AudioSource deathSound;

        // Randomize health add
        private int eatToHealth = 0;
        private int healthRandomCount;

        private void Start()
        {
            // Randomise possibility of health add
            healthRandomCount = Random.Range(10, 30);
            // Default game speed
            Time.timeScale = 1.0f;

            ResetState();
        }

        private void Update()
        {
            PlayerInput();
        }

        private void PlayerInput()
        {
            // Set the direction based on the input key being pressed
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
            {
                if (_direction.x != 0)
                {
                    this._direction = Vector2.up;
                }
            }
            else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
            {
                if (_direction.x != 0)
                {
                    this._direction = Vector2.down;
                }
            }

            // Set the direction based on the input key being pressed
            if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                if (_direction.x == 0)
                {
                    this._direction = Vector2.right;
                }
            }
            else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
            {
                if (_direction.x == 0)
                {
                    this._direction = Vector2.left;
                }
            }
        }

        // Buttons control
        public void InputUp()
        {
            if (_direction.x != 0)
            {
                this._direction = Vector2.up;
                Vibration.Vibrate(25L);
            }
        }

        public void InputDown()
        {
            if (_direction.x != 0)
            {
                this._direction = Vector2.down;
                Vibration.Vibrate(25L);
            }
        }

        public void InputLeft()
        {
            if (_direction.x == 0)
            {
                this._direction = Vector2.left;
                Vibration.Vibrate(25L);
            }
        }

        public void InputRight()
        {
            if (_direction.x == 0)
            {
                this._direction = Vector2.right;
                Vibration.Vibrate(25L);
            }
        }

        private void FixedUpdate()
        {
            // Set each segment's position to be the same as the one it follows.
            // We must do this in reverse order so the position is set to the previous position,
            // otherwise they will all be stacked on top of each other.
            for (int i = _segments.Count - 1; i > 0; i--)
            {
                _segments[i].position = _segments[i - 1].position;
            }

            SnakeMovement();
        }

        private void SnakeMovement()
        {
            // Increase the snake's position by one in the direction they are moving.
            // Round the position to ensure it stays aligned to the grid.
            var position = this.transform.position;
            position = new Vector3(
                Mathf.Round(position.x) + this._direction.x,
                Mathf.Round(position.y) + this._direction.y);
            this.transform.position = position;
        }

        private void Grow()
        {
            // Create a new segment
            Transform segment = Instantiate(this.segmentPrefab);

            // Position the segment at the same spot as the last segment
            segment.position = _segments[_segments.Count - 1].position;

            // Add the segment to the end of the list
            _segments.Add(segment);
        }

        private void ResetState()
        {
            // Set the initial direction of the snake, starting at the origin (center of the grid)
            this._direction = Vector2.left;
            this.transform.position = Vector3.zero;

            // Start at 1 to skip destroying the head
            for (int i = 1; i < _segments.Count; i++)
            {
                Destroy(_segments[i].gameObject);
            }

            // Clear the list then add the head (this) as the first segment
            _segments.Clear();
            _segments.Add(this.transform);

            // Grow the snake to the initial size -1 since the head was already added
            for (int i = 0; i < this.initialSize - 1; i++)
            {
                Grow();
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Food"))
            {
                // Set random health add
                eatToHealth += 1;
                if (healthRandomCount == eatToHealth)
                {
                    eatToHealth = 0;
                    LifeScript.lifeCount += 1;
                }

                // Set score
                ScoreScript.ScoreValue += 10;
                // Set HighScore
                if (ScoreScript.highScoreValue < ScoreScript.ScoreValue)
                {
                    PlayerPrefs.SetInt("highScore", ScoreScript.ScoreValue);
                }

                // Vibrate
                Vibration.Vibrate(100);
                // Play sound
                foodSound.Play();

                // Food eaten, increase the size of the snake
                Grow();
            }
            else if (other.CompareTag("Obstacle"))
            {
                // Play sound
                deathSound.Play();
                // Vibrate
                Vibration.Vibrate(200);
                // Game over, reset the state of the snake
                ResetState();
                // Decrease life
                LifeScript.lifeCount--;
                DeathMethod();
            }
        }

        // To EndGame with delay
        /*private static IEnumerator ToEndGameDelay(float time)
        {
            yield return new WaitForSeconds(time);
            
        }*/

        private void DeathMethod()
        {
            if (LifeScript.lifeCount == 0)
            {
                // To EndGame
                SceneManager.LoadScene("2_EndGame");
            }
        }
    }
}