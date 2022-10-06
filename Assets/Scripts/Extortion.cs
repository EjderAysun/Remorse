using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Extortion : MonoBehaviour
{

    [SerializeField] private Character _characterPreset;
    [SerializeField] private Button _easyButton;
    [SerializeField] private Character _character;
    [SerializeField] private TMP_Text _extortion;
    //[SerializeField] private TMP_Text _easy1;
    [SerializeField] private TMP_Text _easy2;
    [SerializeField] private TMP_Text _easy3;
    [SerializeField] private TMP_Text _message;
    [SerializeField] private Button _takeAndGoButton;
    [SerializeField] private Button _comeBackEmptyHanded;
    //[SerializeField] private TMP_Text _normal1;
    [SerializeField] private TMP_Text _normal2;
    [SerializeField] 

    private void MoveExtortion(){

    }

    public void Easy() {
        _extortion.gameObject.SetActive(false);
        float positivePossibility;
        int receivedMoney;
        _character.whatDidPlay = "Extortion";
        _comeBackEmptyHanded.gameObject.SetActive(true);
        positivePossibility = Random.Range(1f,10f);
        if(positivePossibility <= 6f) {
            receivedMoney = Random.Range(_character.maxMoneyEasyFirstRound / 4, _character.maxMoneyEasyFirstRound + 1);
            _character.currentMoney += receivedMoney;
            _character.remorsePointForExtortion = Random.Range(1f, 4f);
            _message.text = "The man gave you " + receivedMoney + " dollar(s). Take it and go!";
            _message.gameObject.SetActive(true);
            _takeAndGoButton.gameObject.SetActive(true);
            _comeBackEmptyHanded.gameObject.SetActive(false);
        } else {
            // Debug.Log("sal beni");
            _easy2.gameObject.SetActive(true);
            //_easy1.gameObject.SetActive(false);
        }
    }

    public void Normal() {
        _extortion.gameObject.SetActive(false);
        float positivePossibility;
        int receivedMoney;
        _character.whatDidPlay = "Extortion";
        _comeBackEmptyHanded.gameObject.SetActive(true);
        positivePossibility = Random.Range(1f, 10f);
        if(positivePossibility <= 4f) {
            receivedMoney = Random.Range(_character.maxMoneyNormalFirstRound / 4, _character.maxMoneyNormalFirstRound + 1);
            _character.currentMoney += receivedMoney;
            _character.remorsePointForExtortion = Random.Range(4f, 6f);
            _message.text = "You managed to get " + receivedMoney + " dollar(s) by threatening the man.";
            _message.gameObject.SetActive(true);
            _takeAndGoButton.gameObject.SetActive(true);
            _comeBackEmptyHanded.gameObject.SetActive(false);
        } else {
            _normal2.gameObject.SetActive(true);
            //_normal1.gameObject.SetActive(false);
        }
    }

    public void Hard() {
        _extortion.gameObject.SetActive(false);
        float positivePossibility;
        int receivedMoney;
        _character.whatDidPlay = "Extortion";
        _comeBackEmptyHanded.gameObject.SetActive(true);
        positivePossibility = Random.Range(1f, 10f);
        if(positivePossibility <= 2.5f) {
            //_comeBackEmptyHanded.gameObject.SetActive(false);
            receivedMoney = Random.Range(_character.maxMoneyHardRound / 4, _character.maxMoneyHardRound + 1);
            _character.currentMoney += receivedMoney;
            _character.remorsePointForExtortion = Random.Range(5.5f, 8f);
            _message.text = "You beat the man almost to death and got his " + receivedMoney + " dollar(s). Take it and go!";
            _message.gameObject.SetActive(true);
            _takeAndGoButton.gameObject.SetActive(true);
            _comeBackEmptyHanded.gameObject.SetActive(false);
            // _hard1.gameObject.SetActive(false);
        } else {
            _message.text = "The man beat you to death and you got no money.";
            _message.gameObject.SetActive(true);
            _character.remorsePointForExtortion = Random.Range(4f, 6.5f);
            //_hard1.gameObject.SetActive(false);
        }
    }

    public void LoadMenu() {
        SceneManager.LoadScene(0);
    }

    public void Easy2Normal() {
        float positivePossibility;
        int receivedMoney;
        positivePossibility = Random.Range(1f, 10f);
        if(positivePossibility <= 4.5f) {
            //_comeBackEmptyHanded.gameObject.SetActive(false);
            receivedMoney = Random.Range(_character.maxMoneyEasySecondNormalRound / 4, _character.maxMoneyEasySecondNormalRound + 1);
            _character.currentMoney += receivedMoney;
            _character.remorsePointForExtortion = Random.Range(3f, 5f);
            _message.text = "The guy paid you " + receivedMoney + " dollar(s). Take it and go!";
            _message.gameObject.SetActive(true);
            _takeAndGoButton.gameObject.SetActive(true);
            _comeBackEmptyHanded.gameObject.SetActive(false);
            _easy2.gameObject.SetActive(false);
        } else {
            _character.remorsePointForExtortion = Random.Range(2f, 4f);
            _easy3.gameObject.SetActive(true);
            //_comeBackEmptyHanded.gameObject.SetActive(true);
            _easy2.gameObject.SetActive(false);
        }
    }

    public void Easy2Hard() {
        float positivePossibility;
        int receivedMoney;
        positivePossibility = Random.Range(1f, 10f);
        if(positivePossibility <= 3.5f) {
            //_comeBackEmptyHanded.gameObject.SetActive(false);
            receivedMoney = Random.Range(_character.maxMoneyEasySecondHardRound / 4, _character.maxMoneyEasySecondHardRound + 1);
            _character.currentMoney += receivedMoney;
            _character.remorsePointForExtortion = Random.Range(3.5f, 6f);
            _message.text = "You extorted " + receivedMoney + " dollar(s) from the man. Take it and go!";
            _message.gameObject.SetActive(true);
            _takeAndGoButton.gameObject.SetActive(true);
            _comeBackEmptyHanded.gameObject.SetActive(false);
            _easy2.gameObject.SetActive(false);
        } else {
            _easy2.gameObject.SetActive(false);
            _message.text = "The man beat you up, and you didn't get any money.";
            _message.gameObject.SetActive(true);
            _character.remorsePointForExtortion = Random.Range(2.5f, 5f);
            //_easy2.gameObject.SetActive(false);
            //_easy3.gameObject.SetActive(true);
            // _comeBackEmptyHanded.gameObject.SetActive(true);
        }
    }

    public void Easy3Hard() {
        float positivePossibility;
        int receivedMoney;
        positivePossibility = Random.Range(1f, 10f);
        if(positivePossibility <= 3f) {
            //_comeBackEmptyHanded.gameObject.SetActive(false);
            receivedMoney = Random.Range(_character.maxMoneyEasyThirdHardRound / 4, _character.maxMoneyEasyThirdHardRound + 1);
            _character.currentMoney += receivedMoney;
            _character.remorsePointForExtortion = Random.Range(4.5f, 7f);
            _message.text = "You fought the man directly and took his " + receivedMoney + " dollar(s). Take it and go!";
            _message.gameObject.SetActive(true);
            _takeAndGoButton.gameObject.SetActive(true);
            _comeBackEmptyHanded.gameObject.SetActive(false);
            _easy3.gameObject.SetActive(false);
        } else {
            _message.text = "The man beat you up, and you didn't get any money.";
            _message.gameObject.SetActive(true);
            _character.remorsePointForExtortion = Random.Range(3.5f, 6f);
            _easy3.gameObject.SetActive(false);
        }
    }

    public void Normal2Hard() {
        float positivePossibility;
        int receivedMoney;
        positivePossibility = Random.Range(1f, 10f);
        if(positivePossibility <= 2.75f) {
            //_comeBackEmptyHanded.gameObject.SetActive(false);
            receivedMoney = Random.Range(_character.maxMoneyNormalSecondHardRound / 4, _character.maxMoneyNormalSecondHardRound + 1);
            _character.currentMoney += receivedMoney;
            _character.remorsePointForExtortion = Random.Range(5f, 7.5f);
            _message.text = "You managed to get the guy " + receivedMoney + " dollars by beating him up.";
            _message.gameObject.SetActive(true);
            _takeAndGoButton.gameObject.SetActive(true);
            _comeBackEmptyHanded.gameObject.SetActive(false);
            _normal2.gameObject.SetActive(false);
        } else {
            _message.text = "The man beat you up, and you didn't get any money.";
            _message.gameObject.SetActive(true);
            _character.remorsePointForExtortion = Random.Range(3.75f, 6.25f);
            _normal2.gameObject.SetActive(false);
        }
    }

    private void OnApplicationQuit() {
        Character.Instance.Reset(_characterPreset, _character);
    }

}