using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class respawn : MonoBehaviour
{
    private Player player;

    [SerializeField] private Transform Player;
    [SerializeField] private Transform Respawnpoint;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        Player.transform.position = Respawnpoint.transform.position;
        player.Damage(20);

    }
}
