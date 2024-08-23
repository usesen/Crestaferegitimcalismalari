namespace VelorusNet8.Domain.Entities.Aggregates.IncomeGroups;

public class IncomeGroup // gelir grubu
{
    public int Id { get; set; } // Ind (Türkçe: ID)
    public string GroupName { get; set; } // GrupAdi (Türkçe: Grup Adı)
    public int? ParentId { get; set; } // ParentInd (Türkçe: Üst Grup ID)
    public int OrderNo { get; set; } // SiraNo (Türkçe: Sıra No)

    // Constructor
    public IncomeGroup(int id, string groupName, int? parentId, int orderNo)
    {
        Id = id;
        GroupName = groupName;
        ParentId = parentId;
        OrderNo = orderNo;
    }

    // Equals metodu
    public override bool Equals(object obj)
    {
        if (obj is IncomeGroup group)
        {
            return Id == group.Id &&
                   GroupName == group.GroupName &&
                   ParentId == group.ParentId &&
                   OrderNo == group.OrderNo;
        }
        return false;
    }

    // GetHashCode metodu
    public override int GetHashCode()
    {
        return HashCode.Combine(Id, GroupName, ParentId, OrderNo);
    }
}
