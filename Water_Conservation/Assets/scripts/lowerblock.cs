using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lowerblock : MonoBehaviour
{
    private Player player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Equals("upperblock"))
        {
            Destroy(GameObject.FindGameObjectWithTag("destroyingblock"));
            player.Increase(30);
        }
    }


}
