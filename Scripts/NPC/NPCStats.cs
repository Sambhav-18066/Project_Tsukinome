using UnityEngine;

public class NPCStats : MonoBehaviour
{
    public float hunger = 100;
    public float energy = 100;

    void Update()
    {
        hunger -= Time.deltaTime * 0.5f;
        energy -= Time.deltaTime * 0.3f;

        hunger = Mathf.Clamp(hunger, 0, 100);
        energy = Mathf.Clamp(energy, 0, 100);
    }

    public bool IsHungry() => hunger < 50;
    public bool IsTired() => energy < 40;
}
