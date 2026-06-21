
public class PlayerModel : IPlayerModel
{
    private int _id;
    public int ID => _id;
    private int _hp = 3;
    public int HP => _hp;
    private bool _isAlive = true;
    public bool IsAlive => _isAlive;


    public void DicreaseHP()
    {
        _hp--;
    }

    public void SetID(int id)
    {
        _id = id;
    }
}