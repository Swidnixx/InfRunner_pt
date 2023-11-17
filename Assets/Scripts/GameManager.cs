using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    #region Singleton
    public static GameManager Instance;
    private void Awake()
    {
        Instance = this;
    }
    #endregion

    public float worldSpeed = 2;
    public Text scoreText;
    public Text coinText;
    public GameObject gameOverPanel;
    float score;
    int coins;

    private void Start()
    {
        coins = PlayerPrefs.GetInt("Coins");
        coinText.text = coins.ToString();
    }

    private void Update()
    {
        score += worldSpeed * Time.deltaTime;
        scoreText.text = score.ToString("F0");
    }

    public void GameOver()
    {
        Time.timeScale = 0;
        gameOverPanel.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }

    public void CoinCollected()
    {
        coins++;
        coinText.text = coins.ToString();
        PlayerPrefs.SetInt("Coins", coins);
    }
}
