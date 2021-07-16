using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loader : MonoBehaviour {

    public GameObject gameManager;
	void Start () {
        if (GameManager.instance == null)
            Instantiate(gameManager);		
	}
	
	
}
