using UnityEngine;

public class NetTrigger : MonoBehaviour
{
    [SerializeField] BoxCollider2D boxCollider;
    [SerializeField] SpriteRenderer spriteRenderer;

    [SerializeField] AudioSource scoringDingsSource;
    [SerializeField] AudioClip positiveDing;
    [SerializeField] AudioClip negativeDing;

    void OnTriggerStay2D(Collider2D other)
    {
        SpriteRenderer ballRenderer = other.GetComponent<SpriteRenderer>();
        if (spriteRenderer == null) return;
        if (!other.gameObject.CompareTag("Ball")) return;

        Bounds net = boxCollider.bounds;
        Bounds ball = other.bounds;

        bool fullyInside =
            ball.min.x >= net.min.x && ball.max.x <= net.max.x &&
            ball.min.y >= net.min.y && ball.max.y <= net.max.y;

        if (!fullyInside) return;

        if (ballRenderer.color == spriteRenderer.color)
        {
            Debug.Log("You scored a point!");

            scoringDingsSource.PlayOneShot(positiveDing);
            GameManager.Instance?.UpdatePoints(1);

            Destroy(other.gameObject);
        }
        else
        {
            Debug.Log("You scored for the wrong team!");

            scoringDingsSource.PlayOneShot(negativeDing);
            GameManager.Instance?.UpdatePoints(-2);

            Destroy(other.gameObject);
        }
    }
}
