using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // ==== Singleton (akses cepat: GameManager.I) ====
    public static GameManager I;

    void Awake()
    {
        if (I == null) I = this;
        else { Destroy(gameObject); return; }
    }

    // ==== Skor & Game Over ====
    [Header("Score")]
    public int score;
    public TextMeshProUGUI scoreBoard;

    [Header("Game Over UI")]
    public bool GameOver;
    public GameObject gameOverPanel;

    // ==== Lives / Health ====
    [Header("Lives / Health")]
    [Tooltip("Jumlah nyawa awal/maksimal")]
    public int maxLives = 3;

    [HideInInspector] public int lives;

    [Tooltip("Drag 3 ikon basket (kiri→kanan)")]
    public Image[] lifeIcons;

    // ==== Lifecycle ====
    void Start()
    {
        // init skor
        score = 0;
        if (scoreBoard != null) scoreBoard.text = "0";

        // init game over panel
        GameOver = false;
        if (gameOverPanel != null) gameOverPanel.SetActive(false);
        Time.timeScale = 1f;

        // init lives
        lives = Mathf.Clamp(maxLives, 0, 99);
        UpdateLivesUI();
    }

    // ==== Public API ====
    public void ScoreAdd(int amount = 10)
    {
        if (GameOver) return;
        score += amount;
        if (scoreBoard != null) scoreBoard.text = score.ToString();
    }

    public void LoseLife(int amount = 1)
    {
        if (GameOver) return;

        lives = Mathf.Max(0, lives - Mathf.Abs(amount));
        UpdateLivesUI();

        if (lives <= 0)
            TriggerGameOver();
    }

    public void AddLife(int amount = 1)
    {
        if (GameOver) return;

        lives = Mathf.Min(maxLives, lives + Mathf.Abs(amount));
        UpdateLivesUI();
    }

    public void SetMaxLives(int newMax, bool refill = true)
    {
        maxLives = Mathf.Max(0, newMax);
        if (refill) lives = maxLives;
        else lives = Mathf.Clamp(lives, 0, maxLives);
        UpdateLivesUI();
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
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void BackToMenu()
    {
        Time.timeScale = 1f;
        // Ganti sesuai nama scene menu kamu
        SceneManager.LoadScene("MainMenu");
    }

    // ==== Internal ====
    void UpdateLivesUI()
    {
        // Tampilkan hanya sejumlah 'lives' dari total slot (maxLives)
        if (lifeIcons == null) return;

        // Pastikan slot yang berlebih ikut disembunyikan
        for (int i = 0; i < lifeIcons.Length; i++)
        {
            if (lifeIcons[i] == null) continue;

            // Slot aktif hanya sampai maxLives (kalau kamu punya >3 slot)
            bool slotHarusAda = (i < maxLives);
            lifeIcons[i].gameObject.SetActive(slotHarusAda);

            if (slotHarusAda)
            {
                // Nyalakan ikon untuk nyawa yang masih tersisa
                lifeIcons[i].enabled = (i < lives);
            }
        }
    }
}
