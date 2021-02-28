using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreFabs : MonoBehaviour
{

    private GameObject gm;
    private UI_Manager _uiManager;
    public GameObject Ethan;
    
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
            // Debug.Log("Ethan hit " + this.gameObject.name);
            if (this.gameObject.CompareTag("Brick"))
            {
                Destroy(this.gameObject);
                _uiManager.ScoreTracker(100);
                // Debug.Log("HIT BRICK");
            }

            if (this.gameObject.CompareTag("QuestionBox"))
            {
                _uiManager.CoinTracker(1);
                // Debug.Log("HIT QBLOCK");
            }

            if (this.gameObject.CompareTag("Void"))
            {
                // Debug.Log("HIT VOID");
                // reset the player 
                // flash text "YOU DIED" in red
            }

            if (this.gameObject.CompareTag("Coin"))
            {
                // Debug.Log("HIT COIN");
                Destroy(this.gameObject);
                _uiManager.CoinTracker(1);
            }

            if (this.gameObject.CompareTag("Enemy"))
            {
                Debug.Log("Ethan hit " + this.gameObject.name);
                _uiManager.ResetTheGame(false);
            }

            if (this.gameObject.CompareTag("Void"))
            {
                Debug.Log("Ethan hit " + this.gameObject.name);
               _uiManager.ResetTheGame(false); 
            }

            if (this.gameObject.CompareTag("Goal"))
            {
                Debug.Log("Ethan hit " + this.gameObject.name);
                _uiManager.ResetTheGame(true);
            }
            
        }
    }

    private void OnMouseDown()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.CompareTag("Brick"))
            {
                Destroy(this.gameObject);
                _uiManager.ScoreTracker(50);
            }

            if (hit.collider.CompareTag("QuestionBox"))
            {
                _uiManager.CoinTracker(1);
            }
        }
    }
}
