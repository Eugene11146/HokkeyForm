using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Тугл по смене цвета элемента
/// </summary>
[RequireComponent (typeof(Toggle))]
public class ToggleChangeImage : MonoBehaviour
{
    [SerializeField]
    private GameObject choseView;

    [SerializeField]
    private Image imageElement;

    [SerializeField]
    private Image choseImage;

    [SerializeField]
    private ItemController formController;

    private Toggle toggle;

    private void Start()
    {
        toggle = GetComponent<Toggle>();
        toggle.onValueChanged.AddListener(delegate { ChoseImage(); });
        toggle.isOn = true;
    }

    private void ChoseImage()
    {
        if (toggle.isOn)
        {
            formController.ChoseImage(imageElement, choseImage);
            choseView.SetActive(toggle.isOn);
        }
        else
        {
            choseView.SetActive(toggle.isOn);
        }
    }
}
