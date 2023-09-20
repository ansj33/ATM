using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WithdrawController : MonoBehaviour
{
    public Text cashText; // 현금
    public Text balanceText; // 잔액
    public InputField WithdrawInput; // 입력창
    public GameObject WarningPanel;


    private DataManager dataManager;

    private void Start()
    {
        dataManager = DataManager.instance;
        UpdateUI();
    }

    private void UpdateUI()
    {
        cashText.text = dataManager.cash.ToString("N0"); //NO를 쓰면 단위 표기 가능
        balanceText.text = dataManager.balance.ToString("N0");
    }

    private void Withdraw(int amount)
    {
        if (dataManager.balance >= amount)
        {
            dataManager.cash += amount;
            dataManager.balance -= amount;
            UpdateUI();
        }
        else
        {
            WarningPanel.SetActive(true);
        }
    }

    public void Withdraw1()
    {
        Withdraw(10000);
    }

    public void Withdraw2()
    {
        Withdraw(30000);
    }

    public void Withdraw3()
    {
        Withdraw(50000);
    }

    public void Withdraw4()
    {
        if (int.TryParse(WithdrawInput.text, out int amount))
        {
            Withdraw(amount);
        }
        //잘못된 입력시 경고창
    }

    public void CloseWarningPanel()
    {
        WarningPanel.SetActive(false);
    }
}
