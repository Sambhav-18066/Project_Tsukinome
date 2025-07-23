using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public static TimeManager Instance;

    public float dayLengthInSeconds = 240f; // 4 minutes per day
    private float timer = 0f;

    public enum TimeBlock { Morning, Afternoon, Evening, Night }

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    void Update()
    {
        timer += Time.deltaTime;
    }

    public TimeBlock GetCurrentTimeBlock()
    {
        float time = timer % dayLengthInSeconds;
        float quarter = dayLengthInSeconds / 4f;

        if (time < quarter) return TimeBlock.Morning;
        else if (time < quarter * 2) return TimeBlock.Afternoon;
        else if (time < quarter * 3) return TimeBlock.Evening;
        else return TimeBlock.Night;
    }

    public string GetTimeBlockName() => GetCurrentTimeBlock().ToString();
}
