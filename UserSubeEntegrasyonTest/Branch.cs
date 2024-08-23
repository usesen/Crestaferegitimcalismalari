namespace UserSubeEntegrasyonTest;

public class Branch
{
    public int BranchId { get; private set; }
    public string BranchName { get; private set; }

    public Branch(string branchName)
    {
        BranchName = branchName ?? throw new ArgumentNullException(nameof(branchName));
    }
}
