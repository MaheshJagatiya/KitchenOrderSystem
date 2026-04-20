using System.Collections.Generic;
using UnityEngine;

public class OrderController : MonoBehaviour 
{
    public OrderData CreateOrder()
    {
        int count = Random.value > 0.5f ? 2 : 3;
        List<IngredientType> items = new();

        for (int i = 0; i < count; i++)
        {
            items.Add((IngredientType)Random.Range(0, 3));
        }

        return new OrderData(items);
    }
}
