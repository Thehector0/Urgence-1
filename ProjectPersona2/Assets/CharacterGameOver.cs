using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterGameOver : MonoBehaviour
{
    public GameObject gameOverPanel;
    [SerializeField] GameObject weaponParent;

    public void GameOver() 
    {
        gameOverPanel.SetActive(true);
        GetComponent<PlayerController>().enabled = false;
        weaponParent.SetActive(false);
    }
}
