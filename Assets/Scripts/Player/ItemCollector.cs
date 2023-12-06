using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ItemCollector : MonoBehaviour
{
    [SerializeField] private GameObject CollectPrefab;
    [SerializeField] private TextMeshProUGUI MelonText;
    private PlayerMovement pm;

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
        else if (collision.gameObject.CompareTag("JumpBoost"))
        {
            collision.gameObject.GetComponent<Animator>().SetTrigger("Collect");

            pm.AirJumps++;
            UpdateCounter();
        }
    }

    private void Start()
    {
        pm = GetComponent<PlayerMovement>();
        UpdateCounter();
    }
}
