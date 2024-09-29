using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class Aim : MonoBehaviour
{
    private Vector3 distance;
    void Update()
    {
        HorizontalMove();
    }

    public void HorizontalMove()
    {
        if(Input.touchCount != 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            distance = Input.GetTouch(0).deltaPosition / Screen.width;
            transform.position += distance;
        }
    }
}
