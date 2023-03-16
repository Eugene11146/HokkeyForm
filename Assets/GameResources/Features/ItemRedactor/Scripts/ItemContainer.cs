using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// SO-��������� ������ ����������� ����(�����,���� � ��.)
/// </summary>
[CreateAssetMenu(fileName = nameof(ItemContainer), menuName = nameof(ItemContainer))]
public class ItemContainer : ScriptableObject
{
    public List<CustomItem> Forms;

    /// <summary>
    /// ���������� ���� ����-����
    /// </summary>
    [Serializable]
    public class CustomItem
    {
        /// <summary>
        /// ���������� ������� �����
        /// </summary>
        public List<Sprite> ItemSprites;

        /// <summary>
        /// ���������� ������������� ��������
        /// </summary>
        public int CoutColoredItems;
    }
}


