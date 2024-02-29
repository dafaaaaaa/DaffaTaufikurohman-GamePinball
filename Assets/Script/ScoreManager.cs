using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
	// kita buat variabel score untuk menyimpan skor
  public float score;
	
  private void Start()
  {
		// reset skor ke 0 tiap game dimulai dari awal
    ResetScore();
  }

  public void AddScore(float addition)
  {
		// tambah skor berdasarkan parameter
    score += addition;
  }

  public void ResetScore()
  {
		// kembalikan skor ke 0 untuk situasi tertentu
    score = 0;
  }
}
