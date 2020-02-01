using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class OnClickStart : MonoBehaviour
{
    public GameObject TitleUI;


    public void RemoveTitleScreen()
    {
        if (TitleUI != null)
        {
            foreach (Transform child in TitleUI.transform)
            {
                child.gameObject.SetActive(false);
            }
        }
    }

    public void QuitButton()
    {
        Application.Quit();
    }
}
