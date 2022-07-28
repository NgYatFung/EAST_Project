using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TentTopSocket : MonoBehaviour
{
    public Color transparentColor;

    public Color WrongColor;
    public Material SetSnappedMat;
    public bool x = false;
    Material mat;
    public UnityEvent onTigger;


    //bool IsHighLighted = false;
    // Start is called before the first frame update
    void Start()
    {
        mat = GetComponent<Renderer>().material;
    }

    private void OnTriggerEnter(Collider other)
    {
        CubeController cc = other.GetComponent<CubeController>();
        if (cc != null && other.gameObject.tag == "TentTop")
        {
            onTigger.Invoke();
            GetComponent<MeshRenderer>().material = SetSnappedMat;
            cc.SetSocketPos(true, transform.position);
        }
        else if(other.gameObject.tag == "Terrain" || other.gameObject.tag == "Player" || other.gameObject.tag == "Untagged")
        {
            SetNormalLightedColor();
        }
        else
        {
            SetWrongColor();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        CubeController cc = other.GetComponent<CubeController>();
        if (cc != null)
        {
            SetNormalLightedColor();
            cc.SetSocketPos(false);

        }
    }

    /*
    void SetHighLightedColor()
    {
        mat.color = HighlightedColor;
    }
    */
    void SetNormalLightedColor()
    {
        mat.color = transparentColor;
    }
    void SetWrongColor()
    {
        mat.color = WrongColor;
    }


    /* void Checking()
     {
         if (x == true)
         {
             SetWrongColor();
         }
     } 

    */
    // Update is called once per frame
    void Update()
    { /*
        if(Input.GetKeyDown(KeyCode.Space))
        {
            IsHighLighted = !IsHighLighted;

            if(IsHighLighted)
            {
                mat.color = HighlightedColor;
            } 
            else
            {
                mat.color = transparentColor;
            }
        } */
    }
}
