using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Button restartButton;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        restartButton.gameObject.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if (Player.isDead)
        {
            player.SetActive(false);
            restartButton.gameObject.SetActive(true);
        }
    }
    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
