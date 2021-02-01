using System;
using System.Collections.Generic;
using System.Text;

namespace Private.Domain.Models
{
    public class BillingPlanModel
    {
        private Int64 _id;

        public Int64 Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private string _code;

        public string Code
        {
            get { return _code; }
            set { _code = value; }
        }

        private string _description;

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        private string _situation;

        public string Situation
        {
            get { return _situation; }
            set { _situation = value; }
        }

        private DateTime _startOfTerm;

        public DateTime StartOfTerm
        {
            get { return _startOfTerm; }
            set { _startOfTerm = value; }
        }

        private DateTime _endOfTerm;

        public DateTime EndOfTerm
        {
            get { return _endOfTerm; }
            set { _endOfTerm = value; }
        }

        private double _value;

        public double Value
        {
            get { return _value; }
            set { _value = value; }
        }

        public DateTime InclusionDateTime { get; set; } = DateTime.Now;

        private Int64 _inclusionIdUser;

        public Int64 InclusionIdUser
        {
            get { return _inclusionIdUser; }
            set { _inclusionIdUser = value; }
        }

        public DateTime ChangeDateTime { get; set; } = DateTime.Now;

        private Int64 _changeIdUser;

        public Int64 ChangeIdUser
        {
            get { return _changeIdUser; }
            set { _changeIdUser = value; }
        }

        private Int64 _effectiveDays;

        public Int64 EffectiveDays
        {
            get { return _effectiveDays; }
            set { _effectiveDays = value; }
        }

        private Int64 _graceDays;

        public Int64 GraceDays
        {
            get { return _graceDays; }
            set { _graceDays = value; }
        }

        private string _billingCycle;

        public string BillingCycle
        {
            get { return _billingCycle; }
            set { _billingCycle = value; }
        }
    }
}