using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUp : MonoBehaviour
{
    public float PowerupMultiplier = 20f;

    public AudioSource Tapsound;

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.CompareTag("Player"))
        {
            Tapsound.Play();

            Pickup(coll);
        }
    }

    void Pickup(Collider2D player)
    {

        Player Health = player.GetComponent<Player>();
        Health.curHealth += PowerupMultiplier;

        Destroy(gameObject);
    }


}
