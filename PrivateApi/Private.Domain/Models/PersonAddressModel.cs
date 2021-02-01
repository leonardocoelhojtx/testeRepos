using System;
using System.Collections.Generic;
using System.Text;

namespace Private.Domain.Models
{
    public class PersonAddressModel
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

        private Int64 _type;

        public Int64 Type
        {
            get { return _type; }
            set { _type = value; }
        }


        private Int64 _cep;

        public Int64 Cep
        {
            get { return _cep; }
            set { _cep = value; }
        }

        private string _street;

        public string Street
        {
            get { return _street; }
            set { _street = value; }
        }

        private string _number;

        public string Number
        {
            get { return _number; }
            set { _number = value; }
        }

        private string _complement;

        public string Complement
        {
            get { return _complement; }
            set { _complement = value; }
        }

        private string _neighborhood;

        public string Neighborhood
        {
            get { return _neighborhood; }
            set { _neighborhood = value; }
        }

        private string _city;

        public string City
        {
            get { return _city; }
            set { _city = value; }
        }

        private string _state;

        public string State
        {
            get { return _state; }
            set { _state = value; }
        }

        private string _country;

        public string Country
        {
            get { return _country; }
            set { _country = value; }
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
