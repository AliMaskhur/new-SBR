using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InputName : MonoBehaviour
{
    public InputField inputFieldName;
    public static string namePlayer;
    public Button buttonLanjut;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void InputPlayerName()
    {
        if (inputFieldName.text.Length > 0) // 0 == tidak text wa == lenght menjadi 2 button aktif
        {
            buttonLanjut.interactable = true;
        }
        else
        {
            buttonLanjut.interactable = false;
        }
    }

    public void ButtonLanjut()
    {
        namePlayer = inputFieldName.text;

        SceneManager.LoadScene(2); //loadscene ke game
    }
}
