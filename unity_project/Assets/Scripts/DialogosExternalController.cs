using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogosExternalController : MonoBehaviour
{
    // Start is called before the first frame update


    GameObject User;

    private IEnumerator Start()
    {
        yield return new WaitForSeconds(3);
        while (User == null)
        {
            User = GameObject.Find("Player_0");
            yield return new WaitForEndOfFrame();
        }
    }


    public void StartDialogos()
    {
        Debug.Log("Start Dialogos");
        //PrCharacterController class
        User.SendMessage("StartCharla", SendMessageOptions.DontRequireReceiver);
    }

    public void EndDialogos()
    {
        User.SendMessage("EndCharla", SendMessageOptions.DontRequireReceiver);

        Debug.Log("End Dialogos");
        

    }
}
