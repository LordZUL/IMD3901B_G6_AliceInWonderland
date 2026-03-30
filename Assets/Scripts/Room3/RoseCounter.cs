using UnityEngine;
using TMPro;

public class RoseCounter : MonoBehaviour
{
    public static RoseCounter Instance;

    public TextMeshProUGUI counterText;

    public int totalRoses = 7;
    private int paintedRoses = 0;

    void Awake()
    {
        Instance = this;
        UpdateUI();
    }

    public void AddRose()
    {
        paintedRoses++;
        UpdateUI();
    }

    void UpdateUI()
    {
        counterText.text = "Roses: " + paintedRoses + " / " + totalRoses;
    }
}