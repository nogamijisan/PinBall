using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FripperController : MonoBehaviour
{


    private HingeJoint myHingeJoint;

    private float defaultAngle = 20;
    private float flickAngle = -20;

    //Touch touch0;
    //Touch touch1;


    // Start is called before the first frame update
    void Start()
    {
        this.myHingeJoint = GetComponent<HingeJoint>();
        SetAngle(this.defaultAngle);
    }

    // Update is called once per frame
    void Update()
    {
        //touch0 = Input.GetTouch(0);
        //touch1 = Input.GetTouch(1);

        bool leftTouchDown = false; 
        bool rightTouchDown = false; 

        bool leftTouchUp = false; 
        bool rightTouchUp = false; 

        foreach (Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began)
            {
                if (touch.position.x < 540)
                {
                    leftTouchDown = true; 
                }
                else if(touch.position.x >= 540)
                {
                    rightTouchDown = true; 
                }
            }
            if (touch.phase == TouchPhase.Ended)
            {
                if (touch.position.x < 540)
                {
                    leftTouchUp = true; 
                }
                else if (touch.position.x >= 540)
                {
                    rightTouchUp = true; 
                }
            }
        }


        if ((Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A)
            || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)
            || leftTouchDown)
            && tag == "LeftFripperTag")
        {
            SetAngle(this.flickAngle);
        }
        if ((Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D)
            || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)
            || rightTouchDown)
            && tag == "RightFripperTag")
        {
            SetAngle(this.flickAngle);
        }
        if((Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.A)
            || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.DownArrow)
            || leftTouchUp)
            && tag == "LeftFripperTag")
        {
            SetAngle(this.defaultAngle);
        }
        if ((Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.D)
            || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.DownArrow)
            || rightTouchUp)
            && tag == "RightFripperTag")
        {
            SetAngle(this.defaultAngle);
        }

    }

    public void SetAngle(float angle)
    {
        JointSpring jointSpr = this.myHingeJoint.spring;
        jointSpr.targetPosition = angle;
        this.myHingeJoint.spring = jointSpr;
    }

}
