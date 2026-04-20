using UnityEngine;
using TMPro;
using System.Collections;
using System.Text;

public class OrderUIView : MonoBehaviour
{
    public TextMeshPro orderText;

    OrderData order;
    Coroutine timerRoutine;

    public void Bind(OrderData data)
    {
        order = data;
        UpdateUI();

        if (timerRoutine != null)
            StopCoroutine(timerRoutine);
      
        timerRoutine = StartCoroutine(UpdateTimer());
    }
    IEnumerator UpdateTimer()
    {
        while (order != null)
        {
            float time = Time.time - order.StartTime;

            orderText.text = GetItemsText() + "\n" + Mathf.FloorToInt(time) + "s";

            yield return new WaitForSeconds(1f); 
        }
    }

    string GetItemsText()
    {
        StringBuilder sb = new StringBuilder();

        foreach (var item in order.RequiredItems)
        {
            sb.Append(item.ToString()).Append("\n");
        }

        return sb.ToString();
    }

    void UpdateUI()
    {
        orderText.text = GetItemsText();
    }
}