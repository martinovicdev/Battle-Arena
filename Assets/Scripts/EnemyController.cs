using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 0.5f;
    public float axis = 1;
    

    void Start()
    {
        axis = Random.Range(-1.0f, 1.0f);
    }

    void Update()
    {
        float translation = axis * speed;
        translation *= Time.deltaTime;
        transform.Translate(translation, 0, 0);
    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag.Equals("WALL"))
        {
            axis *= -1;
            transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
        }
    }
}
