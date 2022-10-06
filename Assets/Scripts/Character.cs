using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using UnityEditor.Presets;


[CreateAssetMenu(fileName = "Character", menuName = "Create Character")]
public class Character : ScriptableObject
{

    // [SerializeField] private Preset characterPreset;
    public int targetMoney;
    public int currentMoney;
    public int betAmount;
    public bool didWin;
    public int numberOfDaysLeft;
    public int minRemorseValue;
    public int maxRemorseValue;
    public string whatDidPlay;
    public float remorsePointForExtortion;
    public int maxMoneyEasyFirstRound;
    public int maxMoneyEasySecondNormalRound;
    public int maxMoneyEasySecondHardRound;
    public int maxMoneyEasyThirdHardRound;
    public int maxMoneyNormalFirstRound;
    public int maxMoneyNormalSecondHardRound;
    public int maxMoneyHardRound;
    public float lastSliderValue;
    public int donateAmount;

    private static Character instance;

    public static Character Instance
    {
        get
        {
            return instance;
        }
    }

    private void OnEnable() {
        instance = this;
    }

    public int getTargetMoney() {
        return this.targetMoney;
    }

    public void setTargetMoney(int targetMoney) {
        this.targetMoney = targetMoney;
    }

    public void Reset(Character characterPreset, Character character){
        character.targetMoney = characterPreset.targetMoney;
        character.currentMoney = characterPreset.currentMoney;
        character.betAmount = characterPreset.betAmount;
        character.didWin = characterPreset.didWin;
        character.numberOfDaysLeft = characterPreset.numberOfDaysLeft;
        character.minRemorseValue = characterPreset.minRemorseValue;
        character.maxRemorseValue = characterPreset.maxRemorseValue;
        character.whatDidPlay = characterPreset.whatDidPlay;
        character.maxMoneyEasyFirstRound = characterPreset.maxMoneyEasyFirstRound;
        character.maxMoneyEasySecondNormalRound = characterPreset.maxMoneyEasySecondNormalRound;
        character.maxMoneyEasySecondHardRound = characterPreset.maxMoneyEasySecondHardRound;
        character.maxMoneyEasyThirdHardRound = characterPreset.maxMoneyEasyThirdHardRound;
        character.remorsePointForExtortion = characterPreset.remorsePointForExtortion;
        character.maxMoneyNormalFirstRound = characterPreset.maxMoneyNormalFirstRound;
        character.maxMoneyNormalSecondHardRound = characterPreset.maxMoneyNormalSecondHardRound;
        character.maxMoneyHardRound = characterPreset.maxMoneyHardRound;
        character.lastSliderValue = characterPreset.lastSliderValue;
        character.donateAmount = characterPreset.donateAmount;
    }
}