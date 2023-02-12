using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiceController : MonoBehaviour {
    [Header("Image Variables")]
    [SerializeField] Sprite[] diceFaces;
    [SerializeField] Image selectedDiceImage;
    [SerializeField] Sprite sprite;

    [Header("Dice Roll Variables")]
    [SerializeField] float rollAnimationTimer = 2f;
    [SerializeField] int rollValue = 0;
    private float rollTimer;
    private bool isRolling;

    private void Awake() {
        selectedDiceImage = GetComponentInChildren<Image>();
        rollTimer = rollAnimationTimer;
        isRolling = false;
    }

    private void Update() {
        if (isRolling) {
            RollDice();
        }
    }


    private void RollDice() {
        if (rollTimer <= 0f) {
            isRolling = false;
            rollTimer = rollAnimationTimer;
            selectedDiceImage.sprite = sprite;
        }

        int diceFaceIndex = Random.Range(0, 6);
        selectedDiceImage.sprite = diceFaces[diceFaceIndex];
        rollTimer -= 0.1f;
        Debug.Log(diceFaces[diceFaceIndex]);
    }

    public void StartRoll() {
        isRolling = true;
    }
}
