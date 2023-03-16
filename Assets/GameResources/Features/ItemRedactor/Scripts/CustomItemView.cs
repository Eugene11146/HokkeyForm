using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/// <summary>
/// ¬ьюшка установленной ранее итема
/// </summary>
public class CustomItemView : MonoBehaviour
{
    [SerializeField]
    private string CURRENT_FORM = "CURRENT_FORM";

    [SerializeField]
    private string COLOR = "COLOR";

    [SerializeField]
    private ItemContainer itemSO;

    [SerializeField]
    private List<Image> items;

    private void Start()
    {
        int idForm = PlayerPrefs.GetInt(CURRENT_FORM);

        for (int i = 0; i < items.Count; i++)
        {
            items[i].sprite = itemSO.Forms[idForm].ItemSprites[i];

            Color colorSlot = new Color(PlayerPrefs.GetFloat(COLOR + i + 0), PlayerPrefs.GetFloat(COLOR + i + 1), PlayerPrefs.GetFloat(COLOR + i + 2), PlayerPrefs.GetFloat(COLOR + i + 3));
            items[i].color = colorSlot;
        }
    }
}
