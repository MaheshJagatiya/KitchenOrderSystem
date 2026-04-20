using UnityEngine;
using TMPro;
using System.Collections;

public class FloatingText : MonoBehaviour
{
    public TextMeshProUGUI text;

    float life = 1f;
    float speed = 50f;

    public void Init(string message)
    {
        text.text = message;
        life = Random.Range(1f, 2.5f);
        StartCoroutine(Animate());
    }

    IEnumerator Animate()
    {
        float time = 0f;

        while (time < life)
        {
            transform.localPosition += Vector3.up * speed * Time.deltaTime;

            time += Time.deltaTime;

            yield return null; // next frame
        }

        Destroy(gameObject);
    }
}