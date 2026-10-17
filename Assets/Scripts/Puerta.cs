using Unity.VisualScripting;
using UnityEngine;

public class Puerta : MonoBehaviour
{

    public static Puerta instance;
    [SerializeField] SpriteRenderer spriteRenderer;
    private Collider2D col;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {
        col = GetComponent<Collider2D>();
        SetDoorState(false);
    }
    public void SetDoorState(bool isUnlocked)
    {
        if (isUnlocked)
        {
            spriteRenderer.color = Color.green;
            col.enabled = true;
        }
        else
        {
            spriteRenderer.color = Color.gray;
            col.enabled = false;
        }
    }
}
