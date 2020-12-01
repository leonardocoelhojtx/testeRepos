using System;
using System.Collections.Generic;
using System.Text;

namespace Private.Domain.Models
{
    public class PlanAttributeModel
    {
        private Int64 _id;

        public Int64 Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private Int64 _idBillingAttribute;

        public Int64 IdBillingAttribute
        {
            get { return _idBillingAttribute; }
            set { _idBillingAttribute = value; }
        }

        private Int64 _idBillingPlan;

        public Int64 IdBillingPlan
        {
            get { return _idBillingPlan; }
            set { _idBillingPlan = value; }
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

        private double _quantity;

        public double Quantity
        {
            get { return _quantity; }
            set { _quantity = value; }
        }

    }
}