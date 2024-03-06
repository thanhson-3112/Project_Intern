using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCDestroyer : MonoBehaviour
{
    [SerializeField] private float countdownDuration = 3;

    private float currentTime; // Set the countdown duration in seconds
    private bool isCountdownActive = false;
    // Start is called before the first frame update
    void Start()
    {
        currentTime = countdownDuration;
    }

    // Update is called once per frame
    void Update()
    {
        if (isCountdownActive)
        {
            currentTime -= Time.deltaTime;

            if (currentTime <= 0)
            {
                // Countdown has reached zero, handle the event
                HandleCountdownCompletion();
            }
        }
    }
    void HandleCountdownCompletion()
    {
        // Perform actions when the countdown reaches zero
        Debug.Log("Countdown completed!");
        isCountdownActive = false;

        Destroy(gameObject);
    }

    public void StartCountdown()
    {
        // Start the countdown
        isCountdownActive = true;

    }

    // Sau khi den dich thi se dem nguoc roi destroy gameobject

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Building"))
        {
            // Debug.Log(collision.gameObject.name);

            StartCountdown();
        }
    }
}
