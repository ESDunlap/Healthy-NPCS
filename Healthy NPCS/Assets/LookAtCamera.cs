using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    private void Start()
    {
        _camera = FindAnyObjectByType<Camera>();
    }
    void Update()
    {
        Vector3 lookPosition = new Vector3(_camera.transform.position.x,
            transform.position.y,
            _camera.transform.position.z);
        transform.LookAt(lookPosition);
        Debug.Log(lookPosition);
    }
}
