using UnityEngine;

public class Droppable : Interactible
{
    public Item Item;

    public int hp = 2;

    public float cooldown = 0.75f;

    public GameObject destroyedModel = null;

    private GameObject destroyedModelInstance = null;


    public override void Interact()
    {
        if (InputManager.Instance.IsAttacking())
        {
            if (--hp <= 0)
            {
                if (Item != null)
                {
                    CreateItem();
                }

                DestroyObject();
            }
        }
    }

    private void CreateItem()
    {
        // Create the object that can be picked after the current droppable object is destroyed
        GameObject pickableItem = Instantiate(Item.model);
        pickableItem.name = Item.name;
        pickableItem.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);

        ItemPickup itemPickup = pickableItem.AddComponent<ItemPickup>();
        itemPickup.Item = Item;
        itemPickup.radius = 0.8f;
    }

    private void DestroyObject()
    {
        if (destroyedModel != null)
        {
            // Create the cracked version of the current object and destroy it after some time
            destroyedModelInstance = Instantiate(destroyedModel, transform.position, transform.rotation);

            WaitForTimeThenExecute.ExecuteAfterDelay(3f, DestroyCrackedObject);
        }

        Destroy(gameObject);
    }

    private void DestroyCrackedObject()
    {
        Destroy(destroyedModelInstance);
    }
}
