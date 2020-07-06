using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject explosionPrefab;
    public AudioSource tickSource;

    public HealthBar scoreCounter;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "missile")
        {
            scoreCounter.ScoreCounter();

            tickSource.Play();

            GameObject explosion = Instantiate(explosionPrefab, gameObject.transform.position, Quaternion.identity);

            Destroy(explosion, 0.5f);
            Destroy(this.gameObject);

        }
    }
}

