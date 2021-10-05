using UnityEngine;
using System.Linq;

public class FindNearestGameObject : MonoBehaviour
{
    /// <summary>
    /// return Nearest Game Object (Change Object Type to a Type You Looking For)
    /// </summary>
    /// <returns></returns>
    GameObject FindNearest2D()
    {
        return FindObjectsOfType<GameObject>()
            .OrderBy(gameObject => Vector2.Distance(transform.position, gameObject.transform.position))
            .FirstOrDefault().gameObject;
    }
}
