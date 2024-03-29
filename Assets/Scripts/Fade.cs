using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fade : MonoBehaviour
{
    private bool fadeOut;
    public float fadeSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Color objectColor=this.GetComponent<Renderer>().material.color;
        float fadeAmount=objectColor.a -(fadeSpeed *Time.deltaTime);

        objectColor= new Color(objectColor.r, objectColor.g, objectColor.b,fadeAmount);
        this.GetComponent<Renderer>().material.color=objectColor;

        if(objectColor.a <=0)
        {
            fadeOut=false;
        }
        
    }
}
