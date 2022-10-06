using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Donation : MonoBehaviour
{
    [SerializeField] private TMP_InputField _donationInputField;
    private int _donateAmount;
    [SerializeField] private TMP_Text _warningZoneHolder;
    [SerializeField] private Character _character;
    [SerializeField] private Button backToMenuButton;
    public void SetBetAmount(Button button) {
        if(System.Int32.TryParse(_donationInputField.text, out _donateAmount)) {
            if(_donateAmount <= 0) {
                _warningZoneHolder.text = "Please enter a positive donate value!";
            } else {
                if(_character.currentMoney < _donateAmount) {
                    _warningZoneHolder.text = "You don't have that much money.\nPlease enter a smaller amount!";
                } else {
                    _donationInputField.gameObject.SetActive(false);
                    _warningZoneHolder.text = "You donated " + _donateAmount + " dollar(s)";
                    backToMenuButton.gameObject.SetActive(true);
                    _character.donateAmount = _donateAmount;
                    _character.currentMoney -= _donateAmount;
                    _character.whatDidPlay = "Donation";
                }
            }
        } else {
            if(System.Single.TryParse(_donationInputField.text, out float x)) {
                _warningZoneHolder.text = "Please enter a integer donate value!";
            } else {
                _warningZoneHolder.text = "Please enter a valid donate value";
            }
        }
    }

    public void BackToMenu() {
        SceneManager.LoadScene(0);
    }

}