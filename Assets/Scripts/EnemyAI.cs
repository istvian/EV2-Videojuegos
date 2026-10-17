using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] Vector2 a, b;
    [SerializeField] float speed;
    [SerializeField] SpriteRenderer sprite;
    [SerializeField] bool isRight;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        a = transform.GetChild(0).GetComponent<Transform>().position;
        b = transform.GetChild(1).GetComponent<Transform>().position;
    }

    // Update is called once per frame
    void Update()
    {
        float velocidadH = (isRight ? 1 : -1) * speed * Time.deltaTime;
        if (velocidadH > 0)
        {
            sprite.flipX = true;
        }
        if (velocidadH < 0)
        {
            sprite.flipX = false;
        }
        transform.position = new Vector3(transform.position.x + velocidadH, transform.position.y, transform.position.z);
        if (transform.position.x <= a.x)
        {
            isRight = true;
        }
        if (transform.position.x >= b.x)
        {
            isRight = false;
        }

    }
}
