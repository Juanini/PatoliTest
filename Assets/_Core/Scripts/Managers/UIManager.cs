using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    [SerializeField] private GameObject GameOverView;
    
    public void ShowGameOver()
    {
        GameOverView.SetActive(true);
    }
}
