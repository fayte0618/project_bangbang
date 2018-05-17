using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreView : UnityView, IScoreListener
{
    [SerializeField]
    private Text _text;

    public void OnScore (GameEntity entity, int current)
    {
        _text.text = current.ToString();
    }

    protected override void Initialize (Contexts contexts, GameEntity entity)
    {
        _text.text = entity.score.current.ToString();
    }

    protected override void RegisterListeners (GameEntity entity)
    {
        entity.AddScoreListener(this);
    }

    protected override void UnregisterListeners (GameEntity entity)
    {
        entity.RemoveScoreListener(this);
    }
}
