using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiTilesManager : Singleton<UiTilesManager>
{
    [SerializeField] private UiTileButton uiTileButtonPrefab;
    [SerializeField] private Renderer floorRenderer;
    [SerializeField] private Transform contentParent;
    [SerializeField] private Transform tileSelector;
    [SerializeField] private Button viewProductsButton;
    [SerializeField] private Button closeProductsButton;
    [SerializeField] private GameObject mainScrollList;
    private List<UiTileButton> uiTileButtons = new List<UiTileButton>();

    private void Start()
    {
        viewProductsButton.onClick.AddListener(OnViewProductsButtonClicked);
        closeProductsButton.onClick.AddListener(OnCloseProductsButtonClicked);
        ToggleUiTilesManager(false);
        InitTiles();
    }

    private void OnDestroy()
    {
        viewProductsButton.onClick.RemoveListener(OnViewProductsButtonClicked);
        closeProductsButton.onClick.RemoveListener(OnCloseProductsButtonClicked);
    }

    private void OnCloseProductsButtonClicked()
    {
        ToggleUiTilesManager(false);
    }

    private void OnViewProductsButtonClicked()
    {
        ToggleUiTilesManager(true);
    }

    private void InitTiles()
    {
        Sprite[] tileSprites = Resources.LoadAll<Sprite>(AppData.tilesThumbnailsPath);
        for (int i = 0; i < tileSprites.Length; i++)
        {
            UiTileButton uiTileButton = Instantiate(uiTileButtonPrefab, contentParent);
            uiTileButton.InitTile(i, tileSprites[i]);
            uiTileButton.OnTileButtonClicked += OnTileButtonClicked;
            uiTileButtons.Add(uiTileButton);
        }
        uiTileButtons[0].SetTileSelector(tileSelector);
    }

    private void OnTileButtonClicked(int tileId)
    {
        uiTileButtons[tileId].SetTileSelector(tileSelector);
        string tilesPath = AppData.tilesPath + "" + tileId;
        floorRenderer.material.mainTexture = Resources.Load<Texture>(tilesPath);
    }

    public void ToggleUiTilesManager(bool isVisible)
    {
        mainScrollList.SetActive(isVisible);
        viewProductsButton.gameObject.SetActive(!isVisible);
    }
}