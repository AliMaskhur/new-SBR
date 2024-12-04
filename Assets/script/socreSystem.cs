using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreSystem : MonoBehaviour
{
    public TextMeshProUGUI scoreTMP; // Untuk menampilkan skor saat ini
    public TextMeshProUGUI finalScoreTMP; // Untuk menampilkan skor akhir
    private int scoreInt;

    private void Start()
    {
        // Inisialisasi skor ke 0 di awal
        PlayerPrefs.SetInt("Score", 0);
        scoreInt = PlayerPrefs.GetInt("Score");
        UpdateScoreDisplay();
    }

    public void ClickButton()
    {
        // Tambah skor saat tombol diklik
        scoreInt += 5;
        PlayerPrefs.SetInt("Score", scoreInt);
        UpdateScoreDisplay();
    }

    private void Update()
    {
        // Menampilkan skor di UI saat ini
        scoreTMP.text = "Score: " + PlayerPrefs.GetInt("Score").ToString();
    }

    public void ShowFinalScore()
    {
        // Ambil skor akhir dari PlayerPrefs
        int finalScore = PlayerPrefs.GetInt("Score");

        // Tampilkan skor akhir di UI
        if (finalScoreTMP != null)
        {
            finalScoreTMP.text = "Score Akhir: " + finalScore.ToString();
        }
        else
        {
            Debug.LogWarning("finalScoreTMP belum diatur di Inspector.");
        }
    }

    public void OnFinalScoreButtonClick()
    {
        // Fungsi ini dipanggil saat tombol ditekan
        ShowFinalScore();
    }

    private void UpdateScoreDisplay()
    {
        // Perbarui tampilan skor saat ini
        scoreTMP.text = "Score: " + scoreInt.ToString();
    }
}
