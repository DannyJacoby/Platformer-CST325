﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class LevelParserStarter : MonoBehaviour
{
    public string filename;

    public GameObject Rock;

    public GameObject Brick;

    public GameObject QuestionBox;

    public GameObject Stone;

    public Transform parentTransform;
    // Start is called before the first frame update
    void Start()
    {
        RefreshParse();
    }

    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            RefreshParse();
        }
    }


    private void FileParser()
    {
        string fileToParse = string.Format("{0}{1}{2}.txt", Application.dataPath, "/Resources/", filename);

        using (StreamReader sr = new StreamReader(fileToParse))
        {
            string line = "";
            int row = 0;
            while ((line = sr.ReadLine()) != null)
            {
                int column = 0;
                char[] letters = line.ToCharArray();
                foreach (var letter in letters)
                {
                    SpawnPrefab(letter, new Vector3(column, -row, -0.5f)); // spawn a prefab based on a letter, look below ie SpawnPrefab(letter, new Vector3(row, column, 0);
                    column++;
                }
                row++;
            }

            sr.Close();
        }
    }

    private void SpawnPrefab(char spot, Vector3 positionToSpawn)
    {
        GameObject ToSpawn;

        switch (spot)
        {
            case 'b': //Debug.Log("Spawn OBJ " + currPull + " Brick @ " + positionToSpawn);
                ToSpawn = Brick;
                break;
            case '?': //Debug.Log("Spawn OBJ " + currPull + "  QuestionBox @ " + positionToSpawn);
                ToSpawn = QuestionBox;
                break;
            case 'x': //Debug.Log("Spawn OBJ " + currPull + "  Rock @ " + positionToSpawn);
                ToSpawn = Rock;
                break;
            case 's': //Debug.Log("Spawn OBJ " + currPull + "  Stone @ " + positionToSpawn);
                ToSpawn = Stone;
                break;
            //default: Debug.Log("Default Entered"); break;
            default: return;
        }

        ToSpawn = GameObject.Instantiate(ToSpawn, parentTransform);
        ToSpawn.transform.localPosition = positionToSpawn;
    }

    public void RefreshParse()
    {
        GameObject newParent = new GameObject();
        newParent.name = "Environment";
        newParent.transform.position = parentTransform.position;
        newParent.transform.parent = this.transform;
        
        if (parentTransform) Destroy(parentTransform.gameObject);

        parentTransform = newParent.transform;
        FileParser();
    }

    public void OnMouseDown()
    {
        Destroy(this.gameObject);
    }
}
