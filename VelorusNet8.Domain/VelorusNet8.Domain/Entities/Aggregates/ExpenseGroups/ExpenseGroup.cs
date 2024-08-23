namespace VelorusNet8.Domain.Entities.Aggregates.ExpenseGroups;

public class ExpenseGroup // Gider Grubu
{
    public int Id { get; set; } // Ind (Türkçe: ID)
    public string GroupName { get; set; } // GrupAdi (Türkçe: Grup Adı)
    public int? ParentId { get; set; } // ParentInd (Türkçe: Üst Grup ID)
    public int OrderNo { get; set; } // SiraNo (Türkçe: Sıra No)
    public bool? ShowInSummaryReport { get; set; } // OzetRapordaGoster (Türkçe: Özet Raporda Göster)

    // Constructor
    public ExpenseGroup(int id, string groupName, int? parentId, int orderNo, bool? showInSummaryReport)
    {
        Id = id;
        GroupName = groupName;
        ParentId = parentId;
        OrderNo = orderNo;
        ShowInSummaryReport = showInSummaryReport;
    }

    // Equals metodu
    public override bool Equals(object obj)
    {
        if (obj is ExpenseGroup group)
        {
            return Id == group.Id &&
                   GroupName == group.GroupName &&
                   ParentId == group.ParentId &&
                   OrderNo == group.OrderNo &&
                   ShowInSummaryReport == group.ShowInSummaryReport;
        }
        return false;
    }

    // GetHashCode metodu
    public override int GetHashCode()
    {
        return HashCode.Combine(Id, GroupName, ParentId, OrderNo, ShowInSummaryReport);
    }
}

