﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Private.Domain.Entities
{
    public class BaseEntity
    {
        [Key]
        public virtual Int64 Id { get; set; }
        //private DateTime? _createdAt;
        //public DateTime? CreatedAt
        //{
        //    get { return _createdAt; }
        //    set { _createdAt = (value == null ? DateTime.UtcNow : value); }
        //}
        //public DateTime? UpdatedAt { get; set; }
    }
}