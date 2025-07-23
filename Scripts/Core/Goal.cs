public class Goal
{
    public string name;
    public float priority;
    public string reason;

    public Goal(string name, float priority, string reason = "")
    {
        this.name = name;
        this.priority = priority;
        this.reason = reason;
    }
}
