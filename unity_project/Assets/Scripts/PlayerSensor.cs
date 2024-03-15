using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSensor : MonoBehaviour
{

    public Renderer MeshSelector;
    private bool activeColor = false;
    private UnityEngine.UI.Text UseText;
    // Start is called before the first frame update

    void Start()
    {
       

        UseText = GetComponentInChildren<UnityEngine.UI.Text>() as UnityEngine.UI.Text;

        MeshSelector.enabled = false;
        activeColor = false;
        UseText.enabled = false;

    }

        void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (MeshSelector && !activeColor)
            {
                MeshSelector.enabled = true;
                activeColor = true;
                UseText.enabled = true;
                //ChangeColor();

            }
            //if (other.gameObject.GetComponent<PrActorUtils>())
            //    Player = other.gameObject.GetComponent<PrActorUtils>().character.gameObject;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (MeshSelector)
            {
                MeshSelector.enabled = false;
                activeColor = false;
                UseText.enabled = false;
                // ChangeColor();
            }
           // Player = null;
        }
    }

    //protected virtual void ChangeColor()
    //{
    //    if (ColorSetup && activeColor)
    //    {
    //        MeshSelector.material.SetColor("_TintColor", ColorSetup.ActivePickupColor);
    //        if (showText && UseText)
    //        {
    //            UseText.enabled = true;
    //        }
    //    }

    //    else if (ColorSetup && !activeColor)
    //    {
    //        MeshSelector.material.SetColor("_TintColor", ColorSetup.InactivePickupColor);
    //        if (showText && UseText)
    //        {
    //            UseText.enabled = false;
    //        }
    //    }

    //}
}
