using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Pull", menuName = "Create New Object Pull", order = 1)]
public class ZoneObjectPull : ScriptableObject
{
    [SerializeField] private tmp[] _tmps;

    public void Init()
    {
        for (int i = 0; i < _tmps.Length; i++)
        {
            _tmps[i].ResetCounter();
        }
    }

    public bool TryGetObjectFromPull(out GameObject zoneObject)
    {
        for (int i = 0; i < _tmps.Length; i++)
        {
            if (_tmps[i].TryGetSprite(out Sprite sprite))
            {
                zoneObject = new GameObject();

                var spriteRenderer = zoneObject.AddComponent<SpriteRenderer>();

                spriteRenderer.sprite = sprite;

                spriteRenderer.sortingOrder = i;

                return true;
            }
        }

        zoneObject = null;

        return false;
    }
}

[System.Serializable]
public struct tmp
{
    public Sprite Sprite;
    public int MaxCount;
    private int Count;

    public void ResetCounter()
    {
        Count = 0;
    }

    public bool TryGetSprite(out Sprite sprite)
    {
        if (Count >= MaxCount)
        {
            sprite = null;

            return false;
        }

        Count++;
        sprite = Sprite;

        return true;
    }
}