using UnityEngine;
using UnityEngine.UI;

public class ClickOutsideGUIElement : MonoBehaviour
{
    public Image optionPanel;

    private void Update()
    {
        HideIfClickedOutside(optionPanel);
    }
    private void HideIfClickedOutside(Image panel)
    {
        if (Input.GetMouseButton(0)
            && panel.IsActive()
            && !RectTransformUtility.RectangleContainsScreenPoint(panel.GetComponent<RectTransform>(), Input.mousePosition))
        {
            //Do Something
        }
    }
}
