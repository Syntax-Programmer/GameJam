using UnityEngine;

public class NPCSpawner : MonoBehaviour
{
    public GameObject NPCPrefab;
    public Player player;

    public int maxNPCs = 1;   // hard safety limit

    private int currentNPCs;

    void Update()
    {
        float movement = player.MovementInput.x;

        if (movement == 0)
            return;

        if (currentNPCs < maxNPCs)
        {
            Spawn();
        }
    }

    void Spawn()
    {
        Vector3 spawnPos = new Vector3(
            Random.Range(18f, 22f),
            Random.Range(2.5f, 2.8f),
            0f
        );

        GameObject npcGO = Instantiate(NPCPrefab, spawnPos, Quaternion.identity);
        SpawnNPC npc = npcGO.GetComponent<SpawnNPC>();

        npc.player = player;
        npc.Init(GenerateRandomNPC());

        currentNPCs++;

        npcGO.AddComponent<OnDestroyCallback>().onDestroy += () =>
        {
            currentNPCs--;
        };
    }

    NPCDeltaAttr GenerateRandomNPC()
    {
        NPCType type = (NPCType)Random.Range(
            0, System.Enum.GetValues(typeof(NPCType)).Length);

        NPCDeltaAttr data = new NPCDeltaAttr { Type = type };

        switch (type)
        {
            case NPCType.Poor:
                data.wealth = Random.Range(0, 10);
                data.repo = Random.Range(0, 30);
                data.food = Random.Range(0, 20);
                break;

            case NPCType.Merchant:
                data.wealth = Random.Range(30, 80);
                data.repo = Random.Range(40, 70);
                data.food = Random.Range(20, 40);
                break;

            case NPCType.Guard:
                data.wealth = Random.Range(20, 40);
                data.repo = Random.Range(60, 90);
                data.food = Random.Range(30, 50);
                break;

            case NPCType.Noble:
                data.wealth = Random.Range(80, 150);
                data.repo = Random.Range(70, 100);
                data.food = Random.Range(40, 70);
                break;
        }

        return data;
    }
}
