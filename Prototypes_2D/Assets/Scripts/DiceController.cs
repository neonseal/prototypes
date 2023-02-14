using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Dice {
    public int value;
    public bool inPlay;
    public int betIndex;
    public SpriteRenderer spriteRenderer;
}

public class DiceController : MonoBehaviour {
    [Header("Image Variables")]
    [SerializeField] private Sprite[] diceFaces;
    [SerializeField] private SpriteRenderer[] diceSprites;

    [Header("Dice Roll Variables")]
    [SerializeField] private float rollAnimationTimer = 1f;
    [SerializeField] private Dice[] dicePool;
    [SerializeField] private float yieldTime = 0.075f;
    private float rollTimer = 0f;

    private void Awake() {
        diceSprites = GetComponentsInChildren<SpriteRenderer>();
        dicePool = new Dice[3];
        
        for (int i = 0; i < 3; i++) {
            Dice dice = new Dice();
            dice.spriteRenderer = diceSprites[i];
            dicePool[i] = dice;
        }
    }

    private void OnEnable() {
        EventManager.StartListening("StartRoll", StartRoll);
    }

    private void OnDisable() {
        EventManager.StopListening("StartRoll", StartRoll);
    }

    private IEnumerator RollDice() {
        int diceFaceIndex;
        while (rollTimer < rollAnimationTimer) {
            foreach (Dice dice in dicePool) {
                diceFaceIndex = Random.Range(0, 6);
                dice.spriteRenderer.sprite = diceFaces[diceFaceIndex];
                dice.value = diceFaceIndex + 1;
            }
            yield return new WaitForSeconds(yieldTime);
            rollTimer += Time.fixedDeltaTime;
        }

        rollTimer = 0f;
    }

    public void StartRoll() {
        StartCoroutine("RollDice");
    }
}
