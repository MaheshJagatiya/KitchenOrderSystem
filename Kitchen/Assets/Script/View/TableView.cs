using UnityEngine;
using System.Collections;

public class TableView : MonoBehaviour, IInteractable
{
    public void Interact(PlayerView player)
    {
        if (player.HeldItem == null) return;

        var data = player.HeldItem.Data;

        if (data.Type == IngredientType.Vege && !data.IsPrepared)
        {
            StartCoroutine(Chop(data));
        }
    }

    IEnumerator Chop(IngredientData data)
    {
        Debug.Log("Chopping started...");
        FloatingTextSpawner.Instance.Spawn("Chopping started...");
        yield return new WaitForSeconds(2f);
        data.Prepare();
        Debug.Log("Chopping completed!");
        FloatingTextSpawner.Instance.Spawn("Chopping completed!");
    }
}