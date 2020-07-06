using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorShot : MonoBehaviour {

    public GameObject redExplosionPrefab;

    private HealthBar healthBar;

    void Start()
    {
        healthBar = FindObjectOfType<HealthBar>();
    }

    void Update ()
    {
        Destroy(this.gameObject, 3f);
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            healthBar.LoseHealth();

			AudioManager.explosion.Play();

            GameObject explosion = Instantiate(redExplosionPrefab, gameObject.transform.position, Quaternion.identity);
            Destroy(explosion, 0.5f);
            Destroy(this.gameObject);
        }

        if (collision.gameObject.tag == "missile"| collision.gameObject.tag == "barrier")
        {
            AudioManager.explosion.Play();

            GameObject explosion = Instantiate(redExplosionPrefab, gameObject.transform.position, Quaternion.identity);
            Destroy(explosion, 0.5f);
            Destroy(this.gameObject);
        }
    }
}
