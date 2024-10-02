using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static ButtonImage;

public class ButtonImage : MonoBehaviour
{
    [SerializeField] private List<ButtonimageItem> switchableItems;
    private void Awake()
    {
        for (int i = 0; i < switchableItems.Count; i++)
        {
            int swetchId = i;
            switchableItems[i].swichButton.onClick.AddListener(() => SwitchIcon(swetchId));
        }
        
    }

    private void SwitchIcon(int switchId)
    {
        Debug.Log($"Switch {switchId}");
        for (int i = 0; i < switchableItems.Count; i++)
        {
            switchableItems[i].icon.gameObject.SetActive(i == switchId);
        }
    }
}

[Serializable]
public class ButtonimageItem
{
    [field: SerializeField] public Button swichButton { get; private set; }
    [field: SerializeField] public Image icon { get; private set; }
}
