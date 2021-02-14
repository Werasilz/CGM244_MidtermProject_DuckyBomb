using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private float speed = 5;
    private int starCount;
    private Rigidbody2D rb2d;
    private Animator anim;
    private SpriteRenderer spriteRenderer;
    [SerializeField] private GameObject hitEffect;
    [SerializeField] private GameObject bullet;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        AddBullet();
        ShootBullet();
    }

    void FixedUpdate()
    {
        Movement();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("obstacle") || other.gameObject.CompareTag("enemy") || other.gameObject.CompareTag("wall"))
        {
            SoundManager.instance.GetComponent<AudioSource>().PlayOneShot(SoundManager.instance.hitSound);
            anim.SetTrigger("isHurt" + SelectPlayerSprite.spriteID);

            EnableHitEffect();

            GameManager.instance.OnGameOver();
        }

        if (other.gameObject.CompareTag("star"))
        {
            SoundManager.instance.GetComponent<AudioSource>().PlayOneShot(SoundManager.instance.scoreSound);
            starCount += 1;
            GameManager.instance.score += 1;
            Destroy(other.gameObject);
        }
    }

    private void EnableHitEffect()
    {
        hitEffect.SetActive(true);
        Invoke("DisableHitEffect", 0.3f);
    }

    private void DisableHitEffect()
    {
        hitEffect.SetActive(false);
        Time.timeScale = 0;
    }

    private void ShootBullet()
    {
        if (Input.GetKeyDown(KeyCode.Space) && GameManager.instance.bulletRound >= 1 && !GameManager.instance.isGameOver)
        {
            GameManager.instance.bulletRound -= 1;
            Instantiate(bullet, transform.position, Quaternion.Euler(0, 0, -180));
        }
    }

    private void AddBullet()
    {
        if (starCount == 3)
        {
            GameManager.instance.bulletRound += 1;
            starCount = 0;
        }
    }

    private void Movement()
    {
        if (!GameManager.instance.isGameOver)
        {
            float horizontal = Input.GetAxis("Horizontal");
            Vector2 movement = new Vector2(horizontal, 0);
            Vector2 newPos = new Vector2(transform.position.x, transform.position.y);
            newPos = newPos + movement * speed * Time.deltaTime;

            rb2d.MovePosition(newPos);

            anim.SetTrigger("isFly" + SelectPlayerSprite.spriteID);

            if (horizontal < 0)
            {
                spriteRenderer.flipX = true;
            }
            else if (horizontal > 0)
            {
                spriteRenderer.flipX = false;
            }
        }
    }
}
