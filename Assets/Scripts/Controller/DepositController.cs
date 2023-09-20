using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DepositController : MonoBehaviour
{
    public Text cashText; // ����
    public Text balanceText; // �ܾ�
    public InputField DespositInput; // �Է�â
    public GameObject WarningPanel;

    private DataManager dataManager;

    private void Start()
    {
        dataManager = DataManager.instance;
        UpdateUI();
    }

    private void UpdateUI()
    {
        cashText.text = dataManager.cash.ToString("N0"); //NO�� ���� ���� ǥ�� ����
        balanceText.text = dataManager.balance.ToString("N0");
    }

    private void Deposit(int amount)
    {

        if (dataManager.cash >= amount)
        {
            dataManager.cash -= amount;
            dataManager.balance += amount;
            UpdateUI();

            DataManager.instance.cash = dataManager.cash;
            DataManager.instance.balance = dataManager.balance;
        }
        else
        {
            WarningPanel.SetActive(true);
        }
    }

    public void Deposit1()
    {
        Deposit(10000);
    }

    public void Deposit2()
    {
        Deposit(30000);
    }

    public void Deposit3()
    {
        Deposit(50000);
    }

    public void Deposit4()
    {
        if (int.TryParse(DespositInput.text, out int amount))
        {
            Deposit(amount);
        }
        //�߸��� �Է½� ���â
    }

    public void CloseWarningPanel()
    {
        WarningPanel.SetActive(false);
    }
}