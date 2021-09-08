using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckGameObjectInCamraView : MonoBehaviour
{
    public GameObject target;

    void Update()
    {
        Vector3 screenPoint = Camera.main.WorldToViewportPoint(target.transform.position);

        bool onScreen = screenPoint.z > 0 && screenPoint.x > 0 && screenPoint.x < 1 && screenPoint.y > 0 && screenPoint.y < 1;

        if (onScreen)
            print("target inside of the Screen");
        else
            print("target outside of the Screen");
    }
}
