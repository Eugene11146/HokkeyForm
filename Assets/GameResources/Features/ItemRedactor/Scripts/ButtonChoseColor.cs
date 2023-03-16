using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/// <summary>
/// ����� ������ ����������� ����� �����
/// </summary>
[RequireComponent(typeof(Button))]
public class ButtonChoseColor : MonoBehaviour
{
    [SerializeField]
    private Image imageView;

    private ItemController formController;

    private Button button;

    private void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(ChoseColor);
    }
    
    /// <summary>
    /// ������ ���� ������
    /// </summary>
    /// <param name="color"></param>
    /// <param name="controller"></param>
    public void SetColor(Color color, ItemController controller)
    {
        imageView.color = color;
        formController = controller;
    }

    private void ChoseColor() => formController.ChoseColor(imageView.color);
}
