using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[DisallowMultipleComponent]
public class IsUsable : MonoBehaviour
{
    public string displayText;
    public bool canBeUsedNow = false;
    private TextMeshProUGUI nameTag;
    


    void Start()
    {
         nameTag = GameObject.FindGameObjectWithTag("NameTag").GetComponent<TextMeshProUGUI>();
    }

    public void ShowName()
    {
        nameTag.SetText(displayText);

    }

}
