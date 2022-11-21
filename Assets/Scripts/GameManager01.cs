using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager01 : MonoBehaviour
{
    public static GameManager01 instance;
    public float restartDelay=1f;
    public GameObject[] playerCharacters;
    public float waitAfterDying = 2f;

    private void Awake(){
        instance = this;
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

    public void Nivel3(){
        SceneManager.LoadScene("Nivel3");
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void PlayerDied(){

        StartCoroutine(PlayerDiedCo());
        
    }

    public IEnumerator PlayerDiedCo(){

        yield return new WaitForSeconds(waitAfterDying);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
/*
    public void Credits(){
        SceneManager.LoadScene("Credits");
    }

    public void Nivel1(){
        SceneManager.LoadScene("Nivel1");
    }*/
}