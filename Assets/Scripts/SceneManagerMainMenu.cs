using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerMainMenu : MonoBehaviour
{

    public void LoadHorseRacing() {
        SceneManager.LoadScene(1);
    }

    public void LoadExtortion() {
        SceneManager.LoadScene(2);
    }

    public void LoadDonation() {
        SceneManager.LoadScene(3);
    }
}