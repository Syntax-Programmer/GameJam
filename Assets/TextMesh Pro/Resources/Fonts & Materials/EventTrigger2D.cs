using UnityEngine;

public class EventTrigger2D : MonoBehaviour
{
    public EventUI eventUI;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            string eventText = "A wounded traveler asks for food.";
            string[] choices = { "Help", "Ignore", "Rob" };

            eventUI.ShowEvent(eventText, choices);
        }
    }
}
