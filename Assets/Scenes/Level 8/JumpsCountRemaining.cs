using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JumpsCountRemaining
{
    private int jumpsCountRemaining;
    private TextMeshProUGUI textAboutJumpsCountRemaining;
    public bool areJumpsOver = false;

    public JumpsCountRemaining(int jumpsCountRemaining, TextMeshProUGUI textAboutJumpsCountRemaining)
    {
        this.jumpsCountRemaining = jumpsCountRemaining;
        this.textAboutJumpsCountRemaining = textAboutJumpsCountRemaining;
        textAboutJumpsCountRemaining.text = $"������� ��������: {jumpsCountRemaining}";
        Level8_Hero.OnJump += UpdateJumpsCountRemaining;
    }

    public void UpdateJumpsCountRemaining()
    {
        jumpsCountRemaining--;
        textAboutJumpsCountRemaining.text = $"������� ��������: {jumpsCountRemaining}";

        if (jumpsCountRemaining == 0)
        {
            areJumpsOver = true;
            Level8_Hero.OnJump -= UpdateJumpsCountRemaining;
        }
    }
}
