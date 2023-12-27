using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour 
{
    //float
    public float maxSpeed = 3;
    public float speed = 10f;
    public float jumpPower = 150f;

    //boolean
    public bool grounded;
    public bool canDoubleJump;

    //references
    private Rigidbody2D rb2d;
    private Animator anim;
    private gameMaster gm;
    public Animator transitionAnim;

    //Audio
    public AudioSource PLasticbottle;
    public AudioSource Plasticpickupsound;

    public float curHealth;
    public float maxHealth = 350f;

    public Slider slider;

    void Start ()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();

        curHealth = 10f;

        gm = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<gameMaster>();
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("Grounded", grounded);
        anim.SetFloat("Speed", Mathf.Abs(rb2d.velocity.x));

        if (Input.GetAxis("Horizontal") < -0.1f)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

        if (Input.GetAxis("Horizontal") > 0.1f)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }


        if (Input.GetButtonDown("Jump"))
        {
            if (grounded)
            {
                rb2d.AddForce(Vector2.up * jumpPower);
                canDoubleJump = true;
            }
            else
            {
                if (canDoubleJump)
                {
                    canDoubleJump = false;
                    rb2d.velocity = new Vector2(rb2d.velocity.x, 0);
                    rb2d.AddForce(Vector2.up * jumpPower / 1.65f);
                }
            }
        }
        slider.value = curHealth;

        if (curHealth <= 0)
        {
            Application.LoadLevel(3);
        }

        if (curHealth >= 350)
        {
            Application.LoadLevel(4);
        }


    }
    void FixedUpdate()
    {
        Vector3 easeVelocity = rb2d.velocity;
        easeVelocity.y = rb2d.velocity.y;
        easeVelocity.z = 0.0f;
        easeVelocity.x *= 0.75f;

        float h = Input.GetAxis("Horizontal");

        //FAke Friction
        if(grounded)
        {
            rb2d.velocity = easeVelocity;
        }

        rb2d.AddForce((Vector2.right * speed) * h);

        if (rb2d.velocity.x > maxSpeed)
        {
            rb2d.velocity = new Vector2(maxSpeed, rb2d.velocity.y);
        }

        if (rb2d.velocity.x < -maxSpeed)
        {
            rb2d.velocity = new Vector2(-maxSpeed, rb2d.velocity.y);
        }
        slider.value = curHealth;
    }

    public void Damage(int dmg)
    {
        curHealth -= dmg;
    }

    public void Increase(int inc)
    {
        curHealth += inc;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("PlasticBottles"))
        {
            Plasticpickupsound.Play();

            Destroy(col.gameObject);

            gm.bottles += 1;
        }

        if (col.CompareTag("RecycleBin"))
        {
            PLasticbottle.Play();

            curHealth += gm.bottles * 5;

            gm.bottles = 0;
        }

        if (col.CompareTag("EndGame"))
        {
            {
                StartCoroutine(loadScene());
                Application.LoadLevel(5);
            }
        }
        if (col.CompareTag("lastendingofgame"))
        {
            if (curHealth < maxHealth)
            {
                Application.LoadLevel(3);
            }
        }
    }

    IEnumerator loadScene()
    {
        transitionAnim.SetTrigger("end");
        yield return new WaitForSeconds(1.5f);
    }
}


