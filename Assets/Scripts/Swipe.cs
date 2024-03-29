using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swipe : MonoBehaviour
{
    private bool tap, swipeLeft, swipeRight, swipeUp, swipeDown;
    private bool isDragging = false;
    private Vector2 startTouch, swipeDelta;

    public void Update(){
        tap = swipeLeft = swipeRight = swipeDown = swipeUp = false;

        #region Standalone Inputs
        if(Input.GetMouseButtonDown(0))
        {
            tap = true;
            isDragging = true;
            startTouch = Input.mousePosition;
        }
        else if(Input.GetMouseButtonUp(0))
        {
            isDragging = false;
            Reset();
        }
        #endregion

        #region Mobile Inputs
        if(Input.touches.Length > 0){
            if(Input.touches[0].phase == TouchPhase.Began){
                tap = true;
                isDragging = true;
                startTouch = Input.touches[0].position;
            }
            else if(Input.GetTouch(0).phase == TouchPhase.Ended || Input.GetTouch(0).phase == TouchPhase.Canceled){
            isDragging = false;
            Reset();
            }
        }
        #endregion

        swipeDelta = Vector2.zero;
        if(isDragging){
            if(Input.touches.Length > 0){
                swipeDelta = Input.touches[0].position - startTouch;
            }
            else if(Input.GetMouseButton(0)){
                swipeDelta = (Vector2)Input.mousePosition - startTouch;
            }
        }
        if(swipeDelta.magnitude > 125){
            float x = swipeDelta.x;
            float y = swipeDelta.y;

            if(Mathf.Abs(x)>Mathf.Abs(y)){
                if(x < 0){
                    swipeRight = true;
                }
                else{
                    swipeLeft = true;
                }
            }
            else{
                if(y < 0){
                    swipeUp= true;
                }
                else{
                    swipeDown = true;
                }
            }
            Reset();
        }
    } 
    public void Reset(){
        startTouch = swipeDelta = Vector2.zero;
        isDragging = false;
    }

    public Vector2 SwipeDelta{ get { return swipeDelta; }}
    public bool SwipeLeft{ get { return swipeLeft; }}
    public bool SwipeRight{ get { return swipeRight; }}
    public bool SwipeDown{ get { return swipeDown; }}
    public bool SwipeUp{ get { return swipeUp; }}

}