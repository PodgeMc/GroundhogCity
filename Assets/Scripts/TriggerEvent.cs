using UnityEngine;

public class TriggerEvent : MonoBehaviour
{
    public float triggerTime = 900f; // 15:00
    public string memoryToAdd = "HeardShadyConvo";
    private bool triggered = false;

    void Update()
    {
        if (!triggered && DayManager.Instance.GetCurrentTime() >= triggerTime)
        {
            PlayerMemory.Instance.Remember(memoryToAdd);
            triggered = true;
            Debug.Log("Event triggered: " + memoryToAdd);
        }
    }
}