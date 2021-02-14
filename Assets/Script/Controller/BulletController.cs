using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D hitEnemy;
    private Rigidbody2D rb2d;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.velocity = new Vector2(0, GameManager.instance.speedBullet);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("obstacle"))
        {
            SoundManager.instance.GetComponent<AudioSource>().PlayOneShot(SoundManager.instance.hitSound);
            HitEffect(other);
        }

        if (other.gameObject.CompareTag("enemy"))
        {
            SoundManager.instance.GetComponent<AudioSource>().PlayOneShot(SoundManager.instance.hitSound);
            HitEffect(other);
            GameManager.instance.score += 2;
        }
    }

    private void HitEffect(Collider2D other)
    {
        Rigidbody2D clone;
        clone = Instantiate(hitEnemy, transform.position, transform.rotation) as Rigidbody2D;
        Destroy(clone.gameObject, 0.1f);
        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}
