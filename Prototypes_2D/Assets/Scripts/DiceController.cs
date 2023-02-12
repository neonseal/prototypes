using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DiceController : MonoBehaviour {
    [Header("Image Variables")]
    [SerializeField] private Sprite[] diceFaces;
    [SerializeField] private SpriteRenderer[] diceSprites;

    [Header("Dice Roll Variables")]
    [SerializeField] private float rollAnimationTimer = 1f;
    [SerializeField] private int[] rollValues;
    [SerializeField] private float yieldTime = 0.075f;
    private float rollTimer = 0f;

    private void Awake() {
        diceSprites = GetComponentsInChildren<SpriteRenderer>();
        rollValues = new int[] { 0, 0, 0 };
    }

    private IEnumerator RollDice() {
        int diceFaceIndex;
        int diceIndex;
        while (rollTimer < rollAnimationTimer) {
            foreach (SpriteRenderer dice in diceSprites) {
                diceFaceIndex = Random.Range(0, 6);
                diceIndex = System.Array.IndexOf(diceSprites, dice);
                dice.sprite = diceFaces[diceFaceIndex];
                rollValues[diceIndex] = diceFaceIndex + 1;
            }
            yield return new WaitForSeconds(yieldTime);
            rollTimer += (yieldTime);
        }

        rollTimer = 0f;
    }

    public void StartRoll() {
        StartCoroutine("RollDice");
    }
}
