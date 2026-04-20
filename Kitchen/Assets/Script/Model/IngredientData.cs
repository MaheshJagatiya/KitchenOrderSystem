
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
            IngredientType.Vege => 20,
            IngredientType.Cheese => 10,
            IngredientType.Meat => 30,
            _ => 0
        };
    }
}
