using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Linq;

public class HorseRacing : MonoBehaviour

{

    [SerializeField] private Character _character;
    private string _chosenHorse;
    private int _betAmount;
    [SerializeField] private TMP_Text _warningZoneHolder;
    [SerializeField] private GameObject horses;
    [SerializeField] private GameObject _finishLine;
    [SerializeField] private TMP_Text _betAmountText;
    [SerializeField] private TMP_Text _selectedHorseText;
    [SerializeField] private Camera _cam;

    private void OnEnable() {
        if(horses.transform.childCount > 0) {
            _chosenHorse = GetInput.Instance.getChosenHorse();
            _betAmount = GetInput.Instance.getBetAmount();
            // Debug.Log(_betAmount);
            StartCoroutine(Countdown());
        }
    }

    private IEnumerator HorseRace() {

        float positionFinishLine = _finishLine.transform.position.x;
        int index = 0;
        int horseCount = horses.transform.childCount;
        float waitForSeconds = 0.01f / horseCount;
        List<GameObject> horseList = new List<GameObject>();

        // Debug.Log(horses.transform.GetChild(0));
        
        for (int i = 0; i < horseCount; i++) {
            horseList.Add(horses.transform.GetChild(i).gameObject);
        }

        // float sum = 0;
        // float num = 0;
        
        while (true)
        {
            yield return new WaitForSeconds(waitForSeconds);
            // _cam.transform.position = new Vector3(_cam.transform.position.x + 0.05f / horseCount, 0, -10);
            //_cam.GetComponent<Rigidbody2D>().MovePosition(_cam.transform.position + new Vector3(0.05f / (float) horseCount, 0, 0));
            _cam.GetComponent<Rigidbody2D>().velocity = new Vector3(4.1f, 0, 0);
            index++;
            if(index >= horseCount) {
                index = 0;
            }

            float posX = Random.Range(0f, 8f);

            GameObject horse = horseList[index];

            //horse.GetComponent<Rigidbody2D>().MovePosition(horse.transform.position + new Vector3(posX, 0, 0));
            horse.GetComponent<Rigidbody2D>().velocity = new Vector3(posX, 0, 0);
            // sum += horse.GetComponent<Rigidbody2D>().velocity.x;
            // num++;
            // horse.transform.position += new Vector3(posX, 0, 0);

            if (horse.transform.position.x >= positionFinishLine) {
                CalculateCurrentMoney(horse);
                bool didWin = horse.name.Equals(_chosenHorse);
                _character.didWin = didWin;
                _character.betAmount = _betAmount;
                // Debug.Log(_character.betAmount);
                _character.whatDidPlay = "HorseRacing";
                StartCoroutine(SlowDownAndStop(horseList));
                StartCoroutine(LoadScene(_warningZoneHolder, didWin));
                break;
            }
        }
        // Debug.Log(sum / num);
    }

    private IEnumerator Countdown() {

        int second = 5;

        while(second > 0){

            Info(second);

            second--;

            yield return new WaitForSeconds(1);
        }

        _warningZoneHolder.gameObject.SetActive(false);
        _betAmountText.gameObject.SetActive(false);
        _selectedHorseText.gameObject.SetActive(false);
        StartCoroutine(HorseRace());

    }

    private void Info(int second) {
        _warningZoneHolder.text = ("The race starts after " + second + " second(s).\nThe rules are simple.\nIf the " + _chosenHorse + " is 1st, you will win " + _betAmount + " dollar(s).\nIf the " + _chosenHorse + " loses, you will lose " + _betAmount + " dollar(s).");
    }

    private IEnumerator SlowDownAndStop(List<GameObject> horseList){
        float milisecond = 0;
        float constant = 0.01f;
        _cam.GetComponent<Rigidbody2D>().velocity = new Vector3(2.05f, 0, 0);
        while(milisecond <= 2f){
            yield return new WaitForSeconds(constant);
            foreach (GameObject horse in horseList)
            {
                // horse.transform.position += new Vector3(Random.Range(0f, 8f), 0, 0);
                horse.GetComponent<Rigidbody2D>().velocity = new Vector3(Random.Range(0f, 4f), 0, 0);
            }
            milisecond += constant;
        }
        foreach (GameObject horse in horseList)
        {
            horse.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        }
        _cam.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
    }

    private void CalculateCurrentMoney(GameObject horse) {
        _warningZoneHolder.gameObject.SetActive(true);
        _warningZoneHolder.text = horse.name + " won the 10th year Veteran Race.";
        if (horse.name == _chosenHorse) {
            int currentMoney = _character.currentMoney + _betAmount;
            _character.currentMoney = currentMoney;
            _warningZoneHolder.text += ("\nYou won. " + _betAmount + " dollar(s) is yours.");
        } else {
            int currentMoney = _character.currentMoney - _betAmount;
            _character.currentMoney = currentMoney;
            _warningZoneHolder.text += ("\nYou lost. " + _betAmount + " dollar(s) became a bird and flew away.");
        }
    }

    private IEnumerator LoadScene(TMP_Text warningZoneHolder, bool didWin) {
        int second = 5;
        while (second > 0)
        {
            warningZoneHolder.text += "\nAfter " + second + " second(s) it returns to the menu.";
            yield return new WaitForSeconds(1f);
            var lastLine = warningZoneHolder.text.Split('\n').Last();
            // warningZoneHolder.text.Substring(0, warningZoneHolder.text.LastIndexOf("\r\n"));
            warningZoneHolder.text = warningZoneHolder.text.Remove(warningZoneHolder.text.TrimEnd().LastIndexOf("\n"));
            second--;
        }
        warningZoneHolder.gameObject.SetActive(false);
        SceneManager.LoadScene(0);
    }
}