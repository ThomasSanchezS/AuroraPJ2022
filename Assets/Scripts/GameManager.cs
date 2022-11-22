using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public float restartDelay=1f;
    public GameObject[] playerCharacters;
    void restart(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    private void Start(){
         playerCharacters = GameObject.FindGameObjectsWithTag("Player");
         Cursor.lockState = CursorLockMode.Locked;

    }
    private void Update(){
         /* foreach (GameObject jugadorpj in playerCharacters){
             float playerHealth=jugadorpj.GetComponent<PlayerHealth>().currentHealth;
              if(playerHealth<=0){
                Debug.Log("holi");
          }
          }*/
    }

    public void GameOver(){
        SceneManager.LoadScene("Nivel2.1.1");
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Locked;
    }
/*
    public void Credits(){
        SceneManager.LoadScene("Credits");
    }

    public void Nivel1(){
        SceneManager.LoadScene("Nivel1");
    }*/
}