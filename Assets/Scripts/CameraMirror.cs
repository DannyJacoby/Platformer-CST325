using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMirror : MonoBehaviour
{
  public Transform character;

  void Update()
  {
    Vector3 pos = new Vector3(character.position.x, 7.6f, -19.5f);

    this.transform.position = pos;
  }

}
