using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager02 : MonoBehaviour
{
   public void BotonJugar(){
        SceneManager.LoadScene("Nivel1");
   }

   public void BotonSalir(){
        Application.Quit();
   }
   }
