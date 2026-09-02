using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
//using UnityEditor.SearchService;

public class ScoreOnPickup2D : MonoBehaviour
{
    [Header("Scoring")]
    public int points = 0;

    [Header("UI Reference")]
    public TextMeshProUGUI scoreText;

    private static int pages = 0;

    private void Start()
    {
        UpdateScoreUI();
    }

    /// <summary>
    /// Update method
    /// </summary>
    private void Update()
    {
        if (pages == 10)
        {
            GameToWin();
            pages = 0;
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the player hit the object
        if (collision.CompareTag("Player"))
        {
            AddScore(points);
            Destroy(gameObject); // Remove the object after pickup
        }
    }

    public void AddScore(int amount)
    {
        pages += amount;
        UpdateScoreUI();
        if(pages >= 10)
        {
            SceneManager.LoadScene("Win");
        }
    }

    private void UpdateScoreUI()
    {
        if (scoreText != null)
            scoreText.text = "Score: " + pages;
        else
            Debug.LogWarning("Score Text not assigned in Inspector!");
    }

    public void GameToWin()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }

    public void GameToLose()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (gameObject.CompareTag("Player") && collision.gameObject.CompareTag("Enemy"))
        {
            GameToLose();
            pages = 0;
        }
    }
}
