using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class PlayAreaController : MonoBehaviour
{
    [SerializeField] Button playButton;

    private void Awake() {
        playButton = GetComponentInChildren<Button>();
        playButton.onClick.AddListener(StartNewRoll);
    }

    private void StartNewRoll() {
        // Send out start roll event to be picked up by the DiceController
        EventManager.TriggerEvent("StartRoll");
    }
}
