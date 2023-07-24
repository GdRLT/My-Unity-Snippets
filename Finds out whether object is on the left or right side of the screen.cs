using UnityEngine;
using System.Collections;

public class ExampleClass : MonoBehaviour
{
    public Transform target;
    Camera cam;

    void Start()
    {
        cam = GetComponent<Camera>();
    }

    void Update()
    {
        Vector3 viewPos = cam.WorldToViewportPoint(target.position);
        if (viewPos.x > 0.5F)
            print("target is on the right side!");
        else
            print("target is on the left side!");
    }
}
