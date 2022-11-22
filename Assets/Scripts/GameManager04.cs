using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager04 : MonoBehaviour
{
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
    }
    // Start is called before the first frame update
    public void BotonReiniciar(){

        SceneManager.LoadScene("Menu");
    }
    

    // Update is called once per frame
   
}
