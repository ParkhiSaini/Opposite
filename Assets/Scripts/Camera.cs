using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform FollowObject;
    public Vector3 offset;


    private void  LateUpdate(){
        if(FollowObject!=null){
            transform.position= Vector3.Lerp(transform.position,FollowObject.position+ offset,Time.deltaTime*3f);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
