using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DiceController : MonoBehaviour
{
    [SerializeField] Sprite[] diceFaces;
    [SerializeField] Image diceImage;
    private int rollValue = 0;

    private void Awake() {
        diceImage = GetComponentInChildren<Image>();
    }

    public void RollDice() {
        Debug.Log("ROLL DICE");
    }
}
