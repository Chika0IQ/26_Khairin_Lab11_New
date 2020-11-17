using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float rotatespeed;
    public float damageRate;
    public float health;
    bool dead = false;

    public GameObject healthText;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
    }

    void PlayerMovement() // Movement of Player and Main Gameplay
    {
        if (!dead)
        {
            //Forward Movement
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            {
                transform.Translate(Vector3.forward * Time.deltaTime * speed);
                transform.rotation = Quaternion.Euler(0, 0, 0);
                animator.SetBool("isWalk", true);
            }

            //Left Movement
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                transform.Translate(Vector3.forward * Time.deltaTime * speed);
                transform.rotation = Quaternion.Euler(0, 270, 0);
                animator.SetBool("isWalk", true);
            }

            //Backward Movement
            if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            {
                transform.Translate(Vector3.forward * Time.deltaTime * speed);
                transform.rotation = Quaternion.Euler(0, 180, 0);
                animator.SetBool("isWalk", true);
            }

            //Right Movement
            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                transform.Translate(Vector3.forward * Time.deltaTime * speed);
                transform.rotation = Quaternion.Euler(0, 90, 0);
                animator.SetBool("isWalk", true);
            }

            //No Key Pressed
            if (Input.anyKey == false)
            {
                animator.SetBool("isWalk", false);
            }

            //Attack Trigger
            if (Input.GetKeyDown(KeyCode.Space))
            {
                animator.SetTrigger("AttackTrigger");
            }
        }
    }
    private void OnTriggerEnter(Collider other) // Trigger on Fire Cube
    {
        if (other.gameObject.tag == "Fire")
        {
            health -= damageRate * Time.deltaTime;
            healthText.GetComponent<Text>().text = "Health:" + health;
        }
    }

    private void OnTriggerStay(Collider other) //Health 0, Trigger Death Animation, set Dead to True
    {
        if (health <= 0)
        {
            animator.SetTrigger("DeadTrigger");
            dead = true;
        }
    }
}
