using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameInterface : MonoBehaviour
{
    public static GameInterface Instance;

    [SerializeField] private TextMeshProUGUI melonText;

    [SerializeField] private Transform jumpCounterPanel;
    [SerializeField] private GameObject jumpPrefab;

    private PlayerMovement pm;

    private void Start()
    {
        pm = GameObject.FindWithTag("Player").GetComponent<PlayerMovement>();
        GameInterface.Instance.UpdateMelonCounter();
    }
    private void Awake()
    {
        if (Instance)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    public void UpdateJumpCounter()
    {
        if (jumpCounterPanel.childCount < pm.AirJumps)
        {
            for (int i = 0; i < pm.AirJumps - jumpCounterPanel.childCount; i++)
            {
                Instantiate(jumpPrefab, jumpCounterPanel);
            }
        }
        else if (jumpCounterPanel.childCount > pm.AirJumps)
        {
            for (int i = 0; i < jumpCounterPanel.childCount - pm.AirJumps; i++)
            {
                Destroy(jumpCounterPanel.GetChild(0).gameObject);
            }
        }
    }
    
    public void UpdateMelonCounter()
    {
        melonText.text = "Melons: " + GameManager.Instance.Melons.ToString();
    }
}
