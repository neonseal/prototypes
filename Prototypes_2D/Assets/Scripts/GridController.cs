using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;

public class GridController : MonoBehaviour
{
    private Grid grid;
    [SerializeField] private Tilemap tileMap;
    [SerializeField] private Tilemap interactiveMap;
    [SerializeField] private Tile hoverTile;

    private Vector3Int previousMousePosition = new Vector3Int();

    private void Awake() {
        grid = GetComponent<Grid>();
    }

    private void Update() {
        // Capture mouse hover position
        Vector3Int mousePosition = GetMousePosition();

        // Check for mouse movement
        if (!mousePosition.Equals(previousMousePosition)) {
            // Update hover tile
            interactiveMap.SetTile(previousMousePosition, null);
            interactiveMap.SetTile(mousePosition, hoverTile);
            // update mouse position
            previousMousePosition = mousePosition;
        }
    }

    private Vector3Int GetMousePosition() {
        Vector3 mouserWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        return grid.WorldToCell(mouserWorldPosition);
    }
}
