using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Koopa : MonoBehaviour
{
    public Sprite shellSprite;

    private bool shelled;
    private bool pushed;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(shelled && other.gameObject.CompareTag("Player"))
        {
            if (!pushed)
            {
                Vector2 direction = new Vector2(transform.position.x - other.transform.position.x, 0f);
                PushShell(direction);
            }
            else
            {
                Player player = other.gameObject.GetComponent<Player>();
                player.Hit();
            }
        }
    }

    private void PushShell(Vector2 direction)
    {
        pushed = true;

        GetComponent<Rigidbody2D>().isKinematic = false;
        EntityMovement entityMovement = GetComponent<EntityMovement>();
        entityMovement.direction = direction.normalized;
        entityMovement.speed = 12f;
        entityMovement.enabled = true;

        gameObject.layer = LayerMask.NameToLayer("Shell");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!shelled && collision.gameObject.CompareTag("Player"))
        {
            Player player = collision.gameObject.GetComponent<Player>();
            if (collision.transform.DotTest(transform, Vector2.down))
            {
                EnterShell();
            }
            else
            {
                player.Hit();
            }
        }
        else if(!shelled && collision.gameObject.layer == LayerMask.NameToLayer("Shell")){
            Hit();
        }
    }

    private void EnterShell()
    {
        shelled = true;
        GetComponent<EntityMovement>().enabled = false;
        GetComponent<AnimatedSprites>().enabled = false;
        GetComponent<SpriteRenderer>().sprite = shellSprite;
    }

    private void Hit()
    {
        GetComponent<AnimatedSprites>().enabled = false;
        GetComponent<DeathAnimation>().enabled = true;
        Destroy(gameObject, 3f);
    }
}
