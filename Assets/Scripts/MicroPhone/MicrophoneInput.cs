using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MicrophoneInput: MonoBehaviour
{
    private List<string> microphoneDevices;

    public Dropdown dropdown;
    public Toggle toggle;

    private AudioSource audioSource;

    void Start()
    {
        GetAudioSource();
        GetAllDevicesName();
        DropdownInit();
        ToggleInit();
    }

    void GetAudioSource() 
    {
        audioSource = GetComponent<AudioSource>();
    }

    void GetAllDevicesName()
    {
        microphoneDevices = new List<string>();
        foreach (var device in Microphone.devices)
        {
            //Debug.Log("Name: " + device);
            microphoneDevices.Add(device);
        }
    }

    void DropdownInit() 
    {
        dropdown.ClearOptions();
        dropdown.AddOptions(microphoneDevices);

        //start using default microphone
        UpdateMicrophone(0);

        //change microphone device
        dropdown.onValueChanged.AddListener(delegate {
            DropdownValueChanged(dropdown);
        });
    }

    void DropdownValueChanged(Dropdown dropdown)
    {
        //Debug.Log(dropdown.value);
        UpdateMicrophone(dropdown.value);
    }

    void ToggleInit()
    {
        toggle.onValueChanged.AddListener(delegate
        {
            TogggleValueChanged(toggle);
        });
    }

    void TogggleValueChanged(Toggle toggle)
    {
        if (toggle.isOn)
        {
            audioSource.mute = false;
        }
        else
        {
            audioSource.mute = true;
        }
    }

    private void UpdateMicrophone(int dropdownValue)
    {
        audioSource.Stop();
        audioSource.clip = Microphone.Start(microphoneDevices[dropdownValue], true, 10, 44100);
        audioSource.loop = true;
        if (Microphone.IsRecording(microphoneDevices[dropdownValue]))
        { 
            while (!(Microphone.GetPosition(microphoneDevices[dropdownValue]) > 0))
            {
            } 
            audioSource.Play();
        }
        else
        {
        }
    }
}
