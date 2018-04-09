using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HW.LabStore.Entity
{
    public class ApprovalIntermediateResult
    {
        private const int PRECENT_RATE = 100;

        public string PTDHeader { get; set; }
        public decimal PTDRevenue { get; set; }
        public decimal PTDCost { get; set; }
        public decimal PTDMargin
        {
            get { return PTDRevenue - PTDCost; }
        }
        /// <summary>
        /// ($)%
        /// </summary>
        public decimal PTDMarginPrecent
        {
            get
            {
                if (PTDRevenue == 0)
                {
                    return 0;
                }
                return PTDMargin / PTDRevenue * PRECENT_RATE;
            }
        }

        public string FirstHeader { get; set; }
        public decimal FirstRevenue { get; set; }
        public decimal FirstCost { get; set; }
        public decimal FirstMargin
        {
            get { return FirstRevenue - FirstCost; }
        }
        public decimal FirstMarginPrecent
        {
            get
            {
                if (FirstRevenue == 0)
                {
                    return 0;
                }
                return FirstMargin / FirstRevenue * PRECENT_RATE;
            }
        }

        public string RevisedHeader { get; set; }
        public decimal RevisedRevenue { get; set; }
        public decimal RevisedCost { get; set; }
        public decimal RevisedMargin
        {
            get { return RevisedRevenue - RevisedCost; }
        }
        public decimal RevisedMarginPrecent
        {
            get
            {
                if (RevisedRevenue == 0)
                {
                    return 0;
                }
                return RevisedMargin / RevisedRevenue * PRECENT_RATE;
            }
        }

        public string CostSheetHeader { get; set; }
        public decimal CostSheetRevenue { get; set; }
        public decimal CostSheetCost { get; set; }
        public decimal CostSheetMargin
        {
            get { return CostSheetRevenue - CostSheetCost; }
        }
        public decimal CostSheetMarginPrecent
        {
            get
            {
                if (CostSheetRevenue == 0)
                {
                    return 0;
                }
                return CostSheetMargin / CostSheetRevenue * PRECENT_RATE;
            }
        }

        public string ProposedHeader { get; set; }
        public decimal ProposedRevenue { get; set; }
        public decimal ProposedCost { get; set; }
        public decimal ProposedMargin
        {
            get { return ProposedRevenue - ProposedCost; }
        }
        public decimal PropsoedMarginPrecent
        {
            get
            {
                if (ProposedRevenue == 0)
                {
                    return 0;
                }
                return ProposedMargin / ProposedRevenue * PRECENT_RATE;
            }
        }

        public string VarianceHeader { get; set; }
        public decimal VarianceRevenue { get; set; }

        public decimal VarianceCost { get; set; }
        public decimal VarianceMargin
        {
            get { return VarianceRevenue - VarianceCost; }
        }
        public decimal VarianceMarginPrecent
        {
            get
            {
                if (VarianceRevenue == 0)
                {
                    return 0;
                }
                return VarianceMargin / VarianceRevenue * PRECENT_RATE;
            }
        }

        public string NetHeader { get; set; }
        public decimal NetRevenue { get; set; }
        public decimal NetCost { get; set; }
        public decimal NetMargin
        {
            get { return NetRevenue - NetCost; }
        }
        public decimal NetMarginPrecent
        {
            get
            {
                if (NetRevenue == 0)
                {
                    return 0;
                }
                return NetMargin / NetRevenue * PRECENT_RATE;
            }
        }

        public decimal MarginErosion { get; set; }
    }
}
