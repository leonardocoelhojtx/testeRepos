using System;
using System.Collections.Generic;
using System.Text;

namespace Private.Domain.Models
{
    public class CustomerUserModel
    {
        private Int64 _id;

        public Int64 Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private Int64 _idCustomer;

        public Int64 IdCustomer
        {
            get { return _idCustomer; }
            set { _idCustomer = value; }
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
            set { _changeDateTime = value; }
        }
    }
}
