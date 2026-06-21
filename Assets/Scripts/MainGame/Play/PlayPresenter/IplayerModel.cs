using UnityEngine;

public interface IPlayerModel
{
    public int ID { get; }
    public int HP { get; }
    public bool IsAlive { get; }
    public void DicreaseHP();
    public void SetID(int id);
}