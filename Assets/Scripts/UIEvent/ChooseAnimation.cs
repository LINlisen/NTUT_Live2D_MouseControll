using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChooseAnimation : MonoBehaviour
{
    public List<GameObject> modelList = new List<GameObject>();

    public Dropdown dropdown;

    private int CurrentModel = 1;

    List<string> AnimationNames = new List<string>();

    private Animator animator;

    public Toggle motiontoggle;

    public Toggle charactertoggle;

    void Start()
    {
        dropdown.onValueChanged.AddListener(delegate { dropdownValueChanged(dropdown); });
    }
    private void dropdownValueChanged(Dropdown dropdown)
    {
        if (dropdown.value != dropdown.options.FindIndex(option => option.text == animator.GetCurrentAnimatorClipInfo(0)[0].clip.name))
        {
            animator.SetTrigger(dropdown.value.ToString());
        }
    }
    private void Update()
    {
        //需要加判斷式減少進入迴圈可能
        
        for (int i = 0; i < modelList.Count; i++) 
        {
            if (modelList[i].activeSelf == true)
            {
                if (CurrentModel != i)
                {
                    dropdown.ClearOptions();
                    animator = modelList[i].GetComponent<Animator>();
                    foreach (AnimationClip animationClip in animator.runtimeAnimatorController.animationClips)
                    {
                        AnimationNames.Add(animationClip.name);
                    }
                    dropdown.AddOptions(AnimationNames);
                    AnimationNames.Clear();
                }
                CurrentModel = i;
            }
        }

        dropdown.value = dropdown.options.FindIndex(option => option.text == animator.GetCurrentAnimatorClipInfo(0)[0].clip.name);

        if (motiontoggle.isOn)
        {
            animator.SetBool("OneMotionLoop", true);
        }
        else
        {
            animator.SetBool("OneMotionLoop", false);
        }

        if (charactertoggle.isOn && motiontoggle.isOn)
        {
            if (animator.GetCurrentAnimatorClipInfo(0)[0].clip.name == animator.runtimeAnimatorController.animationClips[animator.runtimeAnimatorController.animationClips.Length - 1].name) 
            {
                animator.Play(animator.GetCurrentAnimatorClipInfo(0)[0].clip.name);
                for (int i = 0; i < modelList.Count; i++)
                {
                    if (modelList[i].activeSelf == true)
                    {
                        modelList[i].SetActive(false);
                        if (i == modelList.Count - 1)
                        {
                            i = 0;
                        }
                        else 
                        {
                            i++;
                        }
                        modelList[i].SetActive(true);
                    }
                }
            }
        }
    }
}
