using UnityEngine;

public class Pulse : MonoBehaviour
{
    [SerializeField] private float speed = 6f;
    [SerializeField] private float amount = 0.15f;

    private Vector3 startScale;

    void Awake()
    {
        startScale = transform.localScale;
    }

    void Update()
    {
        float s = 1f + Mathf.Sin(Time.time * speed) * amount;
        transform.localScale = startScale * s;
    }
}
