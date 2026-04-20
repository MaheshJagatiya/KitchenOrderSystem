using UnityEngine;
using System.Collections;

public class StoveView : MonoBehaviour, IInteractable
{
    [SerializeField] Transform slot1;
    [SerializeField] Transform slot2;

    public void Interact(PlayerView player)
    {
       
        if (player.HeldItem != null)
        {
            var data = player.HeldItem.Data;

            if (data.Type == IngredientType.Meat && !data.IsPrepared)
            {
                Transform slot = GetFreeSlot();
                if (slot == null) return;

                // Place meat
                player.HeldItem.transform.SetParent(slot);
                player.HeldItem.transform.localPosition = Vector3.zero;

                StartCoroutine(Cook(data));

                player.ClearItem();
                return;
            }
        }

      
        Transform cookedSlot = GetCookedSlot();

        if (cookedSlot != null && player.HeldItem == null)
        {
            var item = cookedSlot.GetComponentInChildren<IngredientView>();

            if (item != null && item.Data.IsPrepared)
            {
                item.transform.SetParent(null);
                player.PickItem(item);
            }
        }
    }

    Transform GetFreeSlot()
    {
        if (slot1.childCount == 0) return slot1;
        if (slot2.childCount == 0) return slot2;
        return null;
    }

    Transform GetCookedSlot()
    {
        foreach (Transform slot in new[] { slot1, slot2 })
        {
            if (slot.childCount > 0)
            {
                var item = slot.GetComponentInChildren<IngredientView>();
                if (item != null && item.Data.IsPrepared)
                    return slot;
            }
        }
        return null;
    }

    IEnumerator Cook(IngredientData data)
    {
        Debug.Log("Cooking started...");
        FloatingTextSpawner.Instance.Spawn("Cooking started...");

        yield return new WaitForSeconds(6f);

        data.Prepare();

        Debug.Log("Cooking finished!");
        FloatingTextSpawner.Instance.Spawn("Cooking finished!");
    }
}