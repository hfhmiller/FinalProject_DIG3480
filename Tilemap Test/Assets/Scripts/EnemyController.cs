using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    private bool dirRight = true;
    public float speed = 2.0f;
    private float xPosition;

    private void Start()
    {
        xPosition = this.transform.position.x;
    }

    void Update()
    {
        if (dirRight)
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        else
            transform.Translate(-Vector2.right * speed * Time.deltaTime);

        if (transform.position.x >= xPosition + 2)
        {
            dirRight = false;
            Flip();
        }

        if (transform.position.x <= xPosition - 2)
        {
            dirRight = true;
            Flip();
        }
    }

    void Flip()
    {
        Vector2 Scaler = transform.localScale;
        Scaler.x = Scaler.x * -1;
        transform.localScale = Scaler;
    }
}
