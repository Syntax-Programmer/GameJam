using UnityEngine;

[CreateAssetMenu(menuName = "Event")]
public class EventData : ScriptableObject
{
    public string title;
    [TextArea] public string description;
    public int foodChange;
    public int goldChange;
}
