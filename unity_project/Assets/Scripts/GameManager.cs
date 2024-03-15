using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
   
    
    public Bloqueo[] bloqueos = null;


    public void LLegoNPC(GameObject cual)
    {
        // Buscar el objeto 'cual' en los array de 'bloqueos'
        foreach (var bloqueo in bloqueos)
        {
            // Verificar si 'cual' existe en 'bloqueo.objetosEspera'
            foreach (var objetoEspera in bloqueo.directorioConBooleano)
            {
                if (objetoEspera.objetoEspera == cual)
                {
                    // Marcar el booleano como true
                    objetoEspera.booleano = true;

                    // Verificar si todos los booleanos son true
                    bool todosTrue = true;
                    foreach (var objetoEnDirectorio in bloqueo.directorioConBooleano)
                    {
                        if (!objetoEnDirectorio.booleano)
                        {
                            todosTrue = false;
                            break;
                        }
                    }

                    // Si todos los booleanos son true, ejecutar el evento OnComplete
                    if (todosTrue)
                    {
                        bloqueo.OnComplete.Invoke();

                        for (int i = 0; i < bloqueo.objetosOcultarEncuentro.Length; i++)
                        {
                            bloqueo.objetosOcultarEncuentro[i].SetActive(false);
                        }

                        for (int i = 0; i < bloqueo.objetosMostrarEncuentro.Length; i++)
                        {
                            bloqueo.objetosMostrarEncuentro[i].SetActive(true);
                        }



                        bloqueo.OnComplete.Invoke();

                    }

                    return; // Salir del bucle una vez que se ha encontrado y actualizado el objeto 'cual'
                }
            }
        }
    }






    








}

[Serializable]
public class Bloqueo {
    public GameObject[] objetosOcultarEncuentro;
    public GameObject[] objetosMostrarEncuentro;
    public ObjetosEspera[] directorioConBooleano;
    public UnityEvent OnComplete = new UnityEvent();

}

[Serializable]
public class ObjetosEspera
{
    public GameObject objetoEspera;
    public bool booleano;
}




