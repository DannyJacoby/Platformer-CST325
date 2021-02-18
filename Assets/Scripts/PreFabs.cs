using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreFabs : MonoBehaviour
{

    private GameObject gm;
    private UI_Manager _uiManager;
    
    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.FindWithTag("UI Manager");
        _uiManager = gm.GetComponent<UI_Manager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // Debug.Log("Mario hit " + this.gameObject.name);
            if (this.gameObject.CompareTag("Brick"))
            {
                Destroy(this.gameObject);
                _uiManager.ScoreTracker(50);
            }

            if (this.gameObject.CompareTag("QuestionBox"))
            {
                _uiManager.CoinTracker(1);
            }
        }
    }
}
