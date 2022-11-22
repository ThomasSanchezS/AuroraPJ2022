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
        
    }

    // Update is called once per frame
    void Update()
    {
        foreach (GameObject jefe in jefeChar){
             float jefeHealth = jefe.GetComponent<EnemyHealthController>().currentHealth;
              if(jefeHealth<=0){
                Debug.Log("holi");
          }
          }
    }
}
