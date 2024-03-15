using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Thirdweb;
using UnityEngine.Events;
using UnityEngine.UI;
using System;

public class ThirdwebInfo : MonoBehaviour
{

    public Logos[] logos;


    public TMPro.TextMeshProUGUI textMeshPro;

    public const string ContractAddress = "0xfd3fd9b793bAc60e7F0a9b9fB759DB3e250383cB";
    public bool ethereanOwner = false;


    public UnityEvent OnEthereansCheck = new UnityEvent();
    //public UnityEvent onUse = new UnityEvent();
    //public UnityEvent onUse = new UnityEvent();


    public async void ChangeTextToAddrress()
    {
        var result = await ThirdwebManager.Instance.SDK.wallet.GetAddress();

        textMeshPro.text = result.ToString();
    }

    public async void GetNFTBalance()
    {
        Contract contract = ThirdwebManager.Instance.SDK.GetContract(ContractAddress);
        var results = await contract.ERC721.Balance();

        int cantethereans = int.Parse(results);

        if (cantethereans != 0)
        {
            ethereanOwner = true;

            OnEthereansCheck.Invoke();
        }
    }



    public async void DetectChangeLink()
    {
        var result = await ThirdwebManager.Instance.SDK.wallet.GetChainId();
        textMeshPro.text = result.ToString();

        foreach (var item in logos) {
            item.logo.enabled = false;
        }


        foreach (var item in logos)
        {
            if (item.chainId == result.ToString())
            {
                item.logo.enabled = true;
                break;
            }
        }





    }
}

[Serializable]
public class Logos
{
    public string chainId;
    public Image logo;
}