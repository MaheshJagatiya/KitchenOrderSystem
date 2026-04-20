using UnityEngine;

public class FloatingTextSpawner : MonoBehaviour
{
    public static FloatingTextSpawner Instance;

    [SerializeField] FloatingText prefab;
    [SerializeField] Transform parent;
   
    void Awake()
    {
        Instance = this;
    }

    public void Spawn(string message)
    {
        FloatingText obj = Instantiate(prefab, parent);

        float randomY = Random.Range(-200f, 50f);
        obj.transform.localPosition = new Vector3(0f, randomY, 0f);

        obj.Init(message);
    }
}
