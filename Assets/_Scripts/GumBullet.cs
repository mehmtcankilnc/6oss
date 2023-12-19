using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GumBullet : MonoBehaviour
{
    public float speed;
    public float gumDamage;
    private Transform player;
    private Vector2 target;
   
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        target = new Vector2(player.position.x, player.position.y);
    }

   
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
        
        if(transform.position.x == target.x && transform.position.y == target.y)
        {
            DestroyBullet();
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            DestroyBullet();
            other.GetComponent<healthManager>().TakeDamage(gumDamage);
        }
        
    }
    void DestroyBullet()
    {
        Destroy(gameObject);
    }
}
