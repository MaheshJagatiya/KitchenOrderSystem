using UnityEngine;

public class RefrigeratorView : MonoBehaviour, IInteractable
{
    public IngredientView vegPrefab, cheesePrefab, meatPrefab;

    public void Interact(PlayerView player)
    {
        if (player.HeldItem != null) return;

        int r = Random.Range(0, 3);
      //  r = 0;
        IngredientView item = Instantiate(
            r == 0 ? vegPrefab : r == 1 ? cheesePrefab : meatPrefab
        );

        item.Init((IngredientType)r);

        player.PickItem(item);
    }
}