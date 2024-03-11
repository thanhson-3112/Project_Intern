using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCDestroyer : MonoBehaviour
{
    [SerializeField] private float countdownDuration = 3f;

    private float currentTime;
    private bool isCountdownActive = false;

    void Start()
    {
        currentTime = countdownDuration;
    }

    void Update()
    {
        if (isCountdownActive)
        {
            currentTime -= Time.deltaTime;

            if (currentTime <= 0)
            {
               HandleCountdownCompletion();
            }
            isCountdownActive = false;
        }
        if (!isCountdownActive)
        {
            StartCoroutine(OutBuilding());
        }
    }

    public void HandleCountdownCompletion()
    {
        Debug.Log("Countdown completed!");
        gameObject.SetActive(false);
    }

    IEnumerator OutBuilding()
    {
        yield return new WaitForSeconds(3f);
        gameObject.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Building"))
        {
            isCountdownActive = true;
        }
        if (collision.gameObject.CompareTag("DestroyPoint"))
        {
            Destroy(gameObject);
        }
    }
}
