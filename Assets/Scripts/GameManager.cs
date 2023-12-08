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

    public PowerupManager powerupManager;
    BatterySO battery => powerupManager.Battery;
    public MagnetSO magnet => powerupManager.Magnet;

    private void Start()
    {
        coins = PlayerPrefs.GetInt("Coins");
        coinText.text = coins.ToString();

        magnet.magnetActive = false;
    }

    private void Update()
    {
        score += worldSpeed * Time.deltaTime;
        scoreText.text = score.ToString("F0");
    }

    public void GameOver()
    {
        if (battery.active) return;

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

    public void MagnetCollected()
    {
        if(magnet.magnetActive)
        {
            CancelInvoke(nameof(DeactivateMagnet));
        }
        magnet.magnetActive = true;
        Invoke(nameof(DeactivateMagnet), magnet.magnetDuration);
    }
    void DeactivateMagnet()
    {
        magnet.magnetActive = false;
    }

    public void BatteryCollected()
    {
        if (battery.active)
        {
            CancelInvoke(nameof(CancelBattery));
        }
        else
        {
            worldSpeed += battery.speedBoost;
        }
        battery.active = true;
        Invoke(nameof(CancelBattery), battery.duration);
    }
    void CancelBattery()
    {
        battery.active = false;
        worldSpeed -= battery.speedBoost;
    }
}
