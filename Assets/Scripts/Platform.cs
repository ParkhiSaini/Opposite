
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    private void CreatePlatform(Transform _Platform, int value)
    {
        if(value==0)
        {
            //Left ui 
            GlassPlatform.GetComponent<MeshRenderer>().sharedMaterial.color = new Color(Random.Range(0, 1f),Random.Range(0f, 1f),Random.Range(0f, 1f), 1f);
            CurrentPlatform=Instantiate(GlassPlatform, new Vector3(_Platform.position.x+2,-0.526f,_Platform.position.z),Quaternion.identity);
            
            Debug.Log("Left");
        }
        else if(value==1)
        {
            //Right ui
            CurrentPlatform=Instantiate(GlassPlatform, new Vector3(_Platform.position.x-2,-0.526f,_Platform.position.z),Quaternion.identity);
            ////GlassPlatform.GetComponent<MeshRenderer>().sharedMaterial.color = new Color(Random.Range(0, 1f),Random.Range(0f, 1f),Random.Range(0f, 1f), 1f);
            Debug.Log("Right");
        }
        else if(value==2)
        {
            //Down ui
            CurrentPlatform=Instantiate(GlassPlatform, new Vector3(_Platform.position.x,-0.526f,_Platform.position.z+2),Quaternion.identity);
            //GlassPlatform.GetComponent<MeshRenderer>().sharedMaterial.color = new Color(Random.Range(0, 1f),Random.Range(0f, 1f),Random.Range(0f, 1f), 1f);
            Debug.Log("Down");
        }
        else
        {
            //Up ui  
            CurrentPlatform=Instantiate(GlassPlatform, new Vector3(_Platform.position.x,-0.526f,_Platform.position.z-2),Quaternion.identity);
            //GlassPlatform.GetComponent<MeshRenderer>().sharedMaterial.color = new Color(Random.Range(0, 1f),Random.Range(0f, 1f),Random.Range(0f, 1f), 1f);
            Debug.Log("Up");
        }


    }

    private IEnumerator SpawnPlatform()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(CurrentPlatform.gameObject,0.5f);
        int value= Random.Range(0,4);
        CreatePlatform(CurrentPlatform, 0);
        StartCoroutine(SpawnPlatform());
    }

}
