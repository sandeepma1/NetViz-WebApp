using System;
using UnityEngine;
using UnityEngine.UI;

public class UiRoomButton : MonoBehaviour
{
    public Action<int> OnRoomButtonPressed;
    public int id;
    private Button button;

    private void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnButtonPressed);
    }

    private void OnDestroy()
    {
        button.onClick.RemoveListener(OnButtonPressed);
    }

    private void OnButtonPressed()
    {
        OnRoomButtonPressed?.Invoke(id);
    }
}