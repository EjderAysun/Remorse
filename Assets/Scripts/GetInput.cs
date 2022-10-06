using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class GetInput : MonoBehaviour
{

    private string _chosenHorse;
    private int _betAmount;
    [SerializeField] private Character _characterPreset;
    [SerializeField] private Character _character;
    [SerializeField] private TMP_Text _whichHorseText;
    [SerializeField] private TMP_Text _selectedHorseHolder;
    [SerializeField] private TMP_InputField _howMuchBetField;
    [SerializeField] private TMP_Text _warningZoneHolder;
    [SerializeField] private TMP_Text _betAmountHolder;
    [SerializeField] private GameObject _horsePrefab;
    [SerializeField] private GameObject _horsesHolder;
    [SerializeField] private Camera _cam;
    private int _howManyHorses;
    [SerializeField] private Button _horseSelectButtonPrefab;
    [SerializeField] private HorseRacing _horseRacingScript;

// -----------------------------------------------------------
    private static GetInput instance;

    public static GetInput Instance
    {
        get
        {
            return instance;
        }
    }

    public string getChosenHorse(){
        return this._chosenHorse;
    }

    public int getBetAmount(){
        return this._betAmount;
    }

// ------------------------------------------------

    private void Awake() {
        instance = this;
    }

    // koşunun adı 10. yıl gazi koşusu
    private void Start() {

        // horse_name_list = {"Gülbatur", "Şahbatur", "Bold Pilot", "Turbo", "Kafkaslı"};
        

        List<string> horseNameList = new List<string>();
        int counter = 0;
        List<Button> buttonList = new List<Button>();

        horseNameList.Add("Gülbatur");
        horseNameList.Add("Şahbatur");
        horseNameList.Add("Bold Pilot");
        horseNameList.Add("Turbo");
        horseNameList.Add("Kafkaslı");

        _howManyHorses = Random.Range(2, horseNameList.Count + 1);

        while (counter < _howManyHorses) {

            Button button = Instantiate(_horseSelectButtonPrefab) as Button;
            buttonList.Add(button);

            RectTransform rt = button.GetComponent<RectTransform>();
            rt.SetParent(_whichHorseText.transform);

            // button.gameObject.transform.localPosition = new Vector3(-225 + counter * 110, -50, 0);
            int index = Random.Range(0, horseNameList.Count);
            button.GetComponentInChildren<TMP_Text>().text = horseNameList[index];

            GameObject horse = Instantiate(_horsePrefab);
            horse.transform.SetParent(_horsesHolder.transform);

            switch (counter)
            {
                case 0 :
                    horse.transform.position = new Vector3(-6, 0, 0);
                    break;
                case 1 :                  
                    horse.transform.position = new Vector3(-6, 1.5f, 0);
                    break;
                case 2 :
                    horse.transform.position = new Vector3(-6, -1.5f, 0);
                    break;
                case 3 :
                    horse.transform.position = new Vector3(-6, -3, 0);
                    break;
                case 4 :
                    horse.transform.position = new Vector3(-6, 3, 0);
                    break;
            }

            button.transform.position = _cam.WorldToScreenPoint(horse.transform.position) + new Vector3(450f, 0, 0);
            // button.transform.position = _cam.WorldToScreenPoint(horse.transform.position) + new Vector3(100f, 0, 0);

            // horse.GetComponent<SpriteRenderer>().material.color = new Color(Random.value, Random.value, Random.value, 1.0f);

            horse.name = horseNameList[index];

            horseNameList.RemoveAt(index);
            counter++ ;
        }

        for (int i = 0; i < buttonList.Count; i++) {
                int closureIndex = i ; // Prevents the closure problem
                buttonList[closureIndex].onClick.AddListener( () => SetChosenHorse(buttonList[closureIndex]));
        }
    }

    public void SetChosenHorse(Button button){
        _chosenHorse = button.GetComponentInChildren<TMP_Text>().text;
        //button.transform.parent.gameObject.SetActive(false);
        _whichHorseText.gameObject.SetActive(false);
        _selectedHorseHolder.text += _chosenHorse;
        _selectedHorseHolder.gameObject.SetActive(true);
        _howMuchBetField.gameObject.SetActive(true);
    }

    public void SetBetAmount(Button button) {

        if (System.Int32.TryParse(_howMuchBetField.text, out _betAmount)) {
            // Debug.Log(this._betAmount);
            if(_betAmount <= 0) {
                _warningZoneHolder.text = "Please enter a positive bet value!";
            } else {
                if(_character.currentMoney < _betAmount) {
                    _warningZoneHolder.text = "You don't have that much money.\nPlease enter a smaller amount!";
                } else {
                    _howMuchBetField.gameObject.SetActive(false);
                    _betAmountHolder.text += (_betAmount + " dollar(s)");
                    _betAmountHolder.gameObject.SetActive(true);
                    _horseRacingScript.gameObject.SetActive(true);
                    _horseRacingScript.enabled = true;
                    // StartCoroutine(Countdown(_warningZoneHolder));

                }
            }
        } else {
            if(System.Single.TryParse(_howMuchBetField.text, out float x)) {
                _warningZoneHolder.text = "Please enter a integer bet value!";
            } else {
                _warningZoneHolder.text = "Please enter a valid bet value";
            }
        }
    }

    private void OnApplicationQuit() {
        Character.Instance.Reset(_characterPreset, _character);
    }

}