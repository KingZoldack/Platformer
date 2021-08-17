using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI _coinText, _livesText;

    Coins _gameCoins;
    Player _player;

    // Start is called before the first frame update
    void Start()
    {
        _gameCoins = GameObject.FindGameObjectWithTag("Coin").GetComponent<Coins>();
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
       // DisplayCoins(_gameCoins.coins);
    }

    public void DisplayCoins(int coins)
    {
        _coinText.text = "Coins: " + coins;
    }

    public void DisplayLives(int lives)
    {
        _livesText.text = "Lives: " + lives; 
    }
}
