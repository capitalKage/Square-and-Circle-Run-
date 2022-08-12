using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Victory : MonoBehaviour
{
    public GameObject texts;
    public TMP_Text vicText;
    Player player;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.playerVic == true)
        {
            vicText.text = "You made it in " + player.timerText.text + "seconds!";
            texts.SetActive(true);
        }
    }
}
