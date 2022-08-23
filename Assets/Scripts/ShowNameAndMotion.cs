using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowNameAndMotion : MonoBehaviour
{
    Animator animator;
    string m_ClipName;
    AnimatorClipInfo[] m_CurrentClipInfo;

    private GUIStyle guiStyleFore;
    private GUIStyle guiStyleBack;
    private string GUItext = "";


    private void OnMouseOver()
    {
        GUItext = m_ClipName;
    }

    private void OnMouseExit()
    {
        GUItext = "";
    }

    private void OnGUI()
    {
        if (GUItext != "")
        {
            var x = Event.current.mousePosition.x;
            var y = Event.current.mousePosition.y;
            GUI.Label(new Rect (x - 149, y + 40, 300, 60), GUItext, guiStyleBack);
            GUI.Label(new Rect (x - 150, y + 40, 300, 60), GUItext, guiStyleFore);
        }
    }


    private void Start()
    {
        animator = gameObject.GetComponent<Animator>();

        guiStyleFore = new GUIStyle();
        guiStyleFore.normal.textColor = Color.white;
        guiStyleFore.alignment = TextAnchor.UpperCenter;
        guiStyleFore.wordWrap = true;
        guiStyleBack = new GUIStyle();
        guiStyleBack.normal.textColor = Color.black;
        guiStyleBack.alignment = TextAnchor.UpperCenter;
        guiStyleBack.wordWrap = true;
    }
    private void Update()
    {
        m_CurrentClipInfo = this.animator.GetCurrentAnimatorClipInfo(0);
        m_ClipName = this.name + "\n" + m_CurrentClipInfo[0].clip.name;
    }
}
