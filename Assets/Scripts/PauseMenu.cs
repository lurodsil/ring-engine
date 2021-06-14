using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public Text[] menuItems;
    public int index;

    void OnEnable()
    {
        index = 0;
        UpdateColors();
    }

    void Update()
    {
        if (Input.GetButtonDown(XboxButton.DPadDown))
        {
            if (index < menuItems.Length - 1)
            {
                index++;
            }
            else
            {
                index = 0;
            }

            UpdateColors();
        }
        else if (Input.GetButtonDown(XboxButton.DPadUp))
        {
            if (index > 0)
            {
                index--;
            }
            else
            {
                index = menuItems.Length - 1;
            }
            UpdateColors();
        }
    }

    void UpdateColors()
    {
        for (int i = 0; i < menuItems.Length; i++)
        {
            if (i == index)
            {
                menuItems[i].color = Color.yellow;
            }
            else
            {
                menuItems[i].color = Color.white;
            }
        }
    }
}
