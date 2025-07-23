using UnityEngine;

public class NPCEmotion : MonoBehaviour
{
    public string currentMood = "Neutral";

    public void React(string stimulus)
    {
        switch (stimulus)
        {
            case "hungry": currentMood = "Frustrated"; break;
            case "tired": currentMood = "Lethargic"; break;
            case "curious": currentMood = "Playful"; break;
            default: currentMood = "Neutral"; break;
        }

        Debug.Log($"[EMOTION] Mood is now {currentMood}");
    }
}
