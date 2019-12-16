using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A)) {
            gameObject.transform.Translate(Vector2.left * 5 * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            gameObject.transform.Translate(Vector2.right * 5 * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.W))
        {
            gameObject.transform.Translate(Vector2.up * 5 * Time.deltaTime);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Gold") {
            Destroy(gameObject);
            
        }
    }
}
