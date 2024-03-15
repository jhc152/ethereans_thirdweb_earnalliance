//using UnityEngine;
//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.Security.Cryptography;
//using System.Text;
//using UnityEngine.Networking;

//public class EarnAlliance : MonoBehaviour
//{
//    public string clientId = "f33b6347-41c8-4861-bbc2-4374046b1a80";
//    public string clientSecret = "CCoZ6jabkwQ7wxhLXODCP5htvruy8xLK";
//    public string gameId = "3cb8a1cd-0942-4f93-9fd9-ea35f25011b9";
//    public string baseUrl = "https://events.earnalliance.com/v2";
//    private string walletAddress = "0xb794f5ea0ba39494ce839613fffba74279579268";

//    public void ConnectedEarnAlliance()
//    {
//        string connectWalletBody = "{\"gameId\": \"" + gameId + "\", \"identifiers\": [{\"walletAddress\": \"" + walletAddress + "\"}]}";
//        StartCoroutine(ComunEarnAlliance(connectWalletBody));
//    }

//    public void REPEL_INVASIONEarnAlliance()
//    {
//        string repelInvasionBody = "{\"gameId\": \"" + gameId + "\", \"events\": [{\"walletAddress\": \"" + walletAddress + "\", \"event\": \"REPEL_INVASION\", \"time\": \"" + DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ss.fffZ") + "\"}]}";
//        StartCoroutine(ComunEarnAlliance(repelInvasionBody));
//    }

//    IEnumerator ComunEarnAlliance(string body)
//    {
//        long ts = DateTimeOffset.Now.ToUnixTimeMilliseconds();
//        string message = $"{clientId}{ts}{body}";

//        using (HMACSHA256 hmac = new HMACSHA256(Encoding.UTF8.GetBytes(clientSecret)))
//        {
//            byte[] messageBytes = Encoding.UTF8.GetBytes(message);
//            byte[] signatureBytes = hmac.ComputeHash(messageBytes);
//            string signature = BitConverter.ToString(signatureBytes).Replace("-", "").ToLower();

//            Dictionary<string, string> headers = new Dictionary<string, string>();
//            headers.Add("x-client-id", clientId);
//            headers.Add("x-timestamp", ts.ToString());
//            headers.Add("x-signature", signature);

//            using (UnityWebRequest request = new UnityWebRequest(baseUrl, "POST"))
//            {
//                byte[] bodyRaw = Encoding.UTF8.GetBytes(body);
//                request.uploadHandler = new UploadHandlerRaw(bodyRaw);
//                request.downloadHandler = new DownloadHandlerBuffer();

//                foreach (KeyValuePair<string, string> header in headers)
//                {
//                    request.SetRequestHeader(header.Key, header.Value);
//                }

//                yield return request.SendWebRequest();

//                Debug.Log("Response: " + request.downloadHandler.text);
//            }
//        }
//    }
//}



//using UnityEngine;
//using System;
//using System.Security.Cryptography;
//using System.Text;
//using UnityEngine.Networking;
//using System.Collections;
//using System.Collections.Generic;

//public class EarnAllianceIntegration : MonoBehaviour
//{
//    //public string clientId = "<client id>";
//    //public string clientSecret = "<client secret>";
//    //public string baseUrl = "https://events.earnalliance.com/v2";
//    //private string walletAddress = "0xb794f5ea0ba39494ce839613fffba74279579268";

//    public string clientId = "f33b6347-41c8-4861-bbc2-4374046b1a80";
//    public string clientSecret = "CCoZ6jabkwQ7wxhLXODCP5htvruy8xLK";
//    public string gameId = "3cb8a1cd-0942-4f93-9fd9-ea35f25011b9";
//    public string baseUrl = "https://events.earnalliance.com/v2";
//    private string walletAddress = "0xb794f5ea0ba39494ce839613fffba74279579268";

//    void Start()
//    {
//        // Ejemplo 1: Cuando se conecta una billetera
//        string connectWalletBody = "{\"gameId\": \"3cb8a1cd-0942-4f93-9fd9-ea35f25011b9\", \"identifiers\": [{\"userId\": \"[your internal user id]\", \"walletAddress\": \"" + walletAddress + "\"}]}";
//        StartCoroutine(SendRequesdfst(connectWalletBody));

//        // Ejemplo 2: Cuando la invasión ha sido repelida
//        string repelInvasionBody = "{\"gameId\": \"3cb8a1cd-0942-4f93-9fd9-ea35f25011b9\", \"events\": [{\"userId\": \"[your internal user id]\", \"event\": \"REPEL_INVASION\", \"time\": \"" + DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ss.fffZ") + "\"}]}";
//        StartCoroutine(SendRequesdfst(repelInvasionBody));
//    }


//    public void ConnectedEarnAlliance()
//    {

//        string connectWalletBody = "{\"gameId\": \"" + gameId + "\", \"identifiers\": [{\"walletAddress\": \"" + walletAddress + "\"}]}";
//        StartCoroutine(SendRequesdfst(connectWalletBody));
//    }

//    public void REPEL_INVASIONEarnAlliance()
//    {
//        string repelInvasionBody = "{\"gameId\": \"" + gameId + "\", \"events\": [{\"walletAddress\": \"" + walletAddress + "\", \"event\": \"REPEL_INVASION\", \"time\": \"" + DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ss.fffZ") + "\"}]}";
//        StartCoroutine(SendRequesdfst(repelInvasionBody));
//    }





//    IEnumerator SendRequesdfst(string body)
//    {
//        string signature = GenerateSignature(body);


//        Console.WriteLine(signature);


//        UnityWebRequest request = new UnityWebRequest(baseUrl+ "/custom-events", "POST");
//        request.SetRequestHeader("x-client-id", clientId);
//        request.SetRequestHeader("x-timestamp", DateTimeOffset.Now.ToUnixTimeMilliseconds().ToString());
//        request.SetRequestHeader("x-signature", signature);
//        byte[] bodyRaw = Encoding.UTF8.GetBytes(body);
//        request.uploadHandler = new UploadHandlerRaw(bodyRaw);
//        request.downloadHandler = new DownloadHandlerBuffer();


//        yield return request.SendWebRequest();

//        // Manejar la respuesta
//        if (request.result == UnityWebRequest.Result.Success)
//        {
//            Debug.Log("Request successful! Response: " + request.downloadHandler.text);
//        }
//        else
//        {
//            Debug.LogError("Request failed! Error: " + signature);
//        }
//    }

//    string GenerateSignature(string message)
//    {
//        long ts = DateTimeOffset.Now.ToUnixTimeMilliseconds();
//        string fullMessage = $"{clientId}{ts}{message}";

//        using (HMACSHA256 hmac = new HMACSHA256(Encoding.UTF8.GetBytes(clientSecret)))
//        {
//            byte[] messageBytes = Encoding.UTF8.GetBytes(fullMessage);
//            byte[] signatureBytes = hmac.ComputeHash(messageBytes);
//            return BitConverter.ToString(signatureBytes).Replace("-", "").ToLower();
//        }
//    }
//}




//using UnityEngine;
//using UnityEngine.Networking;
//using System.Collections;
//using System.Text;
//using System;

//public class EventSender : MonoBehaviour
//{
//    // Datos de autenticación y URL base
//    //private string clientId = "[CLIENT_ID]";
//    //private string clientSecret = "[CLIENT_SECRET]";
//    //private string baseURL = "https://events.earnalliance.com/v2";


//    public string clientId = "f33b6347-41c8-4861-bbc2-4374046b1a80";
//    public string clientSecret = "CCoZ6jabkwQ7wxhLXODCP5htvruy8xLK";
//    public string gameId = "3cb8a1cd-0942-4f93-9fd9-ea35f25011b9";
//    public string baseURL = "https://events.earnalliance.com/v2";





//    // Método para enviar el evento personalizado
//    public IEnumerator SendCustomEvent(string userId, string discordId, string email, string twitterId, string walletAddress)
//    {
//        // Generar el cuerpo de la solicitud en formato JSON
//        string requestBody = JsonUtility.ToJson(new CustomEvent(userId, discordId, email, twitterId, walletAddress));

//        // Obtener la marca de tiempo actual en milisegundos
//        long timestamp = DateTimeOffset.Now.ToUnixTimeMilliseconds();

//        // Construir el mensaje para generar la firma
//        string message = $"{clientId}{timestamp}{requestBody}";

//        // Generar la firma utilizando HMAC SHA256
//        string signature = GenerateSignature(message);

//        //// Configurar los encabezados de la solicitud
//        //var headers = new Dictionary<string, string>();
//        //headers.Add("x-client-id", clientId);
//        //headers.Add("x-timestamp", timestamp.ToString());
//        //headers.Add("x-signature", signature);
//        //headers.Add("Content-Type", "application/json");

//        //// Crear la solicitud POST
//        //UnityWebRequest request = new UnityWebRequest(baseURL + "/custom-events", "POST");
//        //byte[] bodyRaw = Encoding.UTF8.GetBytes(requestBody);
//        //request.uploadHandler = (UploadHandler)new UploadHandlerRaw(bodyRaw);
//        //request.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();



//        UnityWebRequest request = new UnityWebRequest(baseURL + "/custom-events", "POST");
//        byte[] bodyRaw = Encoding.UTF8.GetBytes(requestBody);
//        request.uploadHandler = (UploadHandler)new UploadHandlerRaw(bodyRaw);
//        request.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();

//        // Establecer los encabezados de la solicitud individualmente
//        request.SetRequestHeader("x-client-id", clientId);
//        request.SetRequestHeader("x-timestamp", timestamp.ToString());
//        request.SetRequestHeader("x-signature", signature);
//        request.SetRequestHeader("Content-Type", "application/json");



//        // Agregar los encabezados a la solicitud
//        //foreach (var header in headers)
//        //{
//        //    request.SetRequestHeader(header.Key, header.Value);
//        //}

//        // Enviar la solicitud
//        yield return request.SendWebRequest();

//        // Manejar la respuesta
//        if (request.result == UnityWebRequest.Result.Success)
//        {
//            Debug.Log("Custom event sent successfully!");
//        }
//        else
//        {
//            Debug.LogError("Failed to send custom event: " + request.error);
//        }
//    }

//    // Método para generar la firma
//    private string GenerateSignature(string message)
//    {
//        byte[] keyBytes = Encoding.UTF8.GetBytes(clientSecret);
//        byte[] messageBytes = Encoding.UTF8.GetBytes(message);

//        using (var hmacsha256 = new System.Security.Cryptography.HMACSHA256(keyBytes))
//        {
//            byte[] hashmessage = hmacsha256.ComputeHash(messageBytes);
//            return BitConverter.ToString(hashmessage).Replace("-", "").ToLower();
//        }
//    }

//    // Clase para representar el evento personalizado
//    [Serializable]
//    public class CustomEvent
//    {
//        public string gameId;
//        public Identifier[] identifiers;

//        public CustomEvent(string userId, string discordId, string email, string twitterId, string walletAddress)
//        {
//            gameId = "[GAME_ID]";
//            identifiers = new Identifier[]
//            {
//                new Identifier(userId, discordId, email, twitterId, walletAddress)
//            };
//        }
//    }

//    // Clase para representar el identificador del usuario
//    [Serializable]
//    public class Identifier
//    {
//        public string userId;
//        public string discordId;
//        public string email;
//        public string twitterId;
//        public string walletAddress;

//        public Identifier(string userId, string discordId, string email, string twitterId, string walletAddress)
//        {
//            this.userId = userId;
//            this.discordId = discordId;
//            this.email = email;
//            this.twitterId = twitterId;
//            this.walletAddress = walletAddress;
//        }
//    }
//}



using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using UnityEngine.Networking;




public class EarnAlliance : MonoBehaviour
{
    // Datos de autenticación y URL base
    //private string clientId = "[CLIENT_ID]";
    //private string clientSecret = "[CLIENT_SECRET]";
    //private string baseURL = "https://events.earnalliance.com/v2";


    public string clientId = "f33b6347-41c8-4861-bbc2-4374046b1a80";
    public string clientSecret = "CCoZ6jabkwQ7wxhLXODCP5htvruy8xLK";
    public string gameId = "3cb8a1cd-0942-4f93-9fd9-ea35f25011b9";
    public string baseURL = "https://events.earnalliance.com/v2";

    string userId = "user123";


    // Método para enviar el evento personalizado
    public IEnumerator SendCustomEvent(string _body)
    {
        // Crear el objeto JSON para el cuerpo de la solicitud
        string requestBody = _body; // $"{{\"gameId\":\"3cb8a1cd-0942-4f93-9fd9-ea35f25011b9\",\"identifiers\":[{{\"userId\":\"{userId}\",\"walletAddress\":\"{walletAddress}\"}}]}}";

        // Obtener la marca de tiempo actual en milisegundos
        string timestamp = DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ss.fffZ");

        // Construir el mensaje para generar la firma
        string message = $"{clientId}{timestamp}{requestBody}";

        // Generar la firma utilizando HMAC SHA256
        string signature = GenerateSignature(message);

        // Crear la solicitud POST
        UnityWebRequest request = new UnityWebRequest(baseURL + "/custom-events", "POST");
        byte[] bodyRaw = Encoding.UTF8.GetBytes(requestBody);
        request.uploadHandler = (UploadHandler)new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();

        // Establecer los encabezados de la solicitud
        request.SetRequestHeader("x-client-id", clientId);
        request.SetRequestHeader("x-timestamp", timestamp.ToString());
        request.SetRequestHeader("x-signature", signature);
        request.SetRequestHeader("Content-Type", "application/json");

        // Enviar la solicitud
        yield return request.SendWebRequest();

        // Manejar la respuesta
        if (request.result == UnityWebRequest.Result.Success)
        {
            Debug.Log("Custom event sent successfully!");
        }
        else
        {
            Debug.LogError("Failed to send custom event: " + request.error);
        }
    }

    // Método para generar la firma
    private string GenerateSignature(string message)
    {
        byte[] keyBytes = Encoding.UTF8.GetBytes(clientSecret);
        byte[] messageBytes = Encoding.UTF8.GetBytes(message);

        using (var hmacsha256 = new System.Security.Cryptography.HMACSHA256(keyBytes))
        {
            byte[] hashmessage = hmacsha256.ComputeHash(messageBytes);
            return System.BitConverter.ToString(hashmessage).Replace("-", "").ToLower();
        }


    }


    public void Start()
    {
        int seed = (int)DateTime.Now.Ticks;
        UnityEngine.Random.InitState(seed);

        // Genera un número aleatorio de 5 dígitos
        int randomNumber = UnityEngine.Random.Range(10000, 100000);

        userId = "user" + randomNumber.ToString();
    }

    public void ConnectedEarnAlliance()
    {

        
        string walletAddress = "0xb794f5ea0ba39494ce839613fffba74279579268";

        string requestBody = $"{{\"gameId\":\"3cb8a1cd-0942-4f93-9fd9-ea35f25011b9\",\"identifiers\":[{{\"userId\":\"{userId}\",\"walletAddress\":\"{walletAddress}\"}}]}}";

        StartCoroutine(SendCustomEvent(requestBody));
    }


    public void CompleteChallenge()
    {

       
        string walletAddress = "0xb794f5ea0ba39494ce839613fffba74279579268";

       // string requestBody = $"{{\"gameId\":\"3cb8a1cd-0942-4f93-9fd9-ea35f25011b9\",\"identifiers\":[{{\"userId\":\"{userId}\",\"walletAddress\":\"{walletAddress}\"}}]}}";

        string timestamp = DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ss.fffZ");
        string requestBody = $"{{\"gameId\":\"{gameId}\",\"events\":[{{\"userId\":\"{userId}\",\"event\":\"REPEL_INVASION\",\"time\":\"{timestamp}\"}}]}}";

        StartCoroutine(SendCustomEvent(requestBody));
    }



}
