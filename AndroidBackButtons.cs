using UnityEngine;

public class GameManager : MonoBehaviour
{
    private void AndroidBackOrEscapeButton()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                //Do Stuffs ..
            }
        }
    }
}
