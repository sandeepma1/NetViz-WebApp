using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiDesignCanvas : Singleton<UiDesignCanvas>
{
    [SerializeField] private GameObject floor;
    [SerializeField] private Button homeButton;
    [SerializeField] private Image mainImage;
    [SerializeField] private RectTransform mainCanvas;
    private GameObject mainPanel;
    private int roomId;

    protected override void Awake()
    {
        base.Awake();
        UiWelcomeCanvas.OnLoadRoomById += OnLoadRoomById;
        mainPanel = transform.GetChild(0).gameObject;
        ToggleThisScreen(false);
        homeButton.onClick.AddListener(OnHomeButtonClicked);
    }

    private void OnDestroy()
    {
        homeButton.onClick.RemoveListener(OnHomeButtonClicked);
        UiWelcomeCanvas.OnLoadRoomById -= OnLoadRoomById;
    }

    private void OnLoadRoomById(int id)
    {
        roomId = id;
        ToggleThisScreen(true);
        ProcessImage();
    }

    private void ProcessImage()
    {
        string spritePath = AppData.roomImagesPath + "" + roomId + AppData.originalName;
        print(spritePath);
        mainImage.sprite = Resources.Load<Sprite>(spritePath);
    }

    private void OnHomeButtonClicked()
    {
        ToggleThisScreen(false);
        UiWelcomeCanvas.Instance.ToggleWelcomeScreen(true);
    }

    public void ToggleThisScreen(bool showScreen)
    {
        mainPanel.gameObject.SetActive(showScreen);
        floor.SetActive(showScreen);
    }
}