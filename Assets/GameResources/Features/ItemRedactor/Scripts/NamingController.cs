using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Контроллер выбора имени
/// </summary>
public class NamingController : MonoBehaviour
{
    [SerializeField]
    private InputField inputField;

    [SerializeField]
    private Color wrongColor;

    [SerializeField]
    private Button buttonNext;

    [SerializeField]
    private Text buttonText;

    [SerializeField]
    private int textRange;

    private void Awake()
    {
        inputField.onValueChanged.AddListener(delegate { CheckTextCount(); }) ;
    }

    private void CheckTextCount()
    {
        if(inputField.text.Length > textRange)
        {
            buttonNext.interactable = false;
            inputField.textComponent.color = wrongColor;
            buttonText.color = buttonNext.colors.disabledColor;
        }
        else
        {
            buttonNext.interactable = true;
            inputField.textComponent.color = Color.white;
            buttonText.color = Color.white;
        }
    }
}
