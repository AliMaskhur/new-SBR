using System.Collections.Generic; // Untuk Dictionary
using UnityEngine;
using UnityEngine.UI;

public class SkorPerLayer : MonoBehaviour
{
    public GameObject[] layers; // Daftar layer dalam satu canvas
    public Text txtSkorAkhir;   // Referensi untuk menampilkan skor akhir
    private Dictionary<string, int> skorPerLayer = new Dictionary<string, int>();
    private int skorAkhir = 0;

    void Start()
    {
        // Inisialisasi skor untuk setiap layer
        foreach (var layer in layers)
        {
            if (layer != null)
            {
                skorPerLayer[layer.name] = 0;
                Debug.Log($"Layer {layer.name} skor diinisialisasi ke 0.");
            }
        }
    }

    // Tambahkan skor ke layer tertentu
    public void TambahkanSkor(string namaLayer, int skor)
    {
        if (skorPerLayer.ContainsKey(namaLayer))
        {
            skorPerLayer[namaLayer] += skor;
            Debug.Log($"Skor untuk Layer {namaLayer} ditambahkan: {skor}. Total: {skorPerLayer[namaLayer]}");
        }
        else
        {
            Debug.LogWarning($"Layer {namaLayer} tidak ditemukan!");
        }
    }

    // Hitung skor akhir dari semua layer
    public void HitungSkorAkhir()
    {
        PlayerPrefs.SetInt("skor", 0);
        skorAkhir = 5;

        foreach (var skor in skorPerLayer.Values)
        {
            skorAkhir += skor;
        }

        Debug.Log($"Skor Akhir: {skorAkhir}");

        // Tampilkan skor akhir di UI jika ada
        if (txtSkorAkhir != null)
        {
            txtSkorAkhir.text = $"Skorn: {skorAkhir}";
        }
    }

     public void TampilkanSkorAkhirDariPrefs()
    {
        // Ambil skor akhir dari PlayerPrefs
        //int skor = PlayerPrefs.GetInt("skor", 0);// Default 0 jika belum disimpan
       
        Debug.Log($"Skor Akhir dari PlayerPrefs: {skorAkhir}");

        // Tampilkan skor di UI
        if (txtSkorAkhir != null)
        {
            txtSkorAkhir.text = $"Skor Akhir: {skorAkhir}";
        }
        else
        {
            Debug.LogWarning("txtSkorAkhir belum diatur di Inspector.");
        }
    }
    // Dapatkan skor dari layer tertentu
    public int GetSkorLayer(string namaLayer)
    {
        if (skorPerLayer.ContainsKey(namaLayer))
        {
            return skorPerLayer[namaLayer];
        }

        Debug.LogWarning($"Layer {namaLayer} tidak ditemukan!");
        return 0;
    }
    
}
