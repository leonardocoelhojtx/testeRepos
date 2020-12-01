using System;
using System.Collections.Generic;
using System.Text;

namespace Private.Domain.Models
{
    public class PartnerBillingPlanModel
    {
        private Int64 _id;

        public Int64 Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private Int64 _idBillingPlan;

        public Int64 IdBillingPlan
        {
            get { return _idBillingPlan; }
            set { _idBillingPlan = value; }
        }

        private Int64 _idPartnerPerson;

        public Int64 IdPartnerPerson
        {
            get { return _idPartnerPerson; }
            set { _idPartnerPerson = value; }
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

        private double _saleValue;

        public double SaleValue
        {
            get { return _saleValue; }
            set { _saleValue = value; }
        }

        private double _partnerValue;

        public double PartnerValue
        {
            get { return _partnerValue; }
            set { _partnerValue = value; }
        }

        private double _resaleValue;

        public double ResaleValue
        {
            get { return _resaleValue; }
            set { _resaleValue = value; }
        }

        private string _accessCode;

        public string AccessCode
        {
            get { return _accessCode; }
            set { _accessCode = value; }
        }

        private string _situation;

        public string Situation
        {
            get { return _situation; }
            set { _situation = value; }
        }

        private string _visibility;

        public string Visibility
        {
            get { return _visibility; }
            set { _visibility = value; }
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
    }
}
