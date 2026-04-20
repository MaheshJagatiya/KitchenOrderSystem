using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class CustomerWindowView : MonoBehaviour, IInteractable
{
   
    [SerializeField] OrderController orderController;
    [SerializeField] ScoreController scoreController;
    [SerializeField] OrderUIView orderUI;

    OrderData order;

    void Start()
    {
        order = orderController.CreateOrder();
        orderUI.Bind(order);
    }

    public void Interact(PlayerView player)
    {

        Debug.Log("Window Interact called");

        if (player.HeldItem == null)
        {
            Debug.Log("No item in hand");
            FloatingTextSpawner.Instance.Spawn("No item in hand");
            return;
        }

        var data = player.HeldItem.Data;

        Debug.Log("Item Type: " + data.Type + " | Prepared: " + data.IsPrepared);

        if (order.TryServe(data))
        {
            Debug.Log("Item Accepted!");
            FloatingTextSpawner.Instance.Spawn("Item Accepted!");

            Destroy(player.HeldItem.gameObject);
            player.ClearItem();

            if (order.IsComplete)
            {
                Debug.Log("Order Completed!");
                FloatingTextSpawner.Instance.Spawn("Order Completed!");
                CompleteOrder();
            }
        }
        else
        {
            Debug.Log("Item Rejected!");
            FloatingTextSpawner.Instance.Spawn("Item Rejected!");
        }

      
    }

    void CompleteOrder()
    {
        int score = order.CalculateScore(Time.time);

        scoreController.AddScore(score);

        Invoke(nameof(Respawn), 5f);
    }

    void Respawn()
    {
        order = orderController.CreateOrder();
        orderUI.Bind(order);
    }
}
