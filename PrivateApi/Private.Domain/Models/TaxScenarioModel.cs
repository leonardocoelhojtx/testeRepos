using System;
using System.Collections.Generic;
using System.Text;

namespace Private.Domain.Models
{
    public class TaxScenarioModel
    {
        private Int64 _id;

        public Int64 Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private string _description;

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        private Int64 _idRegime;

        public Int64 IdRegime
        {
            get { return _idRegime; }
            set { _idRegime = value; }
        }

        private Int64? _idOriginProfile;

        public Int64? IdOriginProfile
        {
            get { return _idOriginProfile; }
            set { _idOriginProfile = value; }
        }

        private Int64? _idDestinationProfile;

        public Int64? IdDestinationProfile
        {
            get { return _idDestinationProfile; }
            set { _idDestinationProfile = value; }
        }

        private string _originUF;

        public string OriginUF
        {
            get { return _originUF; }
            set { _originUF = value; }
        }

        private string _destinationUF;

        public string DestinationUF
        {
            get { return _destinationUF; }
            set { _destinationUF = value; }
        }

        private string _cnae;

        public string CNAE
        {
            get { return _cnae; }
            set { _cnae = value; }
        }

        private DateTime _startOfTerm;

        public DateTime StartOfTerm
        {
            get { return _startOfTerm; }
            set { _startOfTerm = value; }
        }

        private DateTime? _endOfTerm;

        public DateTime? EndOfTerm
        {
            get { return _endOfTerm; }
            set { _endOfTerm = value; }
        }

        private Int64? _idOperationNature;

        public Int64? IdOperationNature
        {
            get { return _idOperationNature; }
            set { _idOperationNature = value; }
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

        public DateTime InclusionDateTime { get; set; } = DateTime.Now;

        private Int64 _changeIdUser;

        public Int64 ChangeIdUser
        {
            get { return _changeIdUser; }
            set { _changeIdUser = value; }
        }

        public DateTime ChangeDateTime { get; set; } = DateTime.Now;
    }
}