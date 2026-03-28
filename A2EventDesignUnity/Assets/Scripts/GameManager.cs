using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    PlayerController controller;
    ProjectileController projectile;
    BouncePad bouncePad;

    public UnityEvent OnArrowLitFire;
    public UnityEvent OnArrowLitIce;
    public UnityEvent onTorchLit;
    public UnityEvent OnBounce;


    //Event stuff
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "FireTorch")
        {
            OnArrowLitFire.Invoke();
        }

        if (collision.gameObject.tag == "IceTorch")
        {
            OnArrowLitIce.Invoke();
        }

        //Here's the thing, the tag is "unlit" as if it needs a fire arrow, but it actually needs a normal arrow as indicated in the projectile script. Oops!
        if (collision.gameObject.tag == "Unlit")
        {
            onTorchLit.Invoke();
        }
    }
}
