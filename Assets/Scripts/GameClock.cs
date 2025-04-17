using UnityEngine;
using UnityEngine.UI;

public class GameClock : MonoBehaviour
{
    public Text clockText;

    void Update()
    {
        float time = DayManager.Instance.GetCurrentTime();
        int hours = Mathf.FloorToInt(time / 60f) % 24;
        int minutes = Mathf.FloorToInt(time % 60);
        clockText.text = $"{hours:00}:{minutes:00}";
    }
}