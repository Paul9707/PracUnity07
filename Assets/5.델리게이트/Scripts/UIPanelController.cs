using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPanelController : MonoBehaviour
{
    public Transform PanelParent;

    public void AddPanelButtonClick()
    {
        var child = new GameObject("Image");
        child.transform.SetParent(PanelParent);
        var childImag = child.AddComponent<Image>();

        //childImag.color = Color.white;

        DayNightManager.instance.onDayComesUp +=
            (isDay) =>
            {
                childImag.color = isDay ? Color.black : Color.white;
            };
    }

}
