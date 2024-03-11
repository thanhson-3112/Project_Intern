using UnityEngine;

public class NPCMovement : MonoBehaviour
{
    private Vector2[] waypoints; // Các ?i?m ??n c?a NPC v?i giá tr? y ng?u nhiên
    public float moveSpeed = 8f;
    public float pauseTime = 2f;
    private int currentWaypointIndex = 0;
    private bool isPaused = false;
    private float pauseTimer = 0f;

    void Start()
    {
        float randomNumberIndex = Random.Range(0, 3);

        int roundedIndex = Mathf.RoundToInt(randomNumberIndex);

        float[] numbers = new float[] { -6, 3, 12 };

        float X = numbers[roundedIndex];

        Debug.Log("So duoc chon la: " + X);

        waypoints = new Vector2[]
        {
            new Vector2(-15f, -3f),
            new Vector2(X, -3f),
            new Vector2(X, 2f),
            new Vector2(X, -3f),
            new Vector2(17f, -3f)
        };

        transform.position = waypoints[0]; 
    }

    void Update()
    {
        if (!isPaused)
        {
            Vector2 targetPosition = waypoints[currentWaypointIndex];

            if ((Vector2)transform.position != targetPosition)
            {
                transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
            }
            else
            {
                isPaused = true;
                pauseTimer = 0f;
            }
        }
        else
        {
            pauseTimer += Time.deltaTime;
            if (pauseTimer >= pauseTime)
            {
                isPaused = false;
                currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
            }
        }
    }
}
