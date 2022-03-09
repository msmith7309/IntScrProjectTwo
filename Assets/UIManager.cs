using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    public static TextMeshProUGUI playerHealthText;

    [SerializeField]
    public static TextMeshProUGUI ammoText;

    public static int totalEnemiesKilled = 0;

    void Start()
    {
        playerHealthText = GameObject.Find("PlayerHealthText").GetComponent<TextMeshProUGUI>();

        ammoText = GameObject.Find("AmmoText").GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        // display totalEnemiesKilled
    }

    //building a static function to keep track of enemies killed.
}
