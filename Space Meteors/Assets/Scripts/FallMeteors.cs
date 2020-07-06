using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallMeteors : MonoBehaviour {

    public GameObject shot;
    public float fireRate = .995f;

    private Transform enemyHolder;

    void Start()
    {
        enemyHolder = GetComponent<Transform>();
    }

    void Update ()
    {
        foreach (Transform enemy in enemyHolder)
        {
            if (Random.value > fireRate)
            {
                Instantiate(shot, enemy.position, enemy.rotation);
            }
        }
    }
}
