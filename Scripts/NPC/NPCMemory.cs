using System.Collections.Generic;
using UnityEngine;

public class NPCMemory : MonoBehaviour
{
    public List<MemoryEntry> memories = new List<MemoryEntry>();

    public void AddMemory(string description, string type, string emotion)
    {
        var entry = new MemoryEntry
        {
            description = description,
            timeBlock = TimeManager.Instance.GetTimeBlockName(),
            type = type,
            emotion = emotion
        };

        memories.Add(entry);
        Debug.Log($"[MEMORY] {description} ({emotion}) at {entry.timeBlock}");
    }
}

[System.Serializable]
public class MemoryEntry
{
    public string description;
    public string timeBlock;
    public string type;
    public string emotion;
}
