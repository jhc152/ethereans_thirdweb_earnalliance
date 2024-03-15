using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Tareas : MonoBehaviour
{
    public string nombreEvento;
    public UnityEvent eventos;

    public void EjecutaEventos()
    {
        Debug.Log("Sadasdasdasdas");
        eventos.Invoke();
    }


    
}
