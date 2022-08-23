using Live2D.Cubism.Framework.LookAt;
using UnityEngine;

public class CubismLookTarget : MonoBehaviour, ICubismLookTarget
{
    public Vector3 GetPosition()
    {
        var targetPosition = Input.mousePosition;
        targetPosition = ((Camera.main.ScreenToWorldPoint(targetPosition)*2) - new Vector3(0.0f, 0.9f, 0.0f));
        return targetPosition;
    }


    public bool IsActive()
    {
        return true;
    }
}