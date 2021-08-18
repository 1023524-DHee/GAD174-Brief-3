using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TabGroup : MonoBehaviour
{
    private bool panelIsUp;
    private AudioSource audioSource;

    public List<TabButton> tabButtons;
    public List<GameObject> objectsToSwap;
    public TabButton selectedTab;
    public Animator pageAnimator;

    public AudioClip hoverClip, selectClip;

	private void Start()
	{
        PlayerControls.current.onTabButtonPressed += TogglePanel;

        audioSource = GetComponent<AudioSource>();
        panelIsUp = false;
	}

	public void Subscribe(TabButton button)
    {
        if (tabButtons == null)
        {
            tabButtons = new List<TabButton>();
        }
        tabButtons.Add(button);
    }

    public void OnTabEnter(TabButton button)
    {
        ResetTabs();
        audioSource.clip = hoverClip;
        audioSource.Play();
        if (selectedTab == null || button != selectedTab)
        {
            button.background.sprite = button.tabHover;
        }
    }

    public void OnTabExit(TabButton button)
    {
        ResetTabs();
    }

    public void OnTabSelected(TabButton button)
    {
        selectedTab = button;
        ResetTabs();
        audioSource.clip = selectClip;
        audioSource.Play();
        button.background.sprite = button.tabActive;

        int index = button.transform.GetSiblingIndex();
        for (int ii = 0; ii < objectsToSwap.Count; ii++)
        {
            if (ii == index)
            {
                objectsToSwap[ii].SetActive(true);
            }
            else
            {
                objectsToSwap[ii].SetActive(false);
            }
        }
    }

    public void ResetTabs()
    {
        foreach (TabButton button in tabButtons)
        {
            if (selectedTab != null && button == selectedTab) { continue; }
            button.background.sprite = button.tabIdle;
        }
    }

    public void TogglePanel()
    {
        panelIsUp = !panelIsUp;

        if (!panelIsUp)
        {
            pageAnimator.SetTrigger("PanelDown");
        }
        else
        {
            pageAnimator.SetTrigger("PanelUp");
        }
    }
}
