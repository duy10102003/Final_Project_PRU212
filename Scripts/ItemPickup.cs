using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public enum ItemType
    {
        Item_Boost_AttackRange,
        Item_Boost_Speed,
        //
        Item_Buff_BoomMulti,
        Item_Buff_Point,
        Item_Buff_Health,
        //
        Item_Skill_FlameLine,
        Item_Skill_Frozen,
        Item_Skill_InfiniteBom,
        
    }

    public ItemType type;

    private void OnItemPickup(GameObject player)
    {
        switch (type)
        {
            case ItemType.Item_Buff_Health:
                player.GetComponent<MovementController>().Addhealth();
                break;

            case ItemType.Item_Buff_BoomMulti:
                player.GetComponent<BombController>().AddBomb();
                break;

            case ItemType.Item_Boost_AttackRange:
                player.GetComponent<BombController>().explosionRadius++;
                break;

            case ItemType.Item_Boost_Speed:
                player.GetComponent<MovementController>().speed++;
                break;
                
            case ItemType.Item_Buff_Point:
                player.GetComponent<MovementController>().AddScore(100);
                break;

            case ItemType.Item_Skill_Frozen:
                var bom = player.GetComponent<BombController>();
                player.AddComponent<FrozenController>();
                player.GetComponent<FrozenController>().SetKey(bom.inputKey);
                Debug.Log("set");
                break;

            case ItemType.Item_Skill_InfiniteBom:
                player.GetComponent<BombController>().AddBomb(0);
                break;

            case ItemType.Item_Skill_FlameLine:
                player.GetComponent<BombController>().bombFuseTime = 0;
                break;
        }

        Destroy(gameObject);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            OnItemPickup(collision.gameObject);
        }
    }
    

}
