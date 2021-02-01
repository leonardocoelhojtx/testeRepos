using System;
using System.Collections.Generic;
using System.Text;

namespace Private.Domain.Models
{
    public class PersonModel
    {
		private Int64? _id;

		public Int64? Id
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

        private DateTime _birthDateTime;

        public DateTime BirthDateTime
        {
            get { return _birthDateTime; }
            set { _birthDateTime = value; }
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
            get { return _primaryPhone; }
            set { _primaryPhone = value; }
        }

        private string _alternativePhone;

        public string AlternativePhone
        {
            get { return _alternativePhone; }
            set { _alternativePhone = value; }
        }

        private string _legalPhysics;

        public string LegalPhysics
        {
            get { return _legalPhysics; }
            set { _legalPhysics = value; }
        }

        private string _contactName;

        public string ContactName
        {
            get { return _contactName; }
            set { _contactName = value; }
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
