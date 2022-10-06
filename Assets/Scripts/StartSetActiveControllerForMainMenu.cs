using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StartSetActiveControllerForMainMenu : MonoBehaviour
{
    [SerializeField] private Button[] _buttons;
    [SerializeField] private TMP_Text[] _tmpTexts;

    private void Start() {
        foreach (Button button in _buttons)
        {
            button.gameObject.SetActive(false);
        }
        foreach (TMP_Text tmp_text in _tmpTexts)
        {
            tmp_text.gameObject.SetActive(false);
        }
    }
}