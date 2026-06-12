using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform target;

    private void LateUpdate()
    {
        if (target == null)
        {
            return;
        }

        Vector3 position = transform.position;
        position.x = target.position.x;
        transform.position = position;
    }
}
