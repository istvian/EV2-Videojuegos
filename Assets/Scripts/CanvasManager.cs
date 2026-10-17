using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    public static CanvasManager instance;
    [SerializeField] GameObject gameoverScreen, winScreen;
    [SerializeField] TextMeshProUGUI coinText;
    private int coinsTotal;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {
        coinsTotal = GameObject.FindGameObjectsWithTag("Coin").Length;
        UpdateCoins(0);
    }
    public void UpdateCoins(int amount)
    {
        coinText.text = $"Monedas: {amount}/{coinsTotal}";
    }
    public void Gameover(bool state)
    {
        gameoverScreen.SetActive(state);
    }
    public void Win()
    {
        winScreen.SetActive(true);
    }
}
