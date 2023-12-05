using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ItemCollector : MonoBehaviour
{
    [SerializeField] private GameObject CollectPrefab;
    [SerializeField] private TextMeshProUGUI MelonText;

    public void UpdateCounter()
    {
        MelonText.text = "Melons: " + GameManager.Instance.Melons.ToString();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Melon"))
        {
            GameObject Collect = Instantiate(CollectPrefab);
            Collect.transform.position = collision.gameObject.transform.position;
            Destroy(collision.gameObject);
            Destroy(Collect, 0.5f);

            GameManager.Instance.Melons++;
            UpdateCounter();
        }
    }

    private void Start()
    {
        UpdateCounter();
    }
}
