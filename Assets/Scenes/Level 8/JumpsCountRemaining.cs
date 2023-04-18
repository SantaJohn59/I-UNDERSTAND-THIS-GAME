using TMPro;
using UnityEngine;

public class JumpsCountRemaining : MonoBehaviour
{
    private static int jumpsCountRemaining = 7;
    [SerializeField] private TextMeshProUGUI TextAboutJumpsCountRemaining;

    void Start()
    {
        TextAboutJumpsCountRemaining.text = $"������� ��������:{jumpsCountRemaining}";
        Level8_Hero.OnJump += UpdateJumpsCountRemaining;
    }

    private void UpdateJumpsCountRemaining()
    {
        if (jumpsCountRemaining > 0)
        {
            jumpsCountRemaining--;
            TextAboutJumpsCountRemaining.text = $"������� ��������:{jumpsCountRemaining}";
        }
        else
        {
            Level8_Hero.OnJump -= UpdateJumpsCountRemaining;
            Level8_Hero.JumpsAreOver();
        }
    }
}
