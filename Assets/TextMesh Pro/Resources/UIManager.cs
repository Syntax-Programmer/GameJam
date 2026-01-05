using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject menuPanel;

    void Start()
    {
        menuPanel.SetActive(false);
    }

    public void ShowMenu()
    {
        menuPanel.SetActive(true);
    }

    public void HideMenu()
    {
        menuPanel.SetActive(false);
    }
}
