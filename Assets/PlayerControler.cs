using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    private float forwardInput;
    private float verticalInput;
    private float speed = 3.0f;
    private float jumpSpeed = 5.0f;
    private Animator animator;
    public EndGame endGameScript;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        forwardInput = Input.GetAxis("Horizontal");
        if (Input.GetKey(KeyCode.Space))
        {
            verticalInput = 1.0f;
        }
        else
        {
            verticalInput = 0.0f;
        }
        // Move the cat forward
        transform.Translate(Vector3.right * Time.deltaTime * speed * forwardInput);
        // Jump the cat
        transform.Translate(Vector3.up * verticalInput * jumpSpeed * Time.deltaTime);

        // Set the Speed parameter
        animator.SetFloat("Speed", Mathf.Abs(forwardInput));

        // flip the cat
        if (forwardInput < 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else if (forwardInput > 0)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
    }

    void CollectFruit(GameObject fruit)
    {
        // Add points to the score.
        ScoreManager.instance.AddScore(1);


        // Destroy the fruit.
        Destroy(fruit);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Fruit"))
        {
            // If the cat collides with a fruit, collect it and remove it from the scene.
            CollectFruit(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("House"))
        {
            animator.SetTrigger("Lay");
            endGameScript.ShowBirthdayMessage();
        }
    }
}
