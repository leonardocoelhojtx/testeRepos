using System;
using System.Collections.Generic;
using System.Text;

namespace Private.Domain.Models
{
    public class CustomerModel
    {
		private Int64 _id;

		public Int64 Id
		{
			get { return _id; }
			set { _id = value; }
		}

		private Int64 _idPessoa;

		public Int64 IdPessoa
		{
			get { return _idPessoa; }
			set { _idPessoa = value; }
		}

	}
}
