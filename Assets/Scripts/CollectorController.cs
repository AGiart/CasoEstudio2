using System.Collections.Generic;
using UnityEngine;

public class CollectorController : MonoBehaviour
{
    private IDictionary<CollectibleType, float> _collectibles;

    private void Awake()
    {
        _collectibles = new Dictionary<CollectibleType, float>();
    }

    public void Increase(CollectibleType collectibleType, float value)
    {
        if (_collectibles.ContainsKey(collectibleType))
        {
            _collectibles[collectibleType] += Mathf.Abs(value);
        }
        else
        {
            _collectibles.Add(collectibleType, Mathf.Abs(value));
        }

        CollectibleManager.Instance.UpdateTextbox(collectibleType, _collectibles[collectibleType]);
    }

    public void Decrease(CollectibleType collectibleType, float value)
    {
        if (!_collectibles.ContainsKey(collectibleType))
        {
            return;
        }

        _collectibles[collectibleType] -= Mathf.Abs(value);
        if (_collectibles[collectibleType] <= 0)
        {
            _collectibles.Remove(collectibleType);
            CollectibleManager.Instance.UpdateTextbox(collectibleType, 0);
            return;
        }

        CollectibleManager.Instance.UpdateTextbox(collectibleType, _collectibles[collectibleType]);
    }
}
