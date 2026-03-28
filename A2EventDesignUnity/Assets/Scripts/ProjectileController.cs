using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ProjectileController : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    PlayerController controller;
    BouncePad bouncePad;
    Vector3 direction;
    public float speed = 1;

    public Material normal;
    public Material fire;
    public Material ice;

    public string status = "normal";

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        controller = FindObjectOfType<PlayerController>();

        CheckDirection();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += direction;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "BouncePad")
        {
            bouncePad = collision.GetComponent<BouncePad>();

            controller.direction = bouncePad.direction;
            CheckDirection();
        }
    }

    //Changes direction of arow when needed
    public void CheckDirection()
    {
        if (controller.direction == ("North"))
        {
            direction = new Vector3(0f, speed, 0f);
        }
        else if (controller.direction == ("South"))
        {
            direction = new Vector3(0f, -speed, 0f);
        }
        else if (controller.direction == ("West"))
        {
            direction = new Vector3(-speed, 0f, 0f);
        }
        else if (controller.direction == ("East"))
        {
            direction = new Vector3(speed, 0f, 0f);
        }
    }

    //Changes normal arrows to fire, ice arrows to normal
    public void ChangeArrowFire()
    {
        if (gameObject.tag == "Normal")
        {
            spriteRenderer.material = fire;
            Debug.Log("works");
            gameObject.tag = "Fire";
            status = "fire";
        }
        else if (gameObject.tag == "Ice")
        {
            spriteRenderer.material = normal;
            gameObject.tag = "Normal";
            status = "normal";
        }
    }

    //Changes normal arrows to ice, fire arrows to normal
    public void ChangeArrowIce()
    {
        if (gameObject.tag == "Normal")
        {
            spriteRenderer.material = ice;
            gameObject.tag = "Ice";
            status = "ice";
        }
        else if (gameObject.tag == "Fire")
        {
            spriteRenderer.material = normal;
            gameObject.tag = "Normal";
            status = "normal";
        }
    }

    public void EndGame()
    {
        if (gameObject.tag == "Normal")
        {
            SceneManager.LoadScene("Game Over");
        }
    }
}
