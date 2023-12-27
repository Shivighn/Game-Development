using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingBlock : MonoBehaviour
{
    Rigidbody2D rb2d;

    PowerUp powerupscript;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();

        powerupscript = GetComponent<PowerUp>();
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name.Equals("mario"))
        {
            Invoke("DropPlatform", 0.2f);
        }
    }

    void DropPlatform()
    {
        rb2d.isKinematic = false;
    }

}
