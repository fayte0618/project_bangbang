using UnityEngine;
using System.Collections;

public class CreateEntityInputController : MonoBehaviour
{
    [SerializeField]
    private bool _createOnStart = true;

    [SerializeField]
    private string[] entities;

    // Use this for initialization
    void Start ()
    {
        Create();
    }

    public void Create ()
    {
        foreach (var id in entities)
        {
            var input = Contexts.sharedInstance.input.CreateEntity();
            input.AddCreateEntity(id);
        }
    }
}
