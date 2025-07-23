using UnityEngine;
[RequireComponent(typeof(NPCStats))]
[RequireComponent(typeof(NPCEmotion))]
[RequireComponent(typeof(NPCMemory))]
[RequireComponent(typeof(TaskManager))]
[RequireComponent(typeof(NPCGoals))]

public class NPCBrain : MonoBehaviour
{
    private NPCStats stats;
    private NPCEmotion emotion;
    private NPCMemory memory;
    private NPCGoals goals;
    private TaskManager taskManager;

    private void Awake()
    {
        stats = GetComponent<NPCStats>();
        emotion = GetComponent<NPCEmotion>();
        memory = GetComponent<NPCMemory>();
        taskManager = GetComponent<TaskManager>();
        goals = GetComponent<NPCGoals>();

    }

    private void Update()
    {
        if (!taskManager.CanAct()) return;

        Think();
        Act();
        taskManager.SetTaskCooldown();
    }

    void Think()
    {
        string timeNow = TimeManager.Instance.GetTimeBlockName();
        // Could add predictive reasoning here later
    }

    void Act()
    {
        var topGoal = goals.GetTopGoal();
        if (topGoal == null) return;

        switch (topGoal.name)
        {
            case "Survive":
                if (stats.IsHungry())
                {
                    emotion.React("hungry");
                    memory.AddMemory("Tried to find food", "Survival", "Hungry");
                    goals.ReflectOnOutcome("Survive", true);
                }
                else
                {
                    goals.ReflectOnOutcome("Survive", false); // nothing urgent
                }
                break;

            case "Explore":
                emotion.React("curious");
                memory.AddMemory("Explored area", "Exploration", "Curious");
                goals.ReflectOnOutcome("Explore", true);
                break;

            case "Rest":
                if (stats.IsTired())
                {
                    emotion.React("tired");
                    memory.AddMemory("Went to sleep", "Rest", "Tired");
                    goals.ReflectOnOutcome("Rest", true);
                }
                else
                {
                    goals.ReflectOnOutcome("Rest", false);
                }
                break;
        }
    }

}
