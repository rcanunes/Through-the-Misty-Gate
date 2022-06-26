using UnityEngine;

[CreateAssetMenu(fileName = "New Lore", menuName = "Inventory/Lore Item")]
public class LoreItem : Item
{
    // Start is called before the first frame update
    public override void Use()
    {
        base.Use();
        Inventory.instance.ShowLore(this);
    }
}
