using UnityEngine;
using UnityEngine.SceneManagement;

public class BattleFlow : MonoBehaviour
{
    public GameObject gameOverUI;
    public PlayerHealth playerHealth;
    public GameObject bgMusic;
    public GameObject gameWinUI;

    bool gameEnded = false;

    private void Awake()
    {
        EnemyHealth.LivingEnemyCount = 0;
    }

    private void Start()
    {
        gameOverUI.SetActive(false);
        gameWinUI.SetActive(false);

        playerHealth.onDead += OnGameOver;
    }

    private void Update()
    {
        if (!gameEnded && EnemyHealth.LivingEnemyCount <= 0)
        {
            gameEnded = true;
            OnGameWin();
        }
    }

    private void OnGameOver()
    {
        if (gameEnded) return;

        gameEnded = true;

        gameOverUI.SetActive(true);
        bgMusic.SetActive(false);

        Time.timeScale = 0f;
    }

    private void OnGameWin()
    {
        gameWinUI.SetActive(true);
        bgMusic.SetActive(false);

        playerHealth.gameObject.SetActive(false);

        Time.timeScale = 0f;
    }

    public void ReturnToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
}