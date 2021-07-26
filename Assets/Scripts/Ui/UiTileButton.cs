using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiTileButton : MonoBehaviour
{
    public Action<int> OnTileButtonClicked;
    private Image iconImage;
    private int id;
    private Button button;

    public void InitTile(int id, Sprite sprite)
    {
        iconImage = GetComponent<Image>();
        button = GetComponent<Button>();
        this.id = id;
        iconImage.sprite = sprite;
        button.onClick.AddListener(OnTileButtonPress);
    }

    public void SetTileSelector(Transform selector)
    {
        selector.SetParent(this.transform);
        selector.localPosition = Vector3.zero;
    }

    private void OnDestroy()
    {
        button.onClick.RemoveListener(OnTileButtonPress);
    }

    private void OnTileButtonPress()
    {
        OnTileButtonClicked?.Invoke(id);
    }
}
