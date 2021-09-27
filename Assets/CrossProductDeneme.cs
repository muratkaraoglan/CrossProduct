using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
public class CrossProductDeneme : MonoBehaviour
{
    public Transform objTransform;


    private void OnDrawGizmos()
    {
        Vector3 myPosition = transform.position;
        Vector3 lookDir = transform.forward;

        void DrawRay(Vector3 p, Vector3 dir) => Handles.DrawAAPolyLine(EditorGUIUtility.whiteTexture,3,p, p + dir);

        if ( Physics.Raycast(transform.position, transform.forward, out RaycastHit hit) )
        {
            Vector3 hitPoint = hit.point;

            Vector3 up = hit.normal;
            Vector3 right = Vector3.Cross(up,lookDir).normalized;
            Vector3 forward = Vector3.Cross(right, up);


            Handles.color = Color.white;
            Handles.DrawAAPolyLine(myPosition, hitPoint);

            //UP
            Handles.color = Color.green;
            DrawRay(hitPoint, up);

            //RİGHT
            Handles.color = Color.red;
            DrawRay(hitPoint, right);

            //FORWARD
            Handles.color = Color.cyan;
            DrawRay(hitPoint, forward);
        }
        else
        {
            Handles.color = Color.red;
            DrawRay(myPosition, lookDir);
        }
    }
}
