using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Котроллер редактирования итема
/// </summary>
public class ItemController : MonoBehaviour
{
    /// <summary>
    /// Ивент по смене итема
    /// </summary>
    public event Action<int> OnItemChanged = delegate { };

    [SerializeField]
    private string itemName = "FORM";

    [SerializeField]
    private string ColorsName = "FORM_COLOR";

    [SerializeField]
    private ItemContainer itemSO;

    [SerializeField]
    private List<Image> itemElements;

    [SerializeField]
    private List<Image> pleviewElements;

    [SerializeField]
    private List<Color> colorsPalet;

    private Image selectedImage;

    private Image previewImage;

    private int currentForm = 0;
    
    public List<Color> ColorsPalet => colorsPalet;


    /// <summary>
    /// Выбрать элемент для редактирования
    /// </summary>
    /// <param name="imageChosed"></param>
    /// <param name="viewImage"></param>
    public void ChoseImage(Image imageChosed, Image viewImage)
    {
        selectedImage = imageChosed;
        previewImage = viewImage;
    }

    /// <summary>
    /// Выбрать цвет элемента
    /// </summary>
    /// <param name="color"></param>
    public void ChoseColor(Color color)
    {
        if (CheckColor(color))
        {
            selectedImage.color = color;
            previewImage.color = color;
        }
    }

    private bool CheckColor(Color color)
    {
        for (int i = 0; i < itemElements.Count; i++)
        {
            if (itemElements[i].color == color)
            {
                return false;
            }
        }
        return true;
    }

    /// <summary>
    /// Установить рандомные цвета итема
    /// </summary>
    public void SetRandomColors()
    {
        List<Color> colors = new List<Color>(ColorsPalet);
        for (int i = 0; i < itemElements.Count; i++)
        {
            Color color = colors[UnityEngine.Random.Range(0, colors.Count)];
            itemElements[i].color = color;
            pleviewElements[i].color = color;
            colors.Remove(color);
        }
    }

    /// <summary>
    /// Сменить итем на другой
    /// </summary>
    /// <param name="isPlus"></param>
    public void NextItem(bool isPlus)
    {
        currentForm = isPlus ? currentForm + 1 : currentForm - 1;

        if (currentForm >= itemSO.Forms.Count)
        {
            currentForm = 0;
        }

        if (currentForm < 0)
        {
            currentForm = itemSO.Forms.Count - 1;
        }

        SelecteItem();
    }

    private void SelecteItem()
    {
        for (int i = 0; i < itemElements.Count; i++)
        {
            itemElements[i].sprite = itemSO.Forms[currentForm].ItemSprites[i];
        }

        OnItemChanged?.Invoke(itemSO.Forms[currentForm].CoutColoredItems);
    }

    private void LoadItem()
    {
        currentForm = PlayerPrefs.GetInt(itemName);
        SelecteItem();
        for (int i = 0; i < itemElements.Count; i++)
        {
            selectedImage = itemElements[i];
            previewImage = pleviewElements[i];

            Color colorSlot = new Color(PlayerPrefs.GetFloat(ColorsName + i + 0), PlayerPrefs.GetFloat(ColorsName + i + 1), PlayerPrefs.GetFloat(ColorsName + i + 2), PlayerPrefs.GetFloat(ColorsName + i + 3));
            ChoseColor(colorSlot);
        }
    }

    private void Awake() => LoadItem();

    private void OnDestroy() => SaveItem();

    /// <summary>
    /// Сохранить итем и его цвета
    /// </summary>
    public void SaveItem()
    {
        PlayerPrefs.SetInt(itemName, currentForm);

        for (int i = 0; i < itemElements.Count; i++)
        {
            PlayerPrefs.SetFloat(ColorsName + i + 0, itemElements[i].color.r);
            PlayerPrefs.SetFloat(ColorsName + i + 1, itemElements[i].color.g);
            PlayerPrefs.SetFloat(ColorsName + i + 2, itemElements[i].color.b);
            PlayerPrefs.SetFloat(ColorsName + i + 3, itemElements[i].color.a);
        }
    }
}
