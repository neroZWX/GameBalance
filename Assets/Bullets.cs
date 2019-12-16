using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullets : MonoBehaviour
{
    public float Speed = 20F;
    public int Rdamage = 50;
    public int RifleLessDamage = 5;
    public LayerMask layerMask;
    public GameObject BulletEffect;
    public Rigidbody2D rd;
    private Enemy enemy;
    // Start is called before the first frame update
    void Start()
    {
        rd.velocity = transform.right * Speed;
        
        
    }
     void OnTriggerEnter2D(Collider2D hitInfo)
    {
        enemy = hitInfo.transform.GetComponent<Enemy>();
        if (enemy != null)
        {
            if (enemy.gameObject.layer == 9)
                enemy.TakeDamage(Rdamage);
               
            if(enemy.gameObject.layer == 8)
                enemy.TakeDamage(RifleLessDamage);
                print("Please use laser!");

        }
        Instantiate(BulletEffect,hitInfo.transform.position, Quaternion.identity);
        Destroy(gameObject);
    }


}
