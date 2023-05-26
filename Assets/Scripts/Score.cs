using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;

public class Score : MonoBehaviour
{

    public bool isOnGround=true;
    public bool gameover=false;
    public int score=0;
    public TextMeshProUGUI scoreUI;


    // Start is called before the first frame update
    void Start()
    {

        
    }

    // Update is called once per frame
    void Update()
    {
        scoreUI.text=score.ToString();        
    }

    private void OnCollisionEnter(Collision collision){
        if(collision.gameObject.CompareTag("Ground")){
            score++;

        }
    }
    private void OnCollisionExit(Collision collision){
        gameover=true;
        Debug.Log("Game over");
    }
}
