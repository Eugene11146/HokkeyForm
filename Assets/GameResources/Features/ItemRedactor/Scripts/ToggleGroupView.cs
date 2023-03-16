using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ¬ьюшка дл€ отображени€ элементов выбора(туглов)
/// </summary>
public class ToggleGroupView : MonoBehaviour
{
    [SerializeField]
    private List<ToggleChangeImage> toggleChanges;

    [SerializeField]
    private ItemController controller;

    private void Awake()
    {
        controller.OnItemChanged += CheckToggles;
    }

    private void CheckToggles(int range)
    {
        for (int i = 0; i < toggleChanges.Count; i++)
        {
            toggleChanges[i].gameObject.SetActive(i < range);
        }
    }
}
