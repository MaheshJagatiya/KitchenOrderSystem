using System.Collections.Generic;
using UnityEngine;

public class OrderData
{
    public List<IngredientType> RequiredItems { get; private set; }

    //  original copy for score calculation
    private List<IngredientType> originalItems;

    public float StartTime { get; private set; }

    public OrderData(List<IngredientType> items)
    {
        RequiredItems = new List<IngredientType>(items);

        // Store original items 
        originalItems = new List<IngredientType>(items);

        StartTime = Time.time;
    }

    public bool TryServe(IngredientData ingredient)
    {
        // Prepared check
        if (!ingredient.IsPrepared && ingredient.Type != IngredientType.Cheese)
            return false;

        // Match check
        if (RequiredItems.Contains(ingredient.Type))
        {
            RequiredItems.Remove(ingredient.Type); // remove only from active list
            return true;
        }

        return false;
    }

    public bool IsComplete => RequiredItems.Count == 0;

    public int CalculateScore(float currentTime)
    {
        int total = 0;

      
        foreach (var item in originalItems)
        {
            total += item switch
            {
                IngredientType.Vege => 40,
                IngredientType.Cheese => 20,
                IngredientType.Meat => 60,
                _ => 0
            };
        }

        int penalty = Mathf.FloorToInt(currentTime - StartTime);

        return total - penalty;
    }
}
