using System;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.InputSystem;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float velocidad = 5f, jumpForce = 15f;
    [SerializeField] int coins = 0;
    [SerializeField] bool isOnFloor = false, isDead = false, hasKey = false;
    [SerializeField] Animator animator;
    private Rigidbody2D rb;
    [SerializeField] LayerMask layer;
    [SerializeField] SpriteRenderer spr;
    [SerializeField] ShadowCaster2D shadowCaster2D;
    [SerializeField] Vector2 jumpBox, jumpBoxSize;
    [SerializeField] ParticleSystem explode;

    void Start()
    {
        rb = transform.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        if (isDead) return;

        if (Physics2D.Raycast(transform.position, new Vector2(Input.GetAxis("Horizontal"), 0), .5f, layer))
        {
            Debug.Log("Colisión");
            velocidad = 2;
        }
        else
        {
            velocidad = 5;
        }

        float velocidadH = Input.GetAxis("Horizontal") * velocidad * Time.deltaTime;
        animator.SetFloat("isMove", Mathf.Abs(Input.GetAxis("Horizontal") * velocidad));
        Vector2 center = (Vector2)transform.position + jumpBox;
        isOnFloor = Physics2D.OverlapBox(center, jumpBoxSize, 0, layer) ? true : false; ;
        animator.SetBool("isJump", !isOnFloor);

        if (Input.GetKeyDown(KeyCode.X) && isOnFloor)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0f);
            rb.AddForceY(jumpForce, ForceMode2D.Impulse);
            AudioController.instance.PlaySound(AudioController.instance.jump);
        }


        if (velocidadH > 0)
        {
            spr.flipX = false;
        }
        if (velocidadH < 0)
        {
            spr.flipX = true;
        }
        Vector3 movimiento = transform.position;
        transform.position = new Vector3(movimiento.x + velocidadH, movimiento.y, movimiento.z);
    }
    private void AddCoin()
    {
        AudioController.instance.PlaySound(AudioController.instance.coin);
        coins++;
        CanvasManager.instance.UpdateCoins(coins);
    }
    private void OnDead()
    {
        isDead = true;
        spr.enabled = false;
        explode.Play();
        shadowCaster2D.enabled = false;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = isOnFloor ? Color.green : Color.red;
        Vector2 center = (Vector2)transform.position + jumpBox;
        Gizmos.DrawWireCube(center, jumpBoxSize);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {
            AddCoin();
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("Key"))
        {
            AudioController.instance.PlaySound(AudioController.instance.key);
            hasKey = true;
            Puerta.instance.SetDoorState(true);
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("Door"))
        {
            if (hasKey)
            {
                CanvasManager.instance.Win();
                AudioController.instance.PlaySound(AudioController.instance.win);
                OnDead();
            }
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (isDead) return;
            CanvasManager.instance.Gameover(true);
            AudioController.instance.PlaySound(AudioController.instance.die);
            AudioController.instance.PlaySound(AudioController.instance.lose);
            OnDead();
        }
    }

}