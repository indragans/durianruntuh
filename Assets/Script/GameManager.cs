using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int score;
    public bool GameOver;
    public GameObject gameOverPanel;
    public TextMeshProUGUI scoreBoard;

    void Start()
    {
        score = 0;
        GameOver = false;
        if (gameOverPanel != null)
            gameOverPanel.SetActive(false); // panel mati saat mulai
        Time.timeScale = 1f; // pastikan waktu normal saat mulai game
    }

    public void ScoreAdd()
    {
        if (!GameOver)
        {
            score += 10;
            if (scoreBoard != null)
                scoreBoard.text = score.ToString();
        }
    }

    public void TriggerGameOver()
    {
       

        
            if (GameOver) return;   // biar cuma sekali dipanggil
            GameOver = true;

            if (gameOverPanel != null)
            {
                gameOverPanel.SetActive(true); // munculkan panel
            }

           Time.timeScale = 0f; // pause game (opsional
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
