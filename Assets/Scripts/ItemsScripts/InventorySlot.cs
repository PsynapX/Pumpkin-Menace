using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Image icon;

    public Button removeButton;

    public GameObject count;

    private Item item;

    public void AddItem(Item newItem)
    {
        ClearSlot();

        item = newItem;

        icon.sprite = item.icon;
        icon.enabled = true;

        removeButton.interactable = true;

        if (item.GetAmount() > 1)
        {
            count.GetComponentInChildren<Text>().text = item.GetAmount().ToString();
            count.SetActive(true);
        }
    }

    public void ClearSlot()
    {
        item = null;

        icon.sprite = null;
        icon.enabled = false;

        removeButton.interactable = false;

        count.GetComponentInChildren<Text>().text = string.Empty;
        count.SetActive(false);
    }

    public void OnRemoveButton()
    {
        Inventory.Instance.Remove(item);
    }

    public void UseItem()
    {
        if (item != null)
        {
            item.Use();
        }
    }
}
