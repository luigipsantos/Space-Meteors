using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EnemyController : MonoBehaviour {

    private Transform enemyHolder;
    public float speed;
    public Text winText;
    public Text rLvlTxt;
    public GameObject shot;
    public float fireRate = .995f;
    public Button menuButton;
    public Button level2Button;

    void Start ()
    {
        InvokeRepeating("MoveEnemy", .1f, .3f);
        enemyHolder = GetComponent<Transform>();
	}
	
	void MoveEnemy ()
    {
        enemyHolder.position += Vector3.right * speed;

        foreach (Transform enemy in enemyHolder)
        {
            if (enemy.position.x < -5.5 || enemy.position.x > 5.5)
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
            level2Button.gameObject.SetActive(true);
        }
	}
}
