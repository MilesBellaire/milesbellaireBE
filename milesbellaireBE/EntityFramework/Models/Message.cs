﻿using MbCore.EntityFramework.Models;

namespace MbCore.EntityFramework.Models
{
    public class Message : BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Text { get; set; }
    }
}
