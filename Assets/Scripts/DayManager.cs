using UnityEngine;
using UnityEngine.SceneManagement;

public class DayManager : MonoBehaviour
{
    public static DayManager Instance;

    [Tooltip("Current in-game time in minutes (0 - 1440)")]
    public float currentTime = 0f;

    [Tooltip("Multiplier: 0.4 means 1 real second = 0.4 in-game minutes (1 full day = 1 real hour)")]
    [Range(0.1f, 10f)]
    public float timeMultiplier = 0.4f;

    [Tooltip("Full day length in in-game minutes (default = 1440)")]
    public float dayLength = 1440f;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
        currentTime += Time.deltaTime * timeMultiplier;

        if (currentTime >= dayLength)
        {
            RestartDay();
        }
    }

    public void RestartDay()
    {
        currentTime = 0f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public float GetCurrentTime()
    {
        return currentTime;
    }
}
