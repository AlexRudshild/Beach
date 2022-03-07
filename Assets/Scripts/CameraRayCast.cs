using UnityEngine;

public class CameraRaycast : MonoBehaviour
{
    public GameObject sprite;

    private Camera _camera;

    void Start()
    {
        _camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Spawn();
        }
    }

    private void Spawn()
    {
        var ray = _camera.ScreenPointToRay(Input.mousePosition);

        var hit = Physics2D.RaycastAll(ray.origin, ray.direction, 20);

        if (hit.Length > 0)
        {
            int i = hit.Length - 1;

            if (hit[i].transform.TryGetComponent(out SpawningZone spawningZone))
            {
                spawningZone.Spawn(hit[i].point);
            }

            return;
        }
    }
}