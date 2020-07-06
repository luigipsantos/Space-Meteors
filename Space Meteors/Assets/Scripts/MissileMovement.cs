using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileMovement : MonoBehaviour {

    public float speed = 4.0f;

    public GameObject lazerExplosionPrefab;

    void Update ()
    {
        transform.position = transform.position + transform.up * speed * Time.deltaTime;
        Destroy(this.gameObject, 2.5f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "meteor")
        {
            GameObject lazerExp = Instantiate(lazerExplosionPrefab, gameObject.transform.position, Quaternion.identity);
            Destroy(lazerExp, 0.5f);
            Destroy(this.gameObject);
        }
        if (collision.gameObject.tag == "barrier")
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "meteormissile")
        {
			AudioManager.explosion.Play();

            GameObject lazerExp = Instantiate(lazerExplosionPrefab, gameObject.transform.position, Quaternion.identity);
            Destroy(lazerExp, 0.5f);
            Destroy(this.gameObject);
        }

        if (collision.gameObject.tag == "gun")
        {
			AudioManager.explosion.Play();

            GameObject lazerExp = Instantiate(lazerExplosionPrefab, gameObject.transform.position, Quaternion.identity);
            Destroy(lazerExp, 0.5f);
            Destroy(this.gameObject);
        }
    }
}
