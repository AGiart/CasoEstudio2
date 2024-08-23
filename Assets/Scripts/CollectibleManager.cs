using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CollectibleManager : MonoState<CollectibleManager>
{
    [SerializeField]
    CollectibleUI[] collectibles;

    IDictionary<CollectibleType, TextMeshProUGUI> _textboxes;

    protected override void Awake()
    {
        base.Awake();

        _textboxes = new Dictionary<CollectibleType, TextMeshProUGUI>();
        foreach (var collectible in collectibles)
        {
            _textboxes.Add(collectible.GetCollectibleType(), collectible.GetTextbox());
        }
    }

    public void UpdateTextbox(CollectibleType collectibleType, float value, string format = "0.00")
    {
        if (!_textboxes.ContainsKey(collectibleType))
        {
            return;
        }

        TextMeshProUGUI textbox = _textboxes[collectibleType];
        textbox.text = value.ToString(format);
    }
}
