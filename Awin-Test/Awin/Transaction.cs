﻿using System;
using System.Collections.Generic;

namespace Awin_Test
{
    public class Transaction
    {
        public int id { get; set; }
        public string url { get; set; }
        public int advertiserId { get; set; }
        public int publisherId { get; set; }
        public int commissionSharingPublisherId { get; set; }
        public int commissionSharingSelectedRatePublisherId { get; set; }
        public string siteName { get; set; }
        public string commissionStatus { get; set; }
        public CommissionAmount commissionAmount { get; set; }
        public SaleAmount saleAmount { get; set; }
        public string ipHash { get; set; }
        public string customerCountry { get; set; }
        public ClickRefs clickRefs { get; set; }
        public DateTime clickDate { get; set; }
        public DateTime transactionDate { get; set; }
        public object validationDate { get; set; }
        public string type { get; set; }
        public object declineReason { get; set; }
        public bool voucherCodeUsed { get; set; }
        public string voucherCode { get; set; }
        public int lapseTime { get; set; }
        public bool amended { get; set; }
        public object amendReason { get; set; }
        public object oldSaleAmount { get; set; }
        public object oldCommissionAmount { get; set; }
        public string clickDevice { get; set; }
        public string transactionDevice { get; set; }
        public string publisherUrl { get; set; }
        public string advertiserCountry { get; set; }
        public string orderRef { get; set; }
        public List<CustomParameter> customParameters { get; set; }
        public List<TransactionPart> transactionParts { get; set; }
        public bool paidToPublisher { get; set; }
        public int paymentId { get; set; }
        public int transactionQueryId { get; set; }
        public object originalSaleAmount { get; set; }
    }
}