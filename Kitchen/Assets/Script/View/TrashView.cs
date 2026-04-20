using UnityEngine;

public class TrashView : MonoBehaviour, IInteractable
{
    public void Interact(PlayerView player)
    {
        if (player.HeldItem == null) return;

        Destroy(player.HeldItem.gameObject);
        player.ClearItem();
    }
}