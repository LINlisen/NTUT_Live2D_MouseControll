using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightClickModel : MonoBehaviour
{
    public GameObject UI;
    private void OnMouseOver()
    {

        if (Input.GetMouseButtonDown(1))
        {
            if (UI.activeSelf == false)
            {
                UI.SetActive(true);
            }
            else 
            {
                UI.SetActive(false);
            }
        }

    }
}
