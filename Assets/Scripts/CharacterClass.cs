using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
//using UnityEditor;
// using UnityEditor.Presets;

public class CharacterClass : MonoBehaviour
{
    [SerializeField] private Character _characterPreset;
    [SerializeField] private TMP_Text _remorseText;
    [SerializeField] private Character _character;
    private int _currentMoney;
    [SerializeField] private Slider _slider;
    [SerializeField] private TMP_Text _warning;
    [SerializeField] private TMP_Text _moneyInfo;
    [SerializeField] private TMP_Text _info;
    [SerializeField] private Button _playAgainButton;
    [SerializeField] private Button _exitButton;
    [SerializeField] private Button _horseRacing;
    [SerializeField] private Button _extortion;
    [SerializeField] private Button _donation;
    // private int _betAmount;
    // private bool _didWin;
    private string _whatDidPlay;

    // public Character Character { get => _character; set => _character = value; }

    private void Start() {

        _currentMoney = _character.currentMoney;
        // _betAmount = _character.betAmount;
        // _didWin = Character.didWin;
        _whatDidPlay = _character.whatDidPlay;

        // Debug.Log(_slider);
        // Debug.Log(_warning);
        // Debug.Log(_moneyInfo);

        // Debug.Log("test start");
        // GiveInfo();
        SetRemorse();
        SliderValueControl();
    } 

    private void SetRemorse() {
        _slider.value = _character.lastSliderValue;
        if(_whatDidPlay.Equals("HorseRacing")) {
            float sliderValue = ((float) _character.betAmount / (float) (_currentMoney - _character.betAmount)) * 25;
            // Debug.Log(_character.betAmount / ((_currentMoney - _character.betAmount)) * 25f);
            // Debug.Log(sliderValue);
            // Debug.Log(_character.betAmount);
            // Debug.Log(_currentMoney - _character.betAmount);
            // Debug.Log(78/144 * 25);
            //Debug.Log();
            if(_character.didWin){
                _slider.value += sliderValue;
            } else {
                _slider.value += sliderValue * 1.5f;
            }
        } else if (_whatDidPlay.Equals("Extortion")) {
            // do something
            _slider.value += _character.remorsePointForExtortion;
        } else if (_whatDidPlay.Equals("Donation")) {
            _slider.value -= ((float) _character.donateAmount / (float) (_currentMoney + _character.donateAmount)) * 25;
            // do something
        } else if (_whatDidPlay.Equals("nothing")) {
            // do nothing
        }
        _remorseText.text = "Remorse: " + _slider.value + "/100";
        _character.lastSliderValue = _slider.value;
    }

    private void SliderValueControl() {
        _warning.gameObject.SetActive(true);
        GiveInfo();

        if(_slider.value > _character.minRemorseValue && _slider.value < _character.maxRemorseValue && _currentMoney > 0 && _character.numberOfDaysLeft > 0) {
            if(_character.currentMoney >= _character.targetMoney){
                _warning.text = "You have reached enough money.\nYou had your child operated on. Your child survived!\nBut you don't think you deserve to live for all you've done.\nYou committed suicide and your child lived his life not to be someone like you.\nHappy ending.";
                EndGame();
            } else {
                _warning.text = "Deep down, you're a bad guy who feels compelled to do these things his own way.\nYou need to find money so that your child can have surgery.\nThere are 3 things you can do to get money: play horse racing, extort someone, and donate to relieve yourself.\nBecause you chose these.\nIf you constantly play horse racing or usurp someone, your remorse will increase and the game will be over (" + _character.maxRemorseValue + "/100 max).\nIf you donate too much, your remorse will be relieved and the game will be over (min " + _character.minRemorseValue + "/100).\nTo have your child operated on, balance your good side with your bad side.\nYour child has " + _character.numberOfDaysLeft + " days to live. You must collect enough money for the surgery within " + _character.numberOfDaysLeft + " days.";
            }
        } else {
            if (_character.numberOfDaysLeft <= 0) {
                _warning.text = "You don't have time anymore.\nYour child is now inoperable.\nYour child was brain dead and he died.\nYour child died because you couldn't find enough money.\nYou committed suicide out of sadness.\nYou died a bad person and no one came to your funeral.\nYou failed in life.";
            } else if(_slider.value < _character.minRemorseValue) {
                _warning.text = "You have almost no remorse.\nYou no longer dare to do any evil.\nYour child died because you couldn't find enough money.\nYou're trying to adjust to your life as someone who was once very bad.\nYou failed in life.";
            } else if (_slider.value > _character.maxRemorseValue) {
                _warning.text = "You almost feel totally remorse.\nYou're too devastated to think about anyone anymore.\nYour child died because you couldn't find enough money.\nYou committed suicide out of remorse.\nYou died a bad person and no one came to your funeral.\nYou failed in life.";
            } else if(_currentMoney <= 0) {
                _warning.text = "You're completely out of money.\nYou were shoot and killed by the mob for failing to pay your gambling debts.\nYour child died because you couldn't find enough money.\nYou died a bad person and no one found your body.\nYou rotted along with your remorse.\nYou failed in life.";
            }
            EndGame();
        }
        if(_character.numberOfDaysLeft > 0) {
            _character.numberOfDaysLeft--;
        }
    }

    private void EndGame() {
        _playAgainButton.gameObject.SetActive(true);
        _exitButton.gameObject.SetActive(true);
        _horseRacing.gameObject.SetActive(false);
        _extortion.gameObject.SetActive(false);
        _donation.gameObject.SetActive(false);
    }

    private void GiveInfo() {
        _moneyInfo.text = "Your money: " + _currentMoney + " dollar(s)";
        _info.text = "The amount required to have your child operated on: " + _character.targetMoney + " dollars";
    }

    public void PlayAgain(){
        Character.Instance.Reset(_characterPreset, _character);
        SceneManager.LoadScene(0);
    }

    public void Exit() {
        Application.Quit();
    }

    private void OnApplicationQuit() {
        Character.Instance.Reset(_characterPreset, _character);
    }
}