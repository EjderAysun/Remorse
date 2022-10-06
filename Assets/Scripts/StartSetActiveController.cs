using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StartSetActiveController : MonoBehaviour
{
    [SerializeField] private Button[] _buttons;
    [SerializeField] private TMP_Text[] _tmpTexts;
    [SerializeField] private TMP_InputField[] _inputFields;
    [SerializeField] private GameObject _horseRacingController;
    [SerializeField] private HorseRacing _horseRacingScript;

    private void Start() {
        foreach (Button button in _buttons)
        {
            button.gameObject.SetActive(false);
        }
        foreach (TMP_Text tmp_text in _tmpTexts)
        {
            tmp_text.gameObject.SetActive(false);
        }
        foreach (TMP_InputField input_field in _inputFields)
        {
            input_field.gameObject.SetActive(false);
        }
    }
    private void Awake() {
        
        _horseRacingController.SetActive(false);
        _horseRacingScript.enabled = false;
    }
}
