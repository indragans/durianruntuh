using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;   // <-- tambah ini

public class GameManager : MonoBehaviour
{
    public int score;
    public bool GameOver;
    public GameObject gameOverPanel;
    public TextMeshProUGUI scoreBoard;

    [Header("Lives / Health")]
    public int maxLives = 3;
    [HideInInspector] public int lives;
    public Image[] lifeIcons; // drag 3 ikon keranjang ke sini (urut kiri->kanan)

    void Start()
    {
        score = 0;
        GameOver = false;
        if (gameOverPanel != null) gameOverPanel.SetActive(false);
        Time.timeScale = 1f;

        lives = maxLives;
        UpdateLivesUI();

        if (scoreBoard != null) scoreBoard.text = "0";
    }

    public void ScoreAdd(int amount = 10)
    {
        if (GameOver) return;
        score += amount;
        if (scoreBoard != null) scoreBoard.text = score.ToString();
    }

    public void LoseLife(int amount = 1)
    {
        if (GameOver) return;
        lives -= amount;
        if (lives < 0) lives = 0;
        UpdateLivesUI();

        if (lives <= 0)
            TriggerGameOver();
    }

    void UpdateLivesUI()
    {
        if (lifeIcons == null) return;
        for (int i = 0; i < lifeIcons.Length; i++)
        {
            if (lifeIcons[i] != null)
                lifeIcons[i].enabled = (i < lives); // hidupkan hanya sejumlah sisa nyawa
        }
    }

    public void TriggerGameOver()
    {
        if (GameOver) return;
        GameOver = true;
        if (gameOverPanel != null) gameOverPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
