using UnityEngine;

public class LaunchIndicator : MonoBehaviour
{
    void Awake()
    {
        Destroy(gameObject, 3.0f);
    }
}
