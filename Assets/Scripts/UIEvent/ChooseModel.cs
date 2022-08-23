using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChooseModel : MonoBehaviour
{
    public List<GameObject> modelList = new List<GameObject>();
    List<string> modelNames = new List<string>();

    public Dropdown dropdown;

    void Start()
    {
        AddModelIntoList();

        DropdownEvent();

        SetModelActive(0);
    }

    private void dropdownValueChanged(Dropdown dropdown) 
    {
        SetModelActive(dropdown.value);
    }

    private void SetModelActive(int modelNumber)
    {
        foreach (GameObject model in modelList)
        {
            model.SetActive(false);
        }
        modelList[modelNumber].SetActive(true);
    }

    private void DropdownEvent()
    {
        dropdown.onValueChanged.AddListener(delegate { dropdownValueChanged(dropdown); });
        dropdown.ClearOptions();
        dropdown.AddOptions(modelNames);
    }

    private void AddModelIntoList()
    {
        foreach (GameObject model in modelList)
        {
            modelNames.Add(model.name);
        }
    }

    private void Update()
    {
        //renew dropdown value while model autochange
        for (int i = 0; i < modelList.Count; i++)
        {
            if (modelList[i].activeSelf == true)
            {
                dropdown.value = i;
            }
        }
    }
}
