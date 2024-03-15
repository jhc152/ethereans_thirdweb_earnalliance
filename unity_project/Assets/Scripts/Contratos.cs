using Language.Lua;
using System.Collections;
using System.Collections.Generic;
using Thirdweb;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Networking;



using SimpleJSON;

public class Contratos : MonoBehaviour
{


    public UnityEvent onCompleteInteract;

    public const string ContractAddress = "0xfd3fd9b793bAc60e7F0a9b9fB759DB3e250383cB";



    public async void ClaimArma00()
    {


        try
        {
            Contract contract = ThirdwebManager.Instance.SDK.GetContract(ContractAddress);
            var data = await contract.ERC721.Claim(1);

            onCompleteInteract?.Invoke();
        }
        catch (System.Exception)
        {


        }
    }

    //public class WebViewManager : MonoBehaviour
    //{
    //    void Start()
    //    {
    //        // Llama a la función ejecutarFuncionDesdeUnity con un parámetro desde Unity
    //        Application.ExternalCall("ejecutarFuncionDesdeUnity", "parametros_de_tu_funcion");
    //    }
    //}


    public void MatoEnemigos1()
    {
        Debug.Log("MAtoEnemigos 1");
        Application.ExternalCall("door");

    }

    public void ObtuvisteArma()
    {
        
        Application.ExternalCall("arma");

    }

    public void ObtuvistePoder()
    {

        Application.ExternalCall("poder");

    }


    public void MatoEnemigos2()
    {
        Debug.Log("MAtoEnemigos 2");
        Application.ExternalCall("poder");
    }












    public async void EjemploReadContract()
    {

        //https://portal.thirdweb.com/unity/contracts/read

        try
        {
            Contract contract = ThirdwebManager.Instance.SDK.GetContract(ContractAddress);


            //ENVIANDO 0 parametros
            //var data = await contract.Read<int>("functionName");

            //ENVIANDO 1 o muchos parametros
            //var data = await contract.Read<int>("functionName", "arg1", "arg2");

        }
        catch (System.Exception)
        {

            throw;
        }
    }




    public async void EjemploWriteContract()
    {

        //https://portal.thirdweb.com/unity/contracts/write

        try
        {

            Contract contract = ThirdwebManager.Instance.SDK.GetContract(ContractAddress);

            TransactionResult result = await contract.Write("functionName");

        }
        catch (System.Exception)
        {

            throw;
        }
    }


    public async void EjemploGetContract()
    {

        //https://portal.thirdweb.com/unity/contracts/get
        try
        {


            Contract contract = ThirdwebManager.Instance.SDK.GetContract(ContractAddress);
            var results = await contract.ERC721.Balance();

            int cantethereans = int.Parse(results);

            if (cantethereans != 0)
            {
                //si tiene nfts de ese contrato XX
            }
        }
        catch (System.Exception)
        {

            throw;
        }
    }


    [HideInInspector]
    public JSONNode dataProfile;


    public IEnumerator GetProfile(string address)
    {


        string API_DCL_PROFILE = "http/localhost";



        UnityWebRequest www = UnityWebRequest.Get(API_DCL_PROFILE + address);
        yield return www.SendWebRequest();
       

        if (www.result == UnityWebRequest.Result.Success)
        {
            // string responseText = www.downloadHandler.text;
            //var jsonString = System.Text.Encoding.UTF8.GetString(www.downloadHandler.data, 3,www.downloadHandler.data.Length - 3);

            dataProfile = JSON.Parse(System.Text.Encoding.UTF8.GetString(www.downloadHandler.data));
           // dataProfileAvatar = dataProfile["avatars"][0]["avatar"];


        }

    }
}
