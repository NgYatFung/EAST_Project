using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryGameObject : MonoBehaviour
{


    public GameObject gameObject;


    public void OnDestroy()
    {
        Destroy(gameObject);
    }
}
