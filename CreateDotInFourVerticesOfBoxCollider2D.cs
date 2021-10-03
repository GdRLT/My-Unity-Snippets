using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateDotInFourVerticesOfBoxCollider2D : MonoBehaviour
{
    public GameObject cornerDot;

    private void Start()
    {
        BoxCollider2D collider = (BoxCollider2D)gameObject.GetComponent<Collider2D>();

        float top = collider.offset.y + (collider.size.y / 2f);
        float btm = collider.offset.y - (collider.size.y / 2f);
        float left = collider.offset.x - (collider.size.x / 2f);
        float right = collider.offset.x + (collider.size.x / 2f);

        Vector3 topLeft = transform.TransformPoint(new Vector3(left, top, 0f));
        Vector3 topRight = transform.TransformPoint(new Vector3(right, top, 0f));
        Vector3 btmLeft = transform.TransformPoint(new Vector3(left, btm, 0f));
        Vector3 btmRight = transform.TransformPoint(new Vector3(right, btm, 0f));

        Instantiate(cornerDot, topLeft, Quaternion.identity, gameObject.transform);
        Instantiate(cornerDot, topRight, Quaternion.identity, gameObject.transform);
        Instantiate(cornerDot, btmLeft, Quaternion.identity, gameObject.transform);
        Instantiate(cornerDot, btmRight, Quaternion.identity, gameObject.transform);
    }
}