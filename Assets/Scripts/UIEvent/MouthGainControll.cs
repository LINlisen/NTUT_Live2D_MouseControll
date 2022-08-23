using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Live2D.Cubism.Framework.MouthMovement;

public class MouthGainControll : MonoBehaviour
{
    public List<GameObject> modelList = new List<GameObject>();

    public Slider slider;
    
    private GameObject lastModel;

    private CubismAudioMouthInput cubismAudioMouthInput;
    private float gain;
    // Start is called before the first frame update
    void Start()
    {
        slider.onValueChanged.AddListener(delegate { ValueChangeCheck(); });
    }

    void ValueChangeCheck()
    {
        gain = slider.value * 10;
        cubismAudioMouthInput.Gain = gain;
    }
    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < modelList.Count; i++)
        {
            if (modelList[i].activeSelf == true)
            {
                if (lastModel != modelList[i])
                {
                    cubismAudioMouthInput = modelList[i].GetComponent<CubismAudioMouthInput>();
                    cubismAudioMouthInput.Gain = gain;
                    lastModel = modelList[i];
                }
            }
        }


    }
}
