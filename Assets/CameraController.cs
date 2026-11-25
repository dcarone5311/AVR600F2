using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public float maxDist, minDist, scrollSpeed, smooth, vertSpeed,  maxAngle, minAngle;
    
    
    
    float currentDistance, targetDistance;


    // Start is called before the first frame update
    void Start()
    {
        targetDistance = currentDistance = transform.position.magnitude; //distance from origin
    }

    // Update is called once per frame
    void LateUpdate()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");

        targetDistance = Mathf.Clamp(targetDistance + scroll * scrollSpeed * Time.deltaTime, minDist, maxDist);

        float vertMove = Input.GetMouseButton(1) ? Input.GetAxis("Mouse Y") : 0; //if right clicking

        transform.Rotate(Vector3.right * vertMove * vertSpeed * Time.deltaTime);
        
        float vertAngle = transform.eulerAngles.x;
        Debug.Log(vertAngle);
        vertAngle = Mathf.Clamp(vertAngle > 90 ? vertAngle - 360f: vertAngle, minAngle, maxAngle);
        transform.localRotation = Quaternion.Euler(vertAngle, 0, 0);



        currentDistance = Mathf.Lerp(currentDistance, targetDistance, smooth * Time.deltaTime);

        transform.localPosition = -transform.parent.InverseTransformVector(transform.forward) * currentDistance;


    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawLine(transform.position, transform.parent.position);



    }


}
