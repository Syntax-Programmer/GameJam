using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class EventManager : MonoBehaviour
{
    public static EventManager Instance;

    public GameObject eventPanel;
    public Text titleText;
    public Text descText;

    public List<EventData> events;

    void Awake()
    {
        Instance = this;
        eventPanel.SetActive(false);
    }

    public void TriggerEvent()
    {
        EventData e = events[Random.Range(0, events.Count)];

        titleText.text = e.title;
        descText.text = e.description;

        GameManager.Instance.player.ChangeStats(e.foodChange, e.goldChange);
        eventPanel.SetActive(true);
    }

    public void CloseEvent()
    {
        eventPanel.SetActive(false);
    }
}
