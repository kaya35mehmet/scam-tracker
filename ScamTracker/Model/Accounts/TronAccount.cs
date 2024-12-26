using ScamTracker.Model.Accounts;

public class TronAccount
{
    public long TotalFrozenV2 { get; set; }
    public long TransactionsOut { get; set; }
    public long FrozenForEnergyV2 { get; set; }
    public long RewardNum { get; set; }
    public long DelegatedFrozenV2BalanceForBandwidth { get; set; }
    public OwnerPermission OwnerPermission { get; set; }
    public string RedTag { get; set; }
    public long DelegateFrozenForEnergy { get; set; }
    public long Balance { get; set; }
    public long FrozenForBandWidthV2 { get; set; }
    public long CanWithdrawAmountV2 { get; set; }
    public object Delegated { get; set; }
    public long TransactionsIn { get; set; }
    public long TotalTransactionCount { get; set; }
    public Representative Representative { get; set; }
    public string Announcement { get; set; }
    public List<string> AllowExchange { get; set; }
    public int AccountType { get; set; }
    public List<string> Exchanges { get; set; }
    public Frozen Frozen { get; set; }
    public long Transactions { get; set; }
    public long DelegatedFrozenV2BalanceForEnergy { get; set; }
    public string Name { get; set; }
    public long FrozenForEnergy { get; set; }
    public double EnergyCost { get; set; }
    public List<ActivePermission> ActivePermissions { get; set; }
    public long AcquiredDelegatedFrozenV2BalanceForBandwidth { get; set; }
    public double NetCost { get; set; }
    public long AcquiredDelegateFrozenForBandWidth { get; set; }
    public string GreyTag { get; set; }
    public string PublicTag { get; set; }
    public List<Token> WithPriceTokens { get; set; }
    public long UnfreezeV2 { get; set; }
    public bool FeedbackRisk { get; set; }
    public long VoteTotal { get; set; }
    public long TotalFrozen { get; set; }
    public long LatestOperationTime { get; set; }
    public long FrozenForBandWidth { get; set; }
    public int Reward { get; set; }
    public string AddressTagLogo { get; set; }
    public string Address { get; set; }
    public List<object> FrozenSupply { get; set; }
    public Bandwidth Bandwidth { get; set; }
    public long DateCreated { get; set; }
    public string AddressTag { get; set; }
    public long AcquiredDelegatedFrozenV2BalanceForEnergy { get; set; }
    public AccountResource AccountResource { get; set; }
    public string BlueTag { get; set; }
    public int Witness { get; set; }
    public long Freezing { get; set; }
    public long DelegateFrozenForBandWidth { get; set; }
    public bool Activated { get; set; }
    public long AcquiredDelegateFrozenForEnergy { get; set; }
}