using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int food = 10;
    public int gold = 5;

    public void ChangeStats(int foodChange, int goldChange)
    {
        food += foodChange;
        gold += goldChange;

        if (food <= 0)
        {
            GameManager.Instance.GameOver("Your caravan starved on the road.");
        }
    }
}
