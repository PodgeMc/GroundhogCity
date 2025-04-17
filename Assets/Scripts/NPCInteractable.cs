using UnityEngine;

public class NPCInteractable : MonoBehaviour
{
    public string npcName = "NPC";
    [TextArea] public string defaultDialogue = "Hey, nice day, huh?";
    [TextArea] public string memoryDialogue = "Oh... you heard that convo, didn’t you?";
    public string requiredMemory = "HeardShadyConvo";

    public void Interact()
    {
        if (PlayerMemory.Instance != null && PlayerMemory.Instance.Knows(requiredMemory))
        {
            Debug.Log(npcName + ": " + memoryDialogue);
        }
        else
        {
            Debug.Log(npcName + ": " + defaultDialogue);
        }
    }
}
