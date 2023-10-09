using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Navigator : MonoBehaviour
{
    private void Start()
    {
        
    }

    public void OnIsrael()
    {
        SceneManager.LoadScene("Israel");
    }

    public void OnUkraine()
    {
        SceneManager.LoadScene("Ukraine");
    }
}
