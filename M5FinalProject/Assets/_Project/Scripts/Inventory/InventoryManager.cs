using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance { get; private set; }

    [SerializeField] private GameObject _player;
    [SerializeField] private List<SO_GenericItem> _inventory;

    private KeyCode[] _keyCodes; 

    private void KeyCodeMap()
    {
        _keyCodes = new KeyCode[] { KeyCode.Alpha1, KeyCode.Alpha2, KeyCode.Alpha3, KeyCode.Alpha4, KeyCode.Alpha5, KeyCode.Alpha6 };
    }
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    public void TryToUse(int itemIndex)
    {
        if (itemIndex < 0 || itemIndex >= _inventory.Count) return;
        if (_inventory[itemIndex] == null) return;

        _inventory[itemIndex].Use(_player);
    }

    public int FindItem(SO_GenericItem item)
    {
        for (int i = 0; i < _inventory.Count; i++)
        {
            if (_inventory[i] == item) return i;
        }
        return -1;
    }

    public bool HasItem(SO_GenericItem item)
    {
        return FindItem(item) >= 0;
    }

    public void AddItem(SO_GenericItem item)
    {
        _inventory.Add(item);
    }

    public void RemoveItem(SO_GenericItem item)
    {
        int foundIndex = FindItem(item);
        RemoveItem(foundIndex);
    }

    public void RemoveItem(int index)
    {
        if (index < 0 || index >= _inventory.Count) return;

        _inventory.RemoveAt(index);
    }

    private void Update()
    {
        for ( int i =  0; i < _keyCodes.Length; i++)
        {
            if (i >=_inventory.Count) break;
            if (_inventory[i] != null && Input.GetKeyDown(_keyCodes[i]))
            {
                TryToUse(i);
            }
        }
    }
}
