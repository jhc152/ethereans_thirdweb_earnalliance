using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnTimer : MonoBehaviour
{

    public float segundos = 0;

    public UnityEvent onTimeComplete;
    
    void OnEnable()
    {
        StartCoroutine(ActivarDespuesDeTresSegundos());
    }

    IEnumerator ActivarDespuesDeTresSegundos()
    {
        yield return new WaitForSeconds(segundos);
        onTimeComplete?.Invoke();


    }
}


