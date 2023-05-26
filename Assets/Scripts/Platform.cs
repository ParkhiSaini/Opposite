
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Platform : MonoBehaviour
{
    public Transform GlassPlatform;
    public Transform StartPlatform;
    private Transform CurrentPlatform=null;
   
    

    void Start()
    {
        CurrentPlatform=StartPlatform;
        StartCoroutine(SpawnPlatform());
    }

    void Update(){
 
    }
    private void CreatePlatform(Transform _Platform, int value)
    {
        if(value==0)
        {
            //Left ui 
            GlassPlatform.GetComponent<MeshRenderer>().sharedMaterial.color = new Color(Random.Range(0, 1f),Random.Range(0f, 1f),Random.Range(0f, 1f), 1f);
            CurrentPlatform=Instantiate(GlassPlatform, new Vector3(_Platform.position.x+2,-0.526f,_Platform.position.z),Quaternion.identity);
          
            //Debug.Log("Left");
        }
        else if(value==1)
        {
            //Right ui
            GlassPlatform.GetComponent<MeshRenderer>().sharedMaterial.color = new Color(Random.Range(0, 1f),Random.Range(0f, 1f),Random.Range(0f, 1f), 1f);
            CurrentPlatform=Instantiate(GlassPlatform, new Vector3(_Platform.position.x-2,-0.526f,_Platform.position.z),Quaternion.identity);
            ////GlassPlatform.GetComponent<MeshRenderer>().sharedMaterial.color = new Color(Random.Range(0, 1f),Random.Range(0f, 1f),Random.Range(0f, 1f), 1f);
          
        }
        else if(value==2)
        {
            //Down ui
            GlassPlatform.GetComponent<MeshRenderer>().sharedMaterial.color = new Color(Random.Range(0, 1f),Random.Range(0f, 1f),Random.Range(0f, 1f), 1f);
            CurrentPlatform=Instantiate(GlassPlatform, new Vector3(_Platform.position.x,-0.526f,_Platform.position.z+2),Quaternion.identity);
            //GlassPlatform.GetComponent<MeshRenderer>().sharedMaterial.color = new Color(Random.Range(0, 1f),Random.Range(0f, 1f),Random.Range(0f, 1f), 1f);
         
        }
        else
        {
            //Up ui 
            GlassPlatform.GetComponent<MeshRenderer>().sharedMaterial.color = new Color(Random.Range(0, 1f),Random.Range(0f, 1f),Random.Range(0f, 1f), 1f); 
            CurrentPlatform=Instantiate(GlassPlatform, new Vector3(_Platform.position.x,-0.526f,_Platform.position.z-2),Quaternion.identity);
            //GlassPlatform.GetComponent<MeshRenderer>().sharedMaterial.color = new Color(Random.Range(0, 1f),Random.Range(0f, 1f),Random.Range(0f, 1f), 1f);
            
        }


    }

    private IEnumerator SpawnPlatform()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(CurrentPlatform.gameObject,0.5f);
        int value= Random.Range(0,4);
        // TextDisplay(value);
        CreatePlatform(CurrentPlatform, value);
        StartCoroutine(SpawnPlatform());
    }

    // private void TextDisplay(value){
    //     if (value==0){
    //         directionUI.text="LEFT";
    //     }
    //     else if (value==1){
    //         directionUI.text="RIGHT";
    //     }
    //     else if (value==2){
    //         directionUI.text="DOWN";
    //     } 
    //     else if (value==3){
    //         directionUI.text="UP";
    //     }

    // }



}
