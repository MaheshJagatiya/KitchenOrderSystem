using UnityEngine;

public class IngredientView : MonoBehaviour
{
    public IngredientData Data;

    public void Init(IngredientType type)
    {
        Data = new IngredientData(type);
    }
}
