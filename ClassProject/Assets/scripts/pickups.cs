using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickups : MonoBehaviour
{
    //reference to player
    public PlayerScript player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("sir capsulote").GetComponent<PlayerScript>();
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        if (other.name == "sir capsulote")
        {
            // if the player collides with the coin, increase points and destroy
            player.coinCount++;
            Destroy(this.gameObject);
        }
    }
}