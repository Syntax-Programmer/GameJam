using System;
using UnityEngine;

public enum NPCType
{

};

public struct NPCDeltaAttr
{
    public NPCType Type;
    public int wealth;
    public int repo;
    public int food;
}

public class SpawnNPC : MonoBehaviour
{
    
    void Start(NPCType type)
    {
        
    }

    void Update()
    {
        
    }

}
