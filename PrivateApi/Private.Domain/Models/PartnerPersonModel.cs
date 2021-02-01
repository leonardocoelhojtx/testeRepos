using System;
using System.Collections.Generic;
using System.Text;

namespace Private.Domain.Models
{
    public class PartnerPersonModel
    {
        private Int64 _id;

        public Int64 Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private Int64 _idPerson;

        public Int64 IdPerson
        {
            get { return _idPerson; }
            set { _idPerson = value; }
        }

        private string _status;

        public string Status
        {
            get { return _status; }
            set { _status = value; }
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

        private string _chargeResponsible;

        public string ChargeResponsible
        {
            get { return _chargeResponsible; }
            set { _chargeResponsible = value; }
        }
    }
}
