using System;
using System.Collections.Generic;
using System.Text;

namespace Private.Domain.Models
{
    public class PartnerUserModel
    {
        private Int64 _id;

        public Int64 Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private Int64 _idPartner;

        public Int64 IdPartner
        {
            get { return _idPartner; }
            set { _idPartner = value; }
        }

        private Int64 _idUser;

        public Int64 IdUser
        {
            get { return _idUser; }
            set { _idUser = value; }
        }

        private string _situation;

        public string Situation
        {
            get { return _situation; }
            set { _situation = value; }
        }

        private Int64 _inclusionIdUser;

        public Int64 InclusionIdUser
        {
            get { return _inclusionIdUser; }
            set { _inclusionIdUser = value; }
        }

        private DateTime _inclusionDateTime;

        public DateTime InclusionDateTime
        {
            get { return _inclusionDateTime; }
            set { _inclusionDateTime = value; }
        }

        private Int64? _changeIdUser;

        public Int64? ChangeIdUser
        {
            get { return _changeIdUser; }
            set { _changeIdUser = value; }
        }

        private DateTime _changeDateTime;

        public DateTime ChangeDateTime
        {
            get { return _changeDateTime; }
            set { _changeDateTime = value;  }
        }
    }
}