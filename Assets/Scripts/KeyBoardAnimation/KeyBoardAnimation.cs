using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyBoardAnimation : MonoBehaviour
{
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    void OnGUI()
    {
        if (Event.current.isKey && Event.current.type == EventType.KeyDown)
        {
            Debug.Log(Event.current.keyCode);
            animator.SetTrigger(Event.current.keyCode.ToString());
        }
    }
}
