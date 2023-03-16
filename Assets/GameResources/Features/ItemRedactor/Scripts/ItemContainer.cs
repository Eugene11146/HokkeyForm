using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// SO-контейнер итемов конкретного типа(форма,лого и тд.)
/// </summary>
[CreateAssetMenu(fileName = nameof(ItemContainer), menuName = nameof(ItemContainer))]
public class ItemContainer : ScriptableObject
{
    public List<CustomItem> Forms;

    /// <summary>
    /// Конкретный итем чего-либо
    /// </summary>
    [Serializable]
    public class CustomItem
    {
        /// <summary>
        /// Конкретные спрайты итема
        /// </summary>
        public List<Sprite> ItemSprites;

        /// <summary>
        /// Количество редактируемых спрайтов
        /// </summary>
        public int CoutColoredItems;
    }
}


