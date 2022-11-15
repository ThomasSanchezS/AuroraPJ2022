using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollisionEnter1 : MonoBehaviour
{
    public GameManager01 gameManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
	{
        Debug.Log("Me esta tocando!!");
		if (other.tag == "Player") {
			gameManager.GameOver();
		}
	}
}
