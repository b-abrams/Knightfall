using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorldMapWindow : GenericWindow
{

    public Button selectButton;

    public override void Open()
    {
        var canSelect = true;

        selectButton.gameObject.SetActive(canSelect);
        if (selectButton.gameObject.activeSelf)
        {
            firstSelected = selectButton.gameObject;
        }

        base.Open();
    }

    public void NewGame()
    {
        OnNextWindow();
    }

    public void Continue()
    {
        Debug.Log("Continue Pressed");
    }

    public void Options()
    {
        Debug.Log("Options Pressed");
    }



}
