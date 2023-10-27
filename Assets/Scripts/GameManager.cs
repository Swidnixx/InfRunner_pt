using UnityEngine;

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
    float score;

    private void Update()
    {
        score += worldSpeed * Time.deltaTime;
    }
}
