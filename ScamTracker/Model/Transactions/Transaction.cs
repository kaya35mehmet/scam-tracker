using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScamTracker.Model.Transactions
{
    public class Transaction
    {
        public ContractMap ContractMap { get; set; }
        public string ContractRet { get; set; }
        public string Data { get; set; }
        public Dictionary<string, ContractInfoDetails> ContractInfo { get; set; }
        public int ContractType { get; set; }
        public int EventCount { get; set; }
        public string Project { get; set; }
        public string ToAddress { get; set; }
        public bool Confirmed { get; set; }
        public List<Trc20TransferInfo> Trc20TransferInfo { get; set; }
        public List<Trc20TransferInfo> TransfersAllList { get; set; }
        public int Block { get; set; }
        public int TriggerContractType { get; set; }
        public bool RiskTransaction { get; set; }
        public long Timestamp { get; set; }
        public Dictionary<string, object> Info { get; set; } = new Dictionary<string, object>();
        public NormalAddressInfo NormalAddressInfo { get; set; }
        public Cost Cost { get; set; }
        public int NoteLevel { get; set; }
        public Dictionary<string, object> AddressTag { get; set; } = new Dictionary<string, object>();
        public bool Revert { get; set; }
        public int Confirmations { get; set; }
        public int FeeLimit { get; set; }
        public TokenTransferInfo TokenTransferInfo { get; set; }
        public string ContractTypeString { get; set; }
        public TriggerInfo TriggerInfo { get; set; }
        public List<string> SignatureAddresses { get; set; }
        public string OwnerAddress { get; set; }
        public List<SrConfirm> SrConfirmList { get; set; }
        public string Hash { get; set; }
        public ContractData ContractData { get; set; }
        public Dictionary<string, object> InternalTransactions { get; set; } = new Dictionary<string, object>();
    }
}
