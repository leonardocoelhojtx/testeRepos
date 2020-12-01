using System;
using System.Collections.Generic;
using System.Text;

namespace Private.Domain.Models
{
    public class PartnerModel
    {
        private Int64 _id;

        public Int64 Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private string _reasonName;
        public string ReasonName 
        {
            get { return _reasonName; }
            set { _reasonName = value; }
        }

        private string _fantasy;
        public string Fantasy 
        {
            get { return _fantasy; }
            set { _fantasy = value; }
        }

        private Int64 _cpfCnpj;
        public Int64 CpfCnpj 
        {
            get { return _cpfCnpj; }
            set { _cpfCnpj = value; }
        }

        private string _email;
        public string Email 
        {
            get { return _email; }
            set { _email = value; }
        }

        private string _primaryPhone;
        public string PrimaryPhone 
        {
            get { return _email; }
            set { _email = value; }
        }

        private string _alternativePhone;
        public string AlternativePhone 
        {
            get { return _alternativePhone; }
            set { _alternativePhone = value; }
        }

        private string _status;
        public string Status 
        {
            get { return _status; }
            set { _status = value; }
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

        private Int64 _changeIdUser;
        public Int64 ChangeIdUser 
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
