using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor (typeof (AI_Vision))]
public class AI_FOVEditor : Editor
{
    private void OnSceneGUI()
    {
        AI_Vision fov = (AI_Vision)target;
        Handles.color = Color.red;
        Handles.DrawWireArc(fov.transform.position, Vector3.up, Vector3.forward, 360, fov.viewRadius);
        Vector3 viewAngleA = fov.dirFromAngle(-fov.viewAngle / 2, false);
        Vector3 viewAngleB = fov.dirFromAngle(fov.viewAngle / 2, false);

        Handles.DrawLine(fov.transform.position, fov.transform.position + viewAngleA * fov.viewRadius);
        Handles.DrawLine(fov.transform.position, fov.transform.position + viewAngleB * fov.viewRadius);


        Handles.color = Color.blue;
        foreach (Transform visibleTargets in fov.visibleTargets)
        {
            Handles.DrawLine(fov.transform.position, visibleTargets.position);
        }
    }
}
