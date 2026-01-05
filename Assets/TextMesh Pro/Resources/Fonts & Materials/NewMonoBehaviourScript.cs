using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class EventUI : MonoBehaviour
{
    public GameObject panel;
    public TextMeshProUGUI eventText;
    public Button[] choiceButtons;

    void Start()
    {
        panel.SetActive(false);
    }

    public void ShowEvent(string text, string[] choices)
    {
        panel.SetActive(true);
        eventText.text = text;

        for (int i = 0; i < choiceButtons.Length; i++)
        {
            if (i < choices.Length)
            {
                choiceButtons[i].gameObject.SetActive(true);
                choiceButtons[i].GetComponentInChildren<TextMeshProUGUI>().text = choices[i];

                int index = i;
                choiceButtons[i].onClick.RemoveAllListeners();
                choiceButtons[i].onClick.AddListener(() => OnChoiceSelected(index));
            }
            else
            {
                choiceButtons[i].gameObject.SetActive(false);
            }
        }
    }

    void OnChoiceSelected(int choiceIndex)
    {
        Debug.Log("Player selected choice: " + choiceIndex);
        panel.SetActive(false);
    }
}
