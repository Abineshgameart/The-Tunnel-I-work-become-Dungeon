using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatEnemy : MonoBehaviour
{
    // Private
    private Transform Player;
    float timer;

    // Public
    public float speed;
    public float lineOfSite;
    public float shootingRange;
    public float attackTime;
    public GameObject sonicBeam;
    public Transform sonicBeamparent;
    
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        float distanceFromPlayer = Vector2.Distance(Player.position, transform.position);
        if (distanceFromPlayer < lineOfSite && distanceFromPlayer > shootingRange)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, Player.position, speed * Time.deltaTime);
        }
        else if (distanceFromPlayer <= shootingRange) {
            timer += Time.deltaTime;

            if (timer > attackTime)
            {
                timer = 0;
                Shoot();
            }

        }
            
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, lineOfSite);
        Gizmos.DrawWireSphere(transform.position, shootingRange);
    }

    void Shoot()
    {
        Instantiate(sonicBeam, sonicBeamparent.position, Quaternion.identity);
    }

}
