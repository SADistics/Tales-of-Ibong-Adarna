using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ExitTriggerPuzzle : MonoBehaviour
{
    public int puzzleCount;
    public int puzzlecurrCount;
    public int puzzlemaxCount;
    public Text puzzleTextCount;
    public GameObject label;
    public GameObject[] puzzles;
    private void Start()
    {
        var puzzles = GameObject.FindGameObjectsWithTag("Puzzle");
        puzzleCount = puzzles.Length;
        puzzlemaxCount = puzzleCount;
        puzzlecurrCount = 0;
        puzzleTextCount.text = "";
    }

    private void Update()
    {
        if (puzzleCount == 0)
        {
            label.SetActive(true);
        }
        puzzleTextCount.text = puzzlecurrCount.ToString() + " / " + puzzlemaxCount.ToString();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && puzzleCount == 0) //if enemy count is 0
        {
            LoadLevel();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && puzzleCount == 0) //if enemy count is 0
        {
            LoadLevel();
        }
    }

    private void LoadLevel()
    {
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("ForestPuzzle"))
            SceneManager.LoadScene("Forest2");
    }
}
