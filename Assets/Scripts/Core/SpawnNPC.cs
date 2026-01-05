using UnityEngine;

public enum NPCType
{
    Poor,
    Merchant,
    Guard,
    Noble
}


public struct NPCDeltaAttr
{
    public NPCType Type;
    public int wealth;
    public int repo;
    public int food;
}

public class SpawnNPC : MonoBehaviour
{
    public Player player;
    public float despawnX = -15f;

    private NPCDeltaAttr npcData;

    public void Init(NPCDeltaAttr data)
    {
        npcData = data;
        Debug.Log($"Spawned {npcData.Type} | Wealth:{npcData.wealth}");
    }

    void Update()
    {
        MoveNPC(player.MovementInput);

        if (transform.position.x < despawnX)
        {
            Destroy(gameObject);
        }
    }

    void MoveNPC(Vector3 vel)
    {
        transform.position -= vel;
    }
}
