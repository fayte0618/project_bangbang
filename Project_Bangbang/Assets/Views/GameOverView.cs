using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameOverView : UnityView, IGameStateListener
{
    [SerializeField]
    Transform panel;

    public void OnGameState (GameEntity entity, GameState active)
    {
        if (active == GameState.GAMEOVER) { panel.gameObject.SetActive(true); }
    }

    protected override void Initialize (Contexts contexts, GameEntity entity)
    {
        if (entity.hasViewData && entity.viewData.parentID != "")
        {
            this.transform.SetParent(ScenePositionUtility.Instance.GetParent(entity.viewData.parentID), false);
        }
    }

    protected override void RegisterListeners (GameEntity entity)
    {
        entity.AddGameStateListener(this);
    }

    protected override void UnregisterListeners (GameEntity entity)
    {
        entity.RemoveGameStateListener(this);
    }

    public void Reset ()
    {
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }
}
