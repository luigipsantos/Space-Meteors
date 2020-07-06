using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

    private Transform player;
    public float speed;
    public float maxBound, minBound;

    public Transform shootPosition;
    public GameObject projetil;
    public float tempoDeVida = .25f;
    private float myTime = 0.0f;
    private float nextFire = 0.5f;
    public float fireDelta = 0.5f;

    public Text gameOverTxt;
    public Text rLvlTxt;

    public GameObject lazer;

    void Start ()
    {
        player = GetComponent<Transform>();
    }

    public void LazerActivator()
    {
        lazer.gameObject.SetActive(true);
    }

    void Update()
    {
        float h = Input.GetAxis("Horizontal");

        if (player.position.x < minBound && h < 0){
            h = 0;
        }
        else if (player.position.x > maxBound && h > 0){
            h = 0;
        }

        player.position += Vector3.right * h * speed;

        myTime = myTime + Time.deltaTime;

        if (Input.GetKey(KeyCode.Space) && myTime > nextFire)
        {
            nextFire = myTime + fireDelta;
            Disparar();
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            lazer.gameObject.SetActive(true);
        }
    }

    void Disparar()
    {
        GameObject novoProjetil = Instantiate(projetil, shootPosition.position, shootPosition.rotation);
        Destroy(novoProjetil, tempoDeVida);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "meteor")
        {
            Destroy(this.gameObject, 0f);

            gameOverTxt.gameObject.SetActive(true);
            rLvlTxt.gameObject.SetActive(true);

            Time.timeScale = 0;
        }

    }

}
