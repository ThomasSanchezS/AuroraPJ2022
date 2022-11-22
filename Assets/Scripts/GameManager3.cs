using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager3 : MonoBehaviour
{
    public GameObject[] jefeChar;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        foreach (GameObject jefe in jefeChar){
            if(jefe == null){
                SceneManager.LoadScene("CinematicaN3");
              }
              }
          }
    }

