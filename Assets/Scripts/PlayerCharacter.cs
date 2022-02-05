using System.Collections.Generic;

public class PlayerCharacter : Character
{
    public List<Action> actionPrefabs = new List<Action>();
    private List<Action> actionButtons = new List<Action>();

    public override void TakeTurn()
    {
        SpawnActions();
    }

    private void SpawnActions()
    {
        foreach (Action action in actionPrefabs)
        {
            Action newAction = Instantiate(action, transform);
            newAction.SetOwner(this);
            actionButtons.Add(newAction);
        }
    }
}
