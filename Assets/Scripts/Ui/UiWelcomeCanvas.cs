using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiWelcomeCanvas : Singleton<UiWelcomeCanvas>
{
    public static Action<int> OnLoadRoomById;
    [SerializeField] private GameObject contentParent;
    [SerializeField] private UiRoomButton[] roomButtons;
    private GameObject mainPanel;

    private void Start()
    {
        mainPanel = transform.GetChild(0).gameObject;
        InitRoomButton();
        ToggleWelcomeScreen(true);
    }

    private void InitRoomButton()
    {
        roomButtons = contentParent.transform.GetComponentsInChildren<UiRoomButton>();
        for (int i = 0; i < roomButtons.Length; i++)
        {
            roomButtons[i].id = i;
            roomButtons[i].OnRoomButtonPressed += OnRoomButtonPressed;
        }
    }

    private void OnRoomButtonPressed(int roomId)
    {
        ToggleWelcomeScreen(false);
        print(roomId);
        OnLoadRoomById?.Invoke(roomId);
    }

    public void ToggleWelcomeScreen(bool showScreen)
    {
        mainPanel.gameObject.SetActive(showScreen);
    }
}
