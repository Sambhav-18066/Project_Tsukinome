using UnityEngine;

public class TaskManager : MonoBehaviour
{
    public float taskCooldown = 2f; // seconds between decisions
    private float taskTimer = 0f;

    public bool CanAct()
    {
        return Time.time >= taskTimer;
    }

    public void SetTaskCooldown()
    {
        taskTimer = Time.time + taskCooldown;
    }
}
