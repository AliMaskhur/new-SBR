using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PengolahSoal : MonoBehaviour
{
    public TextAsset Assetsoal;

    private string[] soal;
    private string[,] soalBag;

    int indexSoal;
    int maxSoal;
    bool ambilSoal;
    char kunciJ;
    //string namaGambar;

    // Komponen UI
    public Text txtSoal, txtOpsiA, txtOpsiB, txtOpsiC, txtOpsiD;
    public Image imgSoal; // Komponen untuk menampilkan gambar soal

    bool isHasil;
    private float durasi;
    public float durasiPenilaian;

    int jwbBenar, jwbSalah;
    float nilai;

    public GameObject panel;
    public GameObject imgPenilaian, imgHasil;
    public Text txtHasil;
    public Text txtPenilaian;

    //public string folderPath;

    // Start is called before the first frame update
    void Start()


    {
        //Object[] resources = Resources.LoadAll(folderPath, typeof(Sprite));

        //if (resources.Length > 0)
        //{
        //    Debug.Log($"Ditemukan {resources.Length} file di folder {folderPath}:");
        //    foreach (var resource in resources)
        //    {
        //        Debug.Log($"- {resource.name}");
        //    }
        //}
        //else
        //{
        //    Debug.LogWarning($"Tidak ditemukan file di folder {folderPath}. Pastikan folder dan file sudah benar.");
        //}

        durasi = durasiPenilaian;
        soal = Assetsoal.ToString().Split('#'); // Memisahkan soal dengan delimiter #

        soalBag = new string[soal.Length, 7]; // Tambah kolom untuk menyimpan nama gambar
        maxSoal = soal.Length;
        OlahSoal();

        ambilSoal = true;
        TampilkanSoal();
    }

    private void OlahSoal()
    {
        for (int i = 0; i < soal.Length; i++)
        {
            string[] tempSoal = soal[i].Split('+'); // Memisahkan data tiap soal dengan delimiter +
            for (int j = 0; j < tempSoal.Length; j++)
            {
                soalBag[i, j] = tempSoal[j];
            }
        }
    }

    private void TampilkanSoal()
    {
        if (indexSoal < maxSoal)
        {
            if (ambilSoal)
            {
                txtSoal.text = soalBag[indexSoal, 0]; // Soal utama
                txtOpsiA.text = soalBag[indexSoal, 1];
                txtOpsiB.text = soalBag[indexSoal, 2];
                txtOpsiC.text = soalBag[indexSoal, 3];
                txtOpsiD.text = soalBag[indexSoal, 4];
                kunciJ = soalBag[indexSoal, 5][0]; // Jawaban benar

                // Load gambar soal
                string namaGambar = soalBag[indexSoal, 6];
                Debug.Log($"Mencoba memuat gambar sebagai Object: {namaGambar}");

                // Muat gambar sebagai Object
                Object objGambar = Resources.Load(namaGambar);

                if (objGambar != null)
                {
                    Debug.Log($"Gambar ditemukan sebagai Object: {objGambar.name}");

                    // Konversi Object ke Sprite
                    Sprite gambarSoal = objGambar as Sprite;

                    if (gambarSoal != null)
                    {
                        Debug.Log($"Gambar berhasil dikonversi menjadi Sprite: {gambarSoal.name}");
                        imgSoal.sprite = gambarSoal;
                        imgSoal.gameObject.SetActive(true);
                    }
                    else
                    {
                        Debug.LogWarning($"Gambar ditemukan tetapi gagal dikonversi ke Sprite. Tipe sebenarnya: {objGambar.GetType()}");
                        imgSoal.gameObject.SetActive(false);
                    }
                }
                else
                {
                    Debug.LogWarning($"Gambar tidak ditemukan di Resources: {namaGambar}");
                    imgSoal.gameObject.SetActive(false);
                }

                ambilSoal = false;
            }
        }
    }

    public void Opsi(string opsiHuruf)
    {
        CheckJawaban(opsiHuruf[0]);

        if (indexSoal == maxSoal - 1)
        {
            isHasil = true;
        }
        else
        {
            indexSoal++;
            ambilSoal = true;
        }

        panel.SetActive(true);
    }

    private float HitungNilai()
    {
        return nilai = (float)jwbBenar / maxSoal * 100;
    }

    private void CheckJawaban(char huruf)
    {
        string penilaian;

        if (huruf.Equals(kunciJ))
        {
            penilaian = "Mantap!";
            jwbBenar++;
        }
        else
        {
            penilaian = "Salah!";
            jwbSalah++;
        }

        txtPenilaian.text = penilaian;
    }

    void Update()
    {
        if (panel.activeSelf)
        {
            durasiPenilaian -= Time.deltaTime;

            if (isHasil)
            {
                imgPenilaian.SetActive(true);
                imgHasil.SetActive(false);

                if (durasiPenilaian <= 0)
                {
                    txtHasil.text = "Jumlah benar: " + jwbBenar + "\nJumlah Salah: " + jwbSalah + "\n\nNilai: " + HitungNilai();

                    imgPenilaian.SetActive(false);
                    imgHasil.SetActive(true);

                    durasiPenilaian = 0;
                }
            }
            else
            {
                imgPenilaian.SetActive(true);
                imgHasil.SetActive(false);

                if (durasiPenilaian <= 0)
                {
                    panel.SetActive(false);
                    durasiPenilaian = durasi;

                    TampilkanSoal();
                }
            }
        }
    }
}
