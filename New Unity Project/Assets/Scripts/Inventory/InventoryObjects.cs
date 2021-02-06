using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="NewInventoryObject", menuName = "Object")]
public class InventoryObjects : ScriptableObject
{
    public new string name;
    public string description;

    public int amount;
    public int dollarydoos;

    public Sprite artwork;
}
