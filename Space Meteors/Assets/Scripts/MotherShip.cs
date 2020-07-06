using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MotherShip : MonoBehaviour {

    private Transform enemyHolder;
    public float speed;
    public Text winText;
    public Text rLvlTxt;
    public GameObject shot;
    public float fireRate = .995f;
    public Button menuButton;

    public Image bar;
    public Image basebar;
    public int health = 10;
    public int maxHealth = 10;
    private readonly int damage = 1;
    public GameObject bigExplosionPrefab;

    void Start()
    {
        InvokeRepeating("MoveEnemy", .1f, .3f);
        enemyHolder = GetComponent<Transform>();

        bar.fillAmount = 1f * health / maxHealth;
    }

    void Update()
    {
        bar.fillAmount = 1f * health / maxHealth;

        if (health == 0f)
        {
            KillMShip();
        }
    }

    public void LoseHealth()
    {
        health = health - damage;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "missile")
        {
            LoseHealth();
        }
    }

    private void KillMShip()
    {
        AudioManager.boom.Play();
        GameObject explosion = Instantiate(bigExplosionPrefab, gameObject.transform.position, Quaternion.identity);
        Destroy(explosion, 0.5f);
        Destroy(this.gameObject);

        basebar.gameObject.SetActive(false);
        bar.gameObject.SetActive(false);

        winText.gameObject.SetActive(true);
        rLvlTxt.gameObject.SetActive(true);
    }

    void MoveEnemy()
    {
        enemyHolder.position += Vector3.right * speed;

        foreach (Transform enemy in enemyHolder)
        {
            if (enemy.position.x < -4.5 || enemy.position.x > 4.5)
            {
                speed = -speed;
                enemyHolder.position += Vector3.down * 0.5f;
                return;
            }

            if (Random.value > fireRate)
            {
                Instantiate(shot, enemy.position, enemy.rotation);
            }
        }

        if (enemyHolder.childCount == 1)
        {
            CancelInvoke();
            InvokeRepeating("MoveEnemy", .1f, .25f);
        }

        if (enemyHolder.childCount == 0)
        {
            Time.timeScale = 0;

            winText.gameObject.SetActive(true);
            rLvlTxt.gameObject.SetActive(true);
            menuButton.gameObject.SetActive(true);
        }
    }
}
