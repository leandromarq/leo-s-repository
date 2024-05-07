using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PORTADA : MonoBehaviour
{
    public string escenacargar;
    public void cargarescena()
    {
        SceneManager.LoadScene(escenacargar);
    }
}
