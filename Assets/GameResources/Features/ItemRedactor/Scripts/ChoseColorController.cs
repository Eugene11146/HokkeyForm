using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Контроллер-спавнер кнопок выбора цвета
/// </summary>
public class ChoseColorController : MonoBehaviour
{
    [SerializeField]
    private ButtonChoseColor choseColorButton;

    [SerializeField]
    private Button randomColorButton;

    [SerializeField]
    private Transform transformSpawn;

    [SerializeField]
    private ItemController formController;

    private List<Color> colors;

    private void Start()
    {
        colors = formController.ColorsPalet;
        for (int i = 0; i < colors.Count; i++)
        {
            Instantiate(choseColorButton, transformSpawn).SetColor(colors[i], formController);
        }

        randomColorButton.onClick.AddListener(ShowRandomColor);
    }

    private void ShowRandomColor()
    {
        formController.SetRandomColors();
    }
}
