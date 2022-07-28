using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    Vector3 posOffset;
    float distance;

    bool IsInSocket = false;
    Vector3 SocketPos;
    private void OnMouseDown()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        Physics.Raycast(ray, out hit);

        posOffset = transform.position - hit.point;
        distance = hit.distance;
    }

    private void OnMouseUp()
    {
        if(IsInSocket)
        {
            transform.position = SocketPos;
        }
    }
    private void OnMouseDrag()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Vector3 newCubePos = ray.GetPoint(distance);
        newCubePos += posOffset;

        transform.position = newCubePos;
    }

    public void SetSocketPos(bool IsInSocket)
    {
        this.IsInSocket = IsInSocket;
        
    }

    public void SetSocketPos(bool IsInSocket, Vector3 SocketPos)
    {
        SetSocketPos(IsInSocket);
        this.SocketPos = SocketPos;
        Destroy(gameObject);
    }
}
