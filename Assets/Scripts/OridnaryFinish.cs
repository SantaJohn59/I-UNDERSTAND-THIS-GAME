using UnityEngine;

public class OridnaryFinish : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            SceneControl.UpdateMaxSceneIndex();
            panel.SetActive(true);
        }
    }
}


