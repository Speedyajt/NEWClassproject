using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinnishLine : MonoBehaviour
{
    public GameManager Manager;

    private void OnTriggerEnter(Collider other)    {
        if(other.name == "sir capsulote")
        {
            Manager.endGame();
        }
    }
}