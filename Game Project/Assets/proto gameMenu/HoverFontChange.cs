using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class HoverFontChange : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("OnPointerEnter Called");

        gameObject.GetComponentInChildren<TMP_Text>().font = Resources.Load<TMP_FontAsset>("8-bit Arcade Out");
        //gameObject.GetComponent<TMP_Text>().font = Resources.Load<TMP_FontAsset>("8-bit Arcade Out");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("OnPointerExit Called");
        gameObject.GetComponentInChildren<TMP_Text>().font = Resources.Load<TMP_FontAsset>("8-bit Arcade In");
        //gameObject.GetComponent<TMP_Text>().font = Resources.Load<TMP_FontAsset>("8-bit Arcade In");
    }
}
