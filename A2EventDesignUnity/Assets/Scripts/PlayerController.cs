using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;
    private float moveSpeed = 3;
    public Camera cam;
    private bool isAlive;
    public string direction = ("North");
    public GameObject projectile;
    int Pnumber = 0;

    // Start is called before the first frame update
    void Start()
    {
        direction = ("North");
    }

    // Update is called once per frame
    void Update()
    {
        // Movement
        float moveInputX = Input.GetAxis("Horizontal");
        float moveInputY = Input.GetAxis("Vertical");

        rb.velocity = new Vector2(moveInputX * moveSpeed, moveInputY * moveSpeed);

        //Restart function
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("SampleScene");
        }

        //Records what way the player character is facing
        if (Input.GetKeyDown(KeyCode.W))
        {
            direction = ("North");
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            direction = ("East");
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            direction = ("South");
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            direction = ("West");
        }

        //Projectile input
        if (Input.GetKeyDown(KeyCode.Space) && Pnumber < 1)
        {
            Instantiate(projectile, transform.position, transform.rotation);
            Pnumber++;
        }

    }
}
