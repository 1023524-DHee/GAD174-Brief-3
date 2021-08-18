using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenTab : MonoBehaviour
{
    private bool panelIsUp;

    // Start is called before the first frame update
    void Start()
    {
        panelIsUp = false;
    }

    public void TogglePanel()
    {
        panelIsUp = !panelIsUp;

        if (!panelIsUp)
        {
            GetComponent<Animator>().SetTrigger("PanelDown");
        }
        else
        {
            GetComponent<Animator>().SetTrigger("PanelUp");
        }
    }
}
