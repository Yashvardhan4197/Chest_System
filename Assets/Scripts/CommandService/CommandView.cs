
using UnityEngine;
using UnityEngine.UI;

public class CommandView : MonoBehaviour
{
    [SerializeField] Button UndoButton;
    private CommandController commandService;

    private void Start()
    {
        UndoButton.onClick.AddListener(PerformUndo);
    }

    private void PerformUndo()
    {
        commandService.Undo();
    }

    public void SetCommandService(CommandController commandService)=>this.commandService = commandService;
}
