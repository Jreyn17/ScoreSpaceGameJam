using UnityEngine;

public class NetTrigger : MonoBehaviour
{
    [SerializeField] BoxCollider2D boxCollider;
    [SerializeField] SpriteRenderer spriteRenderer;

    void OnTriggerEnter2D(Collider2D other)
    {
        SpriteRenderer ballRenderer = other.GetComponent<SpriteRenderer>();
        if (spriteRenderer == null) return;
        if (!other.gameObject.CompareTag("Ball")) return;

        if (ballRenderer.color == spriteRenderer.color)
        {
            Debug.Log("You scored a point!");

            GameManager.Instance?.UpdatePoints(1);

            Destroy(other.gameObject);
        }
        else
        {
            Debug.Log("You scored for the wrong team!");

            GameManager.Instance?.UpdatePoints(-1);

            Destroy(other.gameObject);
        }
    }
}
