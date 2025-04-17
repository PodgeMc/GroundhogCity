using System.Collections.Generic;
using UnityEngine;

public class PlayerMemory : MonoBehaviour
{
    public static PlayerMemory Instance;
    public List<string> memories = new List<string>();

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
    }

    public void Remember(string memory)
    {
        if (!memories.Contains(memory))
        {
            memories.Add(memory);
            Debug.Log("Remembered: " + memory);
        }
    }

    public bool Knows(string memory)
    {
        return memories.Contains(memory);
    }
}