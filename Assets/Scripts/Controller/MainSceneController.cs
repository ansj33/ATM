using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainSceneController : MonoBehaviour
{
    public Text cashText; // 현금
    public Text balanceText; // 잔액
    private DataManager dataManager;

    private void Start()
    {
        dataManager = DataManager.instance;
        UpdateUI();
    }

    private void Update()
    {
        UpdateUI();
    }

    private void UpdateUI()
    {
        cashText.text = dataManager.cash.ToString("N0"); //NO를 쓰면 단위 표기 가능
        balanceText.text = dataManager.balance.ToString("N0");
    }
}
