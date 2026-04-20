
public class IngredientData
{
    public IngredientType Type { get; private set; }
    public bool IsPrepared { get; private set; }

    public IngredientData(IngredientType type)
    {
        Type = type;
        IsPrepared = false;
    }

    public void Prepare()
    {
        IsPrepared = true;
    }

    public int GetScore()
    {
        return Type switch
        {
            IngredientType.Vege => 40,
            IngredientType.Cheese => 20,
            IngredientType.Meat => 60,
            _ => 0
        };
    }
}
