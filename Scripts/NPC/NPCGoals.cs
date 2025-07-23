using System.Collections.Generic;
using UnityEngine;

public class NPCGoals : MonoBehaviour
{
    public List<Goal> activeGoals = new List<Goal>();

    void Start()
    {
        // Start with some basic goals
        AddGoal("Survive", 1.0f, "Stay alive");
        AddGoal("Explore", 0.7f, "Curiosity");
        AddGoal("Rest", 0.5f, "Regain energy");
    }

    public void AddGoal(string name, float priority, string reason)
    {
        Goal goal = new Goal(name, priority, reason);
        activeGoals.Add(goal);
        SortGoals();
    }

    public void RemoveGoal(string name)
    {
        activeGoals.RemoveAll(g => g.name == name);
    }

    public Goal GetTopGoal()
    {
        if (activeGoals.Count == 0) return null;
        return activeGoals[0];
    }

    private void SortGoals()
    {
        activeGoals.Sort((a, b) => b.priority.CompareTo(a.priority));
    }

    public void ReflectOnOutcome(string action, bool success)
    {
        foreach (var goal in activeGoals)
        {
            if (goal.name == action)
            {
                if (!success)
                    goal.priority -= 0.1f;
                else
                    goal.priority += 0.1f;
            }
        }

        SortGoals();
    }
}
