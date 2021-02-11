using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryObjectDisplay : MonoBehaviour
{
    public InventoryObjects inventoryObject;

    public Text nameText;
    public Text descText;

    public Text dollarydoosText;
    public Text amountText;

    public Image artworkImage;

    void Start()
    {
        nameText.text = inventoryObject.name;
        descText.text = inventoryObject.description;
        dollarydoosText.text = inventoryObject.dollarydoos.ToString();
        amountText.text = inventoryObject.amount.ToString();
        artworkImage.sprite = inventoryObject.artwork;
    }

}
