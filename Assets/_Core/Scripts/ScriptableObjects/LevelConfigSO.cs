using UnityEngine;

[CreateAssetMenu(fileName = "LevelConfig", menuName = Constants.SO_PATH + "LevelConfig", order = 0)]
public class LevelConfigSO : ScriptableObject
{
    public int coinsToCompleteLevel;
}