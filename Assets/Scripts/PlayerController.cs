using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rigidBody;
    Animator animator;
    public float speed = 5.0f;
    public float jumpForce = 8.0f;
    public float airControlForce = 10.0f;
    public float airControlMax = 1.5f;
    Vector2 boxExtents;

    public AudioSource coinSound;
    public TextMeshProUGUI uiText;
    int totalCoins;
    int coinsCollected;

    // Start is called before the first frame update
    void Start()
    {
        // get the extent of the collision box
        boxExtents = GetComponent<BoxCollider2D>().bounds.extents;
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
       
        // find out how many coins in the level
        coinsCollected = 0;
        totalCoins = GameObject.FindGameObjectsWithTag("Coin").Length;
    }

    // Update is called once per frame
    void Update()
    {
        string uiString = "x " + coinsCollected + "/" + totalCoins;
        uiText.text = uiString;

        float xSpeed = Mathf.Abs(rigidBody.velocity.x);
        animator.SetFloat("xSpeed", xSpeed); //for running animation

        float ySpeed = rigidBody.velocity.y;
        animator.SetFloat("ySpeed", ySpeed); //for jumping animation

        float blinkVal = Random.Range(0.0f, 200.0f);
        if (blinkVal < 1.0f)
            animator.SetTrigger("blinkTrigger"); //for blinking animation

        if (rigidBody.velocity.x * transform.localScale.x < 0.0f)
        {
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z); //sprite movement
        }

    }
    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        // check if we are on the ground
        Vector2 bottom =
        new Vector2(transform.position.x, transform.position.y - boxExtents.y);

        Vector2 hitBoxSize = new Vector2(boxExtents.x * 2.0f, 0.05f);

        RaycastHit2D result = Physics2D.BoxCast(bottom, hitBoxSize, 0.0f,
        new Vector3(0.0f, -1.0f), 0.0f, 1 << LayerMask.NameToLayer("Ground"));

        bool grounded = result.collider != null && result.normal.y > 0.9f;
        if (grounded)
        {
            if (Input.GetAxis("Jump") > 0.0f)
                rigidBody.AddForce(new Vector2(0.0f, jumpForce), ForceMode2D.Impulse);
            else
            {
                // allow a small amount of movement in the air
                float vx = rigidBody.velocity.x;
                if (h * vx < airControlMax)
                    rigidBody.AddForce(new Vector2(h * airControlForce, 0));
            }
        }
    }
    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Coin")
        {
            Destroy(coll.gameObject);
            coinSound.Play();
            coinsCollected++;
        }
    }
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Death")
        {
            SceneManager.LoadScene(0);
        }
    }

}