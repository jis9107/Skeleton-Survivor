using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIControler : MonoBehaviour
{
    public GameObject[] uiPanels;

    public void Awake()
    {

    }
    public void MoveToPanel(int panelNum)
    {
        uiPanels[panelNum].gameObject.SetActive(true);

        for(int i = 0; i < uiPanels.Length; i++)
        {
            if (i != panelNum)
            {
                uiPanels[i].gameObject.SetActive(false);
            }
        }
    }

}
