
public class SpawnController
{
    private SpawnView spawnView;

    public SpawnController(SpawnView spawnView)
    {
        this.spawnView = spawnView;
        spawnView.SetController(this);
    }
    public void OnSpawnChestButtonClick()
    {
        if (GameService.Instance.ChestService.ReturnChests().Count < GameService.Instance.ChestSlots)
        {
            GameService.Instance.ChestService.SpawnChest();
            GameService.Instance.SoundManager.PlaySound(Sound.SPAWNED);
        }
        else
        {
            GameService.Instance.UIService.GetPopUpController().OpenChestFullAlertPopUp();
            GameService.Instance.SoundManager.PlaySound(Sound.REJECT);
        }
    }
}
