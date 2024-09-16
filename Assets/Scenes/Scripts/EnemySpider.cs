using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpider : MonoBehaviour
{
    // Private
    float timer;
    GameObject player;

    // Public
    public GameObject web;
    public Transform webPos;
    public float attackTime;
    public float playerDistance;
    public float shootDistance;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector2.Distance(transform.position, player.transform.position);

        if (distance < playerDistance && distance > shootDistance)
        {
            timer += Time.deltaTime;

            if (timer > attackTime)
            {
                timer = 0;
                Shoot();
            }
        } 
    }


    void Shoot()
    {
        Instantiate(web, webPos.position, Quaternion.identity);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, shootDistance);
        Gizmos.DrawWireSphere(transform.position, playerDistance);
    }


}
