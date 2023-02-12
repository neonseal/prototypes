using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayAreaController : MonoBehaviour
{
    [SerializeField] DiceController[] playerDice;
    [SerializeField] Button playButton;

    private void Awake() {
        playerDice = GetComponentsInChildren<DiceController>();
        playButton = GetComponentInChildren<Button>();
        playButton.onClick.AddListener(StartNewRoll);
    }

    private void StartNewRoll() { 
        foreach (DiceController dice in playerDice) {
            dice.StartRoll();
        }
    }
}
