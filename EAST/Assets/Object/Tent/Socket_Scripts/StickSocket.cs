using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StickSocket : MonoBehaviour
{
    public Color transparentColor;
    public Color WrongColor;
    [Header("Put the tent material in here")]
    public Material SetSnappedMat;
    [Header("Put child in here")]
    [SerializeField] private GameObject turnOff;
    Material mat;
    [Header("Put next socket set in here")]
    [SerializeField] private GameObject nextSoc;
    public UnityEvent onTigger;
    public AudioSource audioData;
    public GameObject middel;
    public GameObject standup;
    //bool IsHighLighted = false;
    // Start is called before the first frame update
    void Start()
    {
        mat = GetComponent<Renderer>().material;
    }


    public class counter
    {
        public static int x = 0;
    }
    private void OnTriggerEnter(Collider other)
    {
        CubeController cc = other.GetComponent<CubeController>();
        if (cc != null && other.gameObject.tag == "TentStick")
        {
            counter.x++;
            onTigger.Invoke();
            GetComponent<MeshRenderer>().material = SetSnappedMat;
            cc.SetSocketPos(true, transform.position);
            turnOff.SetActive(false);
            audioData.Play();
        }
        else if (other.gameObject.tag == "Terrain" || other.gameObject.tag == "Player" || other.gameObject.tag == "Untagged")
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
    {
        if (counter.x >= 4)
        {
            nextSoc.SetActive(true);
            middel.SetActive(false);
            standup.SetActive(true);
        }
        /*
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

