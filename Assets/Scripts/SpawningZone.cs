using UnityEngine;

public class SpawningZone : MonoBehaviour
{
    [SerializeField] private ZoneObjectPull pull;

    private void Start()
    {
        pull.Init();
    }

    public void Spawn(Vector2 position)
    {
        if (pull.TryGetObjectFromPull(out GameObject zoneObject))
        {
            zoneObject.transform.position = position;
            zoneObject.transform.parent = transform;
            zoneObject.GetComponent<SpriteRenderer>().sortingLayerID = GetComponent<SpriteRenderer>().sortingLayerID;
        }
    }
}
